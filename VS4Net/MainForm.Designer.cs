namespace VS4Net
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBoxVersion = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_checkall = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxVersion
            // 
            this.checkedListBoxVersion.FormattingEnabled = true;
            this.checkedListBoxVersion.Items.AddRange(new object[] {
            ".Net Framework 3.5",
            ".Net Framework 4.0",
            ".Net Framework 4.5",
            ".Net Framework 4.5.1",
            ".Net Framework 4.5.2",
            ".Net Framework 4.6",
            ".Net Framework 4.6.1",
            ".Net Framework 4.6.2",
            ".Net Framework 4.7",
            ".Net Framework 4.7.1",
            ".Net Framework 4.7.2",
            ".Net Framework 4.8",
            ".Net Framework 4.8.1"});
            this.checkedListBoxVersion.Location = new System.Drawing.Point(141, 22);
            this.checkedListBoxVersion.Name = "checkedListBoxVersion";
            this.checkedListBoxVersion.Size = new System.Drawing.Size(248, 84);
            this.checkedListBoxVersion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Version:";
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMsg.Location = new System.Drawing.Point(12, 188);
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.ReadOnly = true;
            this.textBoxMsg.Size = new System.Drawing.Size(419, 333);
            this.textBoxMsg.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output Info:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(314, 119);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.btn_checkall);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Controls.Add(this.checkedListBoxVersion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 170);
            this.panel1.TabIndex = 4;
            // 
            // btn_checkall
            // 
            this.btn_checkall.Location = new System.Drawing.Point(233, 119);
            this.btn_checkall.Name = "btn_checkall";
            this.btn_checkall.Size = new System.Drawing.Size(75, 23);
            this.btn_checkall.TabIndex = 4;
            this.btn_checkall.Text = "CheckAll";
            this.btn_checkall.UseVisualStyleBackColor = true;
            this.btn_checkall.Click += new System.EventHandler(this.btn_checkall_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 533);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxMsg);
            this.MinimumSize = new System.Drawing.Size(459, 572);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VS4Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_checkall;
    }
}

