namespace MarkdownViewer
{
    partial class FormBaseFolder
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
            this.txtBaseFolder = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.butUseFolder = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStartFile = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please specify the base folder";
            // 
            // txtBaseFolder
            // 
            this.txtBaseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaseFolder.Location = new System.Drawing.Point(15, 25);
            this.txtBaseFolder.Name = "txtBaseFolder";
            this.txtBaseFolder.ReadOnly = true;
            this.txtBaseFolder.Size = new System.Drawing.Size(553, 20);
            this.txtBaseFolder.TabIndex = 1;
            // 
            // butBrowse
            // 
            this.butBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBrowse.Location = new System.Drawing.Point(574, 23);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(75, 23);
            this.butBrowse.TabIndex = 2;
            this.butBrowse.Text = "Browse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // butUseFolder
            // 
            this.butUseFolder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butUseFolder.Location = new System.Drawing.Point(224, 113);
            this.butUseFolder.Name = "butUseFolder";
            this.butUseFolder.Size = new System.Drawing.Size(75, 23);
            this.butUseFolder.TabIndex = 3;
            this.butUseFolder.Text = "Use Folder";
            this.butUseFolder.UseVisualStyleBackColor = true;
            this.butUseFolder.Click += new System.EventHandler(this.butUseFolder_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(357, 113);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please specify the start file";
            // 
            // cmbStartFile
            // 
            this.cmbStartFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStartFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartFile.FormattingEnabled = true;
            this.cmbStartFile.Location = new System.Drawing.Point(15, 79);
            this.cmbStartFile.Name = "cmbStartFile";
            this.cmbStartFile.Size = new System.Drawing.Size(634, 21);
            this.cmbStartFile.TabIndex = 6;
            // 
            // FormBaseFolder
            // 
            this.AcceptButton = this.butUseFolder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(661, 148);
            this.Controls.Add(this.cmbStartFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butUseFolder);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.txtBaseFolder);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(99999, 187);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(313, 187);
            this.Name = "FormBaseFolder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Base Folder";
            this.Load += new System.EventHandler(this.FormBaseFolder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBaseFolder;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.Button butUseFolder;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStartFile;
    }
}