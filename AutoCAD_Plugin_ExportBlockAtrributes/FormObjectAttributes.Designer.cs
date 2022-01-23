namespace AutoCAD_Plugin_ExportBlockAtrributes
{
    partial class FormObjectAttributes
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
            this.buttonExportToExcel = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxBlockProperties = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonExportToExcel
            // 
            this.buttonExportToExcel.Location = new System.Drawing.Point(26, 203);
            this.buttonExportToExcel.Name = "buttonExportToExcel";
            this.buttonExportToExcel.Size = new System.Drawing.Size(106, 23);
            this.buttonExportToExcel.TabIndex = 0;
            this.buttonExportToExcel.Text = "Export To Excel";
            this.buttonExportToExcel.UseVisualStyleBackColor = true;
            this.buttonExportToExcel.Click += new System.EventHandler(this.ButtonExportToExcel_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(162, 203);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(97, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // textBoxBlockProperties
            // 
            this.textBoxBlockProperties.Location = new System.Drawing.Point(26, 34);
            this.textBoxBlockProperties.Multiline = true;
            this.textBoxBlockProperties.Name = "textBoxBlockProperties";
            this.textBoxBlockProperties.Size = new System.Drawing.Size(233, 163);
            this.textBoxBlockProperties.TabIndex = 2;
            // 
            // FormObjectAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 251);
            this.Controls.Add(this.textBoxBlockProperties);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonExportToExcel);
            this.Name = "FormObjectAttributes";
            this.Text = "FormObjectAttributes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExportToExcel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxBlockProperties;
    }
}