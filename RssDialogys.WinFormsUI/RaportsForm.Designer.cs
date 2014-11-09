namespace RssDialogys.WinFormsUI
{
    partial class RaportsForm
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
            this.raportsDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.raportsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // raportsDGV
            // 
            this.raportsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.raportsDGV.Location = new System.Drawing.Point(12, 12);
            this.raportsDGV.Name = "raportsDGV";
            this.raportsDGV.Size = new System.Drawing.Size(805, 589);
            this.raportsDGV.TabIndex = 0;
            this.raportsDGV.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.raportsDGV_CellFormatting);
            // 
            // RaportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 607);
            this.Controls.Add(this.raportsDGV);
            this.Name = "RaportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaportsForm";
            ((System.ComponentModel.ISupportInitialize)(this.raportsDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView raportsDGV;
    }
}