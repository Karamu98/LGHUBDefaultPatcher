namespace DefaultPatcher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.appList = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.browseDataPath = new System.Windows.Forms.Button();
            this.dataPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.processButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rootNameDisplay = new System.Windows.Forms.Label();
            this.invertSelectBtn = new System.Windows.Forms.Button();
            this.unselectAllBtn = new System.Windows.Forms.Button();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1048, 66);
            this.label2.TabIndex = 0;
            this.label2.Text = "Applications";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.appList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 681);
            this.panel1.TabIndex = 0;
            // 
            // appList
            // 
            this.appList.AutoScroll = true;
            this.appList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appList.Location = new System.Drawing.Point(0, 66);
            this.appList.Name = "appList";
            this.appList.Size = new System.Drawing.Size(1048, 615);
            this.appList.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(216, 66);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.browseDataPath);
            this.panel4.Controls.Add(this.dataPath);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(216, 63);
            this.panel4.TabIndex = 3;
            // 
            // browseDataPath
            // 
            this.browseDataPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.browseDataPath.Location = new System.Drawing.Point(0, 40);
            this.browseDataPath.Name = "browseDataPath";
            this.browseDataPath.Size = new System.Drawing.Size(216, 23);
            this.browseDataPath.TabIndex = 2;
            this.browseDataPath.Text = "Browse";
            this.browseDataPath.UseVisualStyleBackColor = true;
            this.browseDataPath.Click += new System.EventHandler(this.browseDataPath_Click);
            // 
            // dataPath
            // 
            this.dataPath.AllowDrop = true;
            this.dataPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPath.Location = new System.Drawing.Point(0, 15);
            this.dataPath.Name = "dataPath";
            this.dataPath.Size = new System.Drawing.Size(216, 23);
            this.dataPath.TabIndex = 1;
            this.dataPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataPath_KeyDown);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Path:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // processButton
            // 
            this.processButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.processButton.Location = new System.Drawing.Point(0, 638);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(216, 43);
            this.processButton.TabIndex = 4;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.processButton);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1048, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 681);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rootNameDisplay);
            this.panel5.Controls.Add(this.invertSelectBtn);
            this.panel5.Controls.Add(this.unselectAllBtn);
            this.panel5.Controls.Add(this.selectAllBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 464);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(216, 174);
            this.panel5.TabIndex = 5;
            // 
            // rootNameDisplay
            // 
            this.rootNameDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootNameDisplay.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rootNameDisplay.ForeColor = System.Drawing.SystemColors.Control;
            this.rootNameDisplay.Location = new System.Drawing.Point(0, 90);
            this.rootNameDisplay.Name = "rootNameDisplay";
            this.rootNameDisplay.Size = new System.Drawing.Size(216, 84);
            this.rootNameDisplay.TabIndex = 5;
            this.rootNameDisplay.Text = "Current Root: \r\nDESKTOP";
            // 
            // invertSelectBtn
            // 
            this.invertSelectBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.invertSelectBtn.Location = new System.Drawing.Point(0, 60);
            this.invertSelectBtn.Name = "invertSelectBtn";
            this.invertSelectBtn.Size = new System.Drawing.Size(216, 30);
            this.invertSelectBtn.TabIndex = 4;
            this.invertSelectBtn.Text = "Invert Selection";
            this.invertSelectBtn.UseVisualStyleBackColor = true;
            this.invertSelectBtn.Click += new System.EventHandler(this.invertSelectBtn_Click);
            // 
            // unselectAllBtn
            // 
            this.unselectAllBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.unselectAllBtn.Location = new System.Drawing.Point(0, 30);
            this.unselectAllBtn.Name = "unselectAllBtn";
            this.unselectAllBtn.Size = new System.Drawing.Size(216, 30);
            this.unselectAllBtn.TabIndex = 3;
            this.unselectAllBtn.Text = "Unselect All";
            this.unselectAllBtn.UseVisualStyleBackColor = true;
            this.unselectAllBtn.Click += new System.EventHandler(this.unselectAllBtn_Click);
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectAllBtn.Location = new System.Drawing.Point(0, 0);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(216, 30);
            this.selectAllBtn.TabIndex = 2;
            this.selectAllBtn.Text = "Select All";
            this.selectAllBtn.UseVisualStyleBackColor = true;
            this.selectAllBtn.Click += new System.EventHandler(this.selectAllBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private Label label2;
        private Panel panel1;
        private Panel appList;
        private Panel panel3;
        private Panel panel4;
        private Button browseDataPath;
        private TextBox dataPath;
        private Label label1;
        private Button processButton;
        private Panel panel2;
        private Panel panel5;
        private Label rootNameDisplay;
        private Button invertSelectBtn;
        private Button unselectAllBtn;
        private Button selectAllBtn;
    }
}