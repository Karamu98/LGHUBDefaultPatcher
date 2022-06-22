namespace DefaultPatcher
{
    partial class ApplicationListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationListItem));
            this.appImage = new System.Windows.Forms.PictureBox();
            this.appName = new System.Windows.Forms.Label();
            this.appOverwrite = new System.Windows.Forms.CheckBox();
            this.rootProfile = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.appImage)).BeginInit();
            this.SuspendLayout();
            // 
            // appImage
            // 
            this.appImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.appImage.Image = ((System.Drawing.Image)(resources.GetObject("appImage.Image")));
            this.appImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("appImage.InitialImage")));
            this.appImage.Location = new System.Drawing.Point(0, 0);
            this.appImage.Name = "appImage";
            this.appImage.Size = new System.Drawing.Size(64, 64);
            this.appImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.appImage.TabIndex = 0;
            this.appImage.TabStop = false;
            this.appImage.Click += new System.EventHandler(this.appImage_Click);
            // 
            // appName
            // 
            this.appName.Dock = System.Windows.Forms.DockStyle.Left;
            this.appName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.appName.Location = new System.Drawing.Point(64, 0);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(386, 64);
            this.appName.TabIndex = 1;
            this.appName.Text = "AppName";
            this.appName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.appName.Click += new System.EventHandler(this.appName_Click);
            // 
            // appOverwrite
            // 
            this.appOverwrite.Dock = System.Windows.Forms.DockStyle.Right;
            this.appOverwrite.Location = new System.Drawing.Point(543, 0);
            this.appOverwrite.Name = "appOverwrite";
            this.appOverwrite.Size = new System.Drawing.Size(82, 64);
            this.appOverwrite.TabIndex = 2;
            this.appOverwrite.Text = "Overwrite";
            this.appOverwrite.UseVisualStyleBackColor = true;
            this.appOverwrite.CheckedChanged += new System.EventHandler(this.appOverwrite_CheckedChanged);
            // 
            // rootProfile
            // 
            this.rootProfile.AutoSize = true;
            this.rootProfile.Dock = System.Windows.Forms.DockStyle.Right;
            this.rootProfile.Location = new System.Drawing.Point(456, 0);
            this.rootProfile.Name = "rootProfile";
            this.rootProfile.Size = new System.Drawing.Size(87, 64);
            this.rootProfile.TabIndex = 3;
            this.rootProfile.TabStop = true;
            this.rootProfile.Text = "Root Profile";
            this.rootProfile.UseVisualStyleBackColor = true;
            this.rootProfile.CheckedChanged += new System.EventHandler(this.rootProfile_CheckedChanged);
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rootProfile);
            this.Controls.Add(this.appOverwrite);
            this.Controls.Add(this.appName);
            this.Controls.Add(this.appImage);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(625, 64);
            ((System.ComponentModel.ISupportInitialize)(this.appImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox appImage;
        private Label appName;
        private CheckBox appOverwrite;
        private RadioButton rootProfile;
    }
}
