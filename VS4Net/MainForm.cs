using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VS4Net
{
    public partial class MainForm : Form
    {
        private static MainForm self;
        public MainForm()
        {
            InitializeComponent();
            self = this;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            DownoadManager.Instance.Clear();
            Regex regex = new Regex(@"(\-|\+)?\d+(\.\d+)?(\.\d+)?");
            foreach (var item in checkedListBoxVersion.CheckedItems)
            {
                var match = regex.Match(item.ToString());
                var link = $"Microsoft.NETFramework.ReferenceAssemblies.net{match.Value.Replace(".", "")}";
                DownoadManager.Instance.Add(link);
            } 
            if(DownoadManager.Instance.Count()==0)
            {
                MessageBox.Show("Please select item!");
                return;
            }
            MainForm.setEnable(false);
            self.textBoxMsg.Clear();
            DownoadManager.Instance.Start();
        }

        public static void setEnable( bool enable)
        {
            self.Invoke(new MethodInvoker(delegate ()
            {
                self.buttonStart.Enabled = enable;
                self.checkedListBoxVersion.Enabled = enable;
                self.btn_checkall.Enabled = enable;
                if (enable)
                {
                    self.buttonStart.Text = "Start";
                }
                else
                {
                    self.buttonStart.Text = "Running";
                } 
            }));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DownoadManager.Instance.Running)
            {
                if (MessageBox.Show("Task Still Running, Are You Sure to Cancel?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DownoadManager.Instance.Abort();
                    Application.Exit();
                }
                else
                    e.Cancel = true;
            } 

        }

        public static void Log(string log)
        {
            try
            {
                self.Invoke(new MethodInvoker(delegate ()
                {
                    self.textBoxMsg.AppendText(DateTime.Now.ToString("HH:mm:ss") + ">>" + log + "\r\n");
                    self.textBoxMsg.ScrollToCaret();
                }));
            }
            catch { }
        }

        private void btn_checkall_Click(object sender, EventArgs e)
        {
            for(int i=0;i<checkedListBoxVersion.Items.Count;i++)
            {
                checkedListBoxVersion.SetItemChecked(i,true);
            } 
        }
    }
}