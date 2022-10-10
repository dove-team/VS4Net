using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace VS4Net
{
    class DownoadManager
    {
        private static DownoadManager instance;
        public static DownoadManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DownoadManager();
                return instance;
            }
        }
        public void Clear() => List.Clear();
        public bool Running { get; private set; }
        private List<string> List { get; }
        private readonly string TARGET_ROOT_DIR = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Reference Assemblies\Microsoft\Framework\.NETFramework";
        private DownoadManager()
        {
            Running = false;
            List = new List<string>();
        }
        public void Add(string link) => List.Add(link);
        public int Count => List.Count;
        public void Start()
        {
            Task.Run(() =>
            {
                try
                {
                    if (List != null && List.Count > 0)
                    {
                        Running = true;
                        MainForm.Log("Start Download!Target folder is " + TARGET_ROOT_DIR);
                        var files = new List<string>();
                        foreach (var item in List)
                        {
                            if (!Running) return;
                            string logname = ".NETFramework " + item.Replace("Microsoft.NETFramework.ReferenceAssemblies.net", "");
                            MainForm.Log("GetVersion " + logname);
                            var version = NugetManager.Instance.GetVersion(item).Result;
                            MainForm.Log("Downloading " + logname);
                            if (!Running) return;
                            var filePath = NugetManager.Instance.Download(item, version).Result;
                            if (!Running) return;
                            MainForm.Log(logname + " Download finished!");
                            if (!string.IsNullOrEmpty(filePath))
                                files.Add(filePath);
                        }
                        UnZip(files);
                    }
                    MainForm.Log("All done,enjoy it!");
                }
                catch (Exception ex)
                {
                    MainForm.Log("Error happens:" + ex.Message);
                }
                finally
                {
                    MainForm.SetEnable(true);
                    Running = false;
                }
            });
        }
        private void UnZip(List<string> files)
        {
            MainForm.Log("Start unzip files!");
            foreach (var file in files)
            {
                MainForm.Log("Unzipping " + file);
                try
                {
                    using (ZipInputStream s = new ZipInputStream(File.OpenRead(file)))
                    {
                        ZipEntry theEntry;
                        while ((theEntry = s.GetNextEntry()) != null)
                        {
                            string directoryName = Path.GetDirectoryName(theEntry.Name),
                                sourceDir = directoryName.Replace("build\\.NETFramework", ""),
                                fileName = theEntry.Name.Replace("build/.NETFramework", "");
                            if (directoryName.StartsWith("build\\.NETFramework\\v4"))
                            {
                                if (directoryName.Length > 0)
                                    Directory.CreateDirectory($"{TARGET_ROOT_DIR}\\{sourceDir}");
                                if (fileName != string.Empty)
                                {
                                    using (var streamWriter = File.Create($"{TARGET_ROOT_DIR}\\{fileName}"))
                                    {
                                        int size = 2048;
                                        byte[] data = new byte[2048];
                                        while (true)
                                        {
                                            size = s.Read(data, 0, data.Length);
                                            if (size > 0)
                                                streamWriter.Write(data, 0, size);
                                            else
                                                break;
                                        }
                                    }
                                }
                            }
                            if (!Running) return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MainForm.Log("unzip error:"+ex.Message);
                } 
                Thread.Sleep(200);
                MainForm.Log("delete origin file");
                File.Delete(file);
            }
            MainForm.Log("Unzip files finished!");
        }
        public void Abort()
        {
            Running = false;
        }
    }
}