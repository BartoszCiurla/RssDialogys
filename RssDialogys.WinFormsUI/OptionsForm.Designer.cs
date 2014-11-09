namespace RssDialogys.WinFormsUI
{
    partial class OptionsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.win8ToggleSwitch4 = new Binarymission.WinForms.Controls.ToggleControls.Win8ToggleSwitch();
            this.win8ToggleSwitch3 = new Binarymission.WinForms.Controls.ToggleControls.Win8ToggleSwitch();
            this.win8ToggleSwitch2 = new Binarymission.WinForms.Controls.ToggleControls.Win8ToggleSwitch();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.win8ToggleSwitch1 = new Binarymission.WinForms.Controls.ToggleControls.Win8ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Update po uruchomieniu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Częstotliwość pobierania danych";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Wyświetl rezultat pobrania";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Wyświetl powiadomienia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Wyświetl nasze kanały RSS";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(65, 185);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ReadOnly = true;
            this.maskedTextBox1.Size = new System.Drawing.Size(39, 20);
            this.maskedTextBox1.TabIndex = 10;
            // 
            // win8ToggleSwitch4
            // 
            this.win8ToggleSwitch4.BackgroundEndColor = System.Drawing.Color.DarkGray;
            this.win8ToggleSwitch4.BackgroundEndColorUnchecked = System.Drawing.Color.DarkGray;
            this.win8ToggleSwitch4.BackgroundStartColor = System.Drawing.Color.White;
            this.win8ToggleSwitch4.BackgroundStartColorUnchecked = System.Drawing.Color.White;
            this.win8ToggleSwitch4.InnerBorderColor = System.Drawing.Color.Black;
            this.win8ToggleSwitch4.InnerBorderColorUnchecked = System.Drawing.Color.Black;
            this.win8ToggleSwitch4.InnerBorderThickness = 1;
            this.win8ToggleSwitch4.IsChecked = false;
            this.win8ToggleSwitch4.Location = new System.Drawing.Point(40, 450);
            this.win8ToggleSwitch4.Name = "win8ToggleSwitch4";
            this.win8ToggleSwitch4.OuterBorderColor = System.Drawing.Color.LightGray;
            this.win8ToggleSwitch4.OuterBorderColorUnchecked = System.Drawing.Color.LightGray;
            this.win8ToggleSwitch4.OuterBorderThickness = 3;
            this.win8ToggleSwitch4.ShouldDrawFocusRectangleWhenFocused = false;
            this.win8ToggleSwitch4.ShouldDrawGapBetweenSwitchStickAndTrack = false;
            this.win8ToggleSwitch4.Size = new System.Drawing.Size(75, 23);
            this.win8ToggleSwitch4.SwitchStickControlGapWidth = 0;
            this.win8ToggleSwitch4.TabIndex = 8;
            this.win8ToggleSwitch4.Text = "win8ToggleSwitch4";
            this.win8ToggleSwitch4.ToggleStickColor = System.Drawing.Color.OrangeRed;
            this.win8ToggleSwitch4.ToggleStickColorUnchecked = System.Drawing.Color.OrangeRed;
            this.win8ToggleSwitch4.ToggleSwitchStickWidth = 13;
            this.win8ToggleSwitch4.MouseCaptureChanged += new System.EventHandler(this.TemporarySave);
            // 
            // win8ToggleSwitch3
            // 
            this.win8ToggleSwitch3.BackgroundEndColor = System.Drawing.Color.DarkGray;
            this.win8ToggleSwitch3.BackgroundEndColorUnchecked = System.Drawing.Color.DarkGray;
            this.win8ToggleSwitch3.BackgroundStartColor = System.Drawing.Color.White;
            this.win8ToggleSwitch3.BackgroundStartColorUnchecked = System.Drawing.Color.White;
            this.win8ToggleSwitch3.InnerBorderColor = System.Drawing.Color.Black;
            this.win8ToggleSwitch3.InnerBorderColorUnchecked = System.Drawing.Color.Black;
            this.win8ToggleSwitch3.InnerBorderThickness = 1;
            this.win8ToggleSwitch3.IsChecked = false;
            this.win8ToggleSwitch3.Location = new System.Drawing.Point(40, 361);
            this.win8ToggleSwitch3.Name = "win8ToggleSwitch3";
            this.win8ToggleSwitch3.OuterBorderColor = System.Drawing.Color.LightGray;
            this.win8ToggleSwitch3.OuterBorderColorUnchecked = System.Drawing.Color.LightGray;
            this.win8ToggleSwitch3.OuterBorderThickness = 3;
            this.win8ToggleSwitch3.ShouldDrawFocusRectangleWhenFocused = false;
            this.win8ToggleSwitch3.ShouldDrawGapBetweenSwitchStickAndTrack = false;
            this.win8ToggleSwitch3.Size = new System.Drawing.Size(75, 23);
            this.win8ToggleSwitch3.SwitchStickControlGapWidth = 0;
            this.win8ToggleSwitch3.TabIndex = 6;
            this.win8ToggleSwitch3.Text = "win8ToggleSwitch3";
            this.win8ToggleSwitch3.ToggleStickColor = System.Drawing.Color.OrangeRed;
            this.win8ToggleSwitch3.ToggleStickColorUnchecked = System.Drawing.Color.OrangeRed;
            this.win8ToggleSwitch3.ToggleSwitchStickWidth = 13;
            this.win8ToggleSwitch3.MouseCaptureChanged += new System.EventHandler(this.TemporarySave);
            // 
            // win8ToggleSwitch2
            // 
            this.win8ToggleSwitch2.BackgroundEndColor = System.Drawing.Color.DarkGray;
            this.win8ToggleSwitch2.BackgroundEndColorUnchecked = System.Drawing.Color.DarkGray;
            this.win8ToggleSwitch2.BackgroundStartColor = System.Drawing.Color.White;
            this.win8ToggleSwitch2.BackgroundStartColorUnchecked = System.Drawing.Color.White;
            this.win8ToggleSwitch2.InnerBorderColor = System.Drawing.Color.Black;
            this.win8ToggleSwitch2.InnerBorderColorUnchecked = System.Drawing.Color.Black;
            this.win8ToggleSwitch2.InnerBorderThickness = 1;
            this.win8ToggleSwitch2.IsChecked = true;
            this.win8ToggleSwitch2.Location = new System.Drawing.Point(40, 257);
            this.win8ToggleSwitch2.Name = "win8ToggleSwitch2";
            this.win8ToggleSwitch2.OuterBorderColor = System.Drawing.Color.LightGray;
            this.win8ToggleSwitch2.OuterBorderColorUnchecked = System.Drawing.Color.LightGray;
            this.win8ToggleSwitch2.OuterBorderThickness = 3;
            this.win8ToggleSwitch2.ShouldDrawFocusRectangleWhenFocused = false;
            this.win8ToggleSwitch2.ShouldDrawGapBetweenSwitchStickAndTrack = false;
            this.win8ToggleSwitch2.Size = new System.Drawing.Size(75, 23);
            this.win8ToggleSwitch2.SwitchStickControlGapWidth = 0;
            this.win8ToggleSwitch2.TabIndex = 4;
            this.win8ToggleSwitch2.Text = "win8ToggleSwitch2";
            this.win8ToggleSwitch2.ToggleStickColor = System.Drawing.Color.OrangeRed;
            this.win8ToggleSwitch2.ToggleStickColorUnchecked = System.Drawing.Color.OrangeRed;
            this.win8ToggleSwitch2.ToggleSwitchStickWidth = 13;
            this.win8ToggleSwitch2.MouseCaptureChanged += new System.EventHandler(this.TemporarySave);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(27, 144);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(120, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 1;
            this.trackBar1.MouseCaptureChanged += new System.EventHandler(this.TemporarySave);
            // 
            // win8ToggleSwitch1
            // 
            this.win8ToggleSwitch1.BackgroundEndColor = System.Drawing.Color.DarkGray;
            this.win8ToggleSwitch1.BackgroundEndColorUnchecked = System.Drawing.Color.DarkGray;
            this.win8ToggleSwitch1.BackgroundStartColor = System.Drawing.Color.White;
            this.win8ToggleSwitch1.BackgroundStartColorUnchecked = System.Drawing.Color.White;
            this.win8ToggleSwitch1.InnerBorderColor = System.Drawing.Color.Black;
            this.win8ToggleSwitch1.InnerBorderColorUnchecked = System.Drawing.Color.Black;
            this.win8ToggleSwitch1.InnerBorderThickness = 1;
            this.win8ToggleSwitch1.IsChecked = false;
            this.win8ToggleSwitch1.Location = new System.Drawing.Point(40, 71);
            this.win8ToggleSwitch1.Name = "win8ToggleSwitch1";
            this.win8ToggleSwitch1.OuterBorderColor = System.Drawing.Color.LightGray;
            this.win8ToggleSwitch1.OuterBorderColorUnchecked = System.Drawing.Color.LightGray;
            this.win8ToggleSwitch1.OuterBorderThickness = 3;
            this.win8ToggleSwitch1.ShouldDrawFocusRectangleWhenFocused = false;
            this.win8ToggleSwitch1.ShouldDrawGapBetweenSwitchStickAndTrack = false;
            this.win8ToggleSwitch1.Size = new System.Drawing.Size(75, 23);
            this.win8ToggleSwitch1.SwitchStickControlGapWidth = 0;
            this.win8ToggleSwitch1.TabIndex = 0;
            this.win8ToggleSwitch1.Text = "win8ToggleSwitch1";
            this.win8ToggleSwitch1.ToggleStickColor = System.Drawing.Color.OrangeRed;
            this.win8ToggleSwitch1.ToggleStickColorUnchecked = System.Drawing.Color.OrangeRed;
            this.win8ToggleSwitch1.ToggleSwitchStickWidth = 13;
            this.win8ToggleSwitch1.MouseCaptureChanged += new System.EventHandler(this.TemporarySave);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(183, 485);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.win8ToggleSwitch4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.win8ToggleSwitch3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.win8ToggleSwitch2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.win8ToggleSwitch1);
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OptionsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Binarymission.WinForms.Controls.ToggleControls.Win8ToggleSwitch win8ToggleSwitch1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private Binarymission.WinForms.Controls.ToggleControls.Win8ToggleSwitch win8ToggleSwitch2;
        private System.Windows.Forms.Label label3;
        private Binarymission.WinForms.Controls.ToggleControls.Win8ToggleSwitch win8ToggleSwitch3;
        private System.Windows.Forms.Label label4;
        private Binarymission.WinForms.Controls.ToggleControls.Win8ToggleSwitch win8ToggleSwitch4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}