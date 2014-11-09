namespace RssDialogys.WinFormsUI
{
    partial class ShadowForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShadowForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wiadomościTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.raportTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.opcjeTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.zakmnijTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.timerForDownload = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.progressTxt = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "RssDialogys";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wiadomościTSMI,
            this.updateTSMI,
            this.raportTSMI,
            this.opcjeTSMI,
            this.zakmnijTSMI});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 114);
            // 
            // wiadomościTSMI
            // 
            this.wiadomościTSMI.Name = "wiadomościTSMI";
            this.wiadomościTSMI.Size = new System.Drawing.Size(140, 22);
            this.wiadomościTSMI.Text = "Wiadomości";
            this.wiadomościTSMI.Click += new System.EventHandler(this.wiadomościTSMI_Click);
            // 
            // updateTSMI
            // 
            this.updateTSMI.Name = "updateTSMI";
            this.updateTSMI.Size = new System.Drawing.Size(140, 22);
            this.updateTSMI.Text = "Update";
            this.updateTSMI.Click += new System.EventHandler(this.updateTSMI_Click);
            // 
            // raportTSMI
            // 
            this.raportTSMI.Name = "raportTSMI";
            this.raportTSMI.Size = new System.Drawing.Size(140, 22);
            this.raportTSMI.Text = "Raport";
            this.raportTSMI.Click += new System.EventHandler(this.raportTSMI_Click);
            // 
            // opcjeTSMI
            // 
            this.opcjeTSMI.BackColor = System.Drawing.Color.White;
            this.opcjeTSMI.Name = "opcjeTSMI";
            this.opcjeTSMI.Size = new System.Drawing.Size(140, 22);
            this.opcjeTSMI.Text = "Opcje";
            this.opcjeTSMI.Click += new System.EventHandler(this.opcjeTSMI_Click);
            // 
            // zakmnijTSMI
            // 
            this.zakmnijTSMI.Name = "zakmnijTSMI";
            this.zakmnijTSMI.Size = new System.Drawing.Size(140, 22);
            this.zakmnijTSMI.Text = "Zamknij";
            this.zakmnijTSMI.Click += new System.EventHandler(this.zakmnijTSMI_Click);
            // 
            // timerForDownload
            // 
            this.timerForDownload.Interval = 1;
            this.timerForDownload.Tick += new System.EventHandler(this.timerForDownload_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Black;
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.progressBar1.Location = new System.Drawing.Point(1, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(313, 49);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(85, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Postęp";
            // 
            // progressTxt
            // 
            this.progressTxt.BackColor = System.Drawing.Color.Black;
            this.progressTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.progressTxt.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.progressTxt.ForeColor = System.Drawing.Color.White;
            this.progressTxt.Location = new System.Drawing.Point(153, 64);
            this.progressTxt.Name = "progressTxt";
            this.progressTxt.ReadOnly = true;
            this.progressTxt.Size = new System.Drawing.Size(51, 20);
            this.progressTxt.TabIndex = 0;
            this.progressTxt.TabStop = false;
            this.progressTxt.Text = "0";
            // 
            // ShadowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(315, 89);
            this.Controls.Add(this.progressTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShadowForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem raportTSMI;
        private System.Windows.Forms.ToolStripMenuItem opcjeTSMI;
        private System.Windows.Forms.ToolStripMenuItem zakmnijTSMI;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Timer timerForDownload;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox progressTxt;
        private System.Windows.Forms.ToolStripMenuItem updateTSMI;
        private System.Windows.Forms.ToolStripMenuItem wiadomościTSMI;

    }
}

