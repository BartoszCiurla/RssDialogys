namespace RssDialogys.WinFormsUI
{
    partial class PresentationForm
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
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCategoryInformation = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowMetroCategories = new System.Windows.Forms.Button();
            this.btCloseOpenCantegories = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bwScrollEffect = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp
            // 
            this.flp.Location = new System.Drawing.Point(12, 66);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(914, 746);
            this.flp.TabIndex = 1;
            // 
            // flpCategories
            // 
            this.flpCategories.Location = new System.Drawing.Point(3, 64);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Size = new System.Drawing.Size(310, 746);
            this.flpCategories.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(411, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 21);
            this.label17.TabIndex = 6;
            this.label17.Text = "label17";
            // 
            // lblCategoryInformation
            // 
            this.lblCategoryInformation.AutoSize = true;
            this.lblCategoryInformation.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCategoryInformation.ForeColor = System.Drawing.Color.White;
            this.lblCategoryInformation.Location = new System.Drawing.Point(99, 12);
            this.lblCategoryInformation.Name = "lblCategoryInformation";
            this.lblCategoryInformation.Size = new System.Drawing.Size(143, 37);
            this.lblCategoryInformation.TabIndex = 13;
            this.lblCategoryInformation.Text = "Categorie";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShowMetroCategories);
            this.panel1.Controls.Add(this.btCloseOpenCantegories);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.flp);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(328, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 822);
            this.panel1.TabIndex = 16;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PF_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PF_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PF_MouseUp);
            // 
            // btnShowMetroCategories
            // 
            this.btnShowMetroCategories.BackgroundImage = global::RssDialogys.WinFormsUI.Properties.Resources.appbar_list_star;
            this.btnShowMetroCategories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowMetroCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowMetroCategories.Location = new System.Drawing.Point(97, 0);
            this.btnShowMetroCategories.Name = "btnShowMetroCategories";
            this.btnShowMetroCategories.Size = new System.Drawing.Size(80, 57);
            this.btnShowMetroCategories.TabIndex = 15;
            this.btnShowMetroCategories.UseVisualStyleBackColor = true;
            this.btnShowMetroCategories.Click += new System.EventHandler(this.btnShowMetroCategories_Click);
            // 
            // btCloseOpenCantegories
            // 
            this.btCloseOpenCantegories.BackgroundImage = global::RssDialogys.WinFormsUI.Properties.Resources.appbar_arrow_left_right;
            this.btCloseOpenCantegories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btCloseOpenCantegories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCloseOpenCantegories.Location = new System.Drawing.Point(12, 0);
            this.btCloseOpenCantegories.Name = "btCloseOpenCantegories";
            this.btCloseOpenCantegories.Size = new System.Drawing.Size(80, 57);
            this.btCloseOpenCantegories.TabIndex = 14;
            this.btCloseOpenCantegories.UseVisualStyleBackColor = true;
            this.btCloseOpenCantegories.Click += new System.EventHandler(this.btCloseOpenCantegories_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackgroundImage = global::RssDialogys.WinFormsUI.Properties.Resources.appbar_power;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(846, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 57);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::RssDialogys.WinFormsUI.Properties.Resources.appbar_download;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(760, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 57);
            this.button4.TabIndex = 11;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.LoadScrollingForm);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::RssDialogys.WinFormsUI.Properties.Resources.appbar_arrow_left;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(325, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 57);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::RssDialogys.WinFormsUI.Properties.Resources.appbar_arrow1_right;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(528, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 57);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bwScrollEffect
            // 
            this.bwScrollEffect.WorkerReportsProgress = true;
            this.bwScrollEffect.WorkerSupportsCancellation = true;
            this.bwScrollEffect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwScrollEffect_DoWork);
            this.bwScrollEffect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwScrollEffect_RunWorkerCompleted);
            // 
            // PresentationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1266, 822);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCategoryInformation);
            this.Controls.Add(this.flpCategories);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PresentationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PresentationForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PF_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PF_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PF_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flpCategories;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblCategoryInformation;
        private System.Windows.Forms.Button btCloseOpenCantegories;
        private System.Windows.Forms.Button btnShowMetroCategories;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker bwScrollEffect;
    }
}