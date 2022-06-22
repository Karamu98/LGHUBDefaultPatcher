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
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.invertAppBtn = new System.Windows.Forms.Button();
            this.unselectAppsBtn = new System.Windows.Forms.Button();
            this.selectAllAppsBtn = new System.Windows.Forms.Button();
            this.appList = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.browseDataPath = new System.Windows.Forms.Button();
            this.dataPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.processButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.attributeList = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rootNameDisplay = new System.Windows.Forms.Label();
            this.invertSelectAttsBtn = new System.Windows.Forms.Button();
            this.unselectAllAttsBtn = new System.Windows.Forms.Button();
            this.selectAllAttsBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromLoadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.injectJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.injectLoadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.injectOtherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(995, 71);
            this.label2.TabIndex = 0;
            this.label2.Text = "Applications";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.appList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 657);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(995, 71);
            this.panel6.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.invertAppBtn);
            this.panel7.Controls.Add(this.unselectAppsBtn);
            this.panel7.Controls.Add(this.selectAllAppsBtn);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(128, 71);
            this.panel7.TabIndex = 1;
            // 
            // invertAppBtn
            // 
            this.invertAppBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.invertAppBtn.Location = new System.Drawing.Point(0, 46);
            this.invertAppBtn.Name = "invertAppBtn";
            this.invertAppBtn.Size = new System.Drawing.Size(128, 23);
            this.invertAppBtn.TabIndex = 2;
            this.invertAppBtn.Text = "Invert App Selection";
            this.invertAppBtn.UseVisualStyleBackColor = true;
            this.invertAppBtn.Click += new System.EventHandler(this.invertAppBtn_Click);
            // 
            // unselectAppsBtn
            // 
            this.unselectAppsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.unselectAppsBtn.Location = new System.Drawing.Point(0, 23);
            this.unselectAppsBtn.Name = "unselectAppsBtn";
            this.unselectAppsBtn.Size = new System.Drawing.Size(128, 23);
            this.unselectAppsBtn.TabIndex = 1;
            this.unselectAppsBtn.Text = "Unselect All Apps";
            this.unselectAppsBtn.UseVisualStyleBackColor = true;
            this.unselectAppsBtn.Click += new System.EventHandler(this.unselectAppsBtn_Click);
            // 
            // selectAllAppsBtn
            // 
            this.selectAllAppsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectAllAppsBtn.Location = new System.Drawing.Point(0, 0);
            this.selectAllAppsBtn.Name = "selectAllAppsBtn";
            this.selectAllAppsBtn.Size = new System.Drawing.Size(128, 23);
            this.selectAllAppsBtn.TabIndex = 0;
            this.selectAllAppsBtn.Text = "Select All Apps";
            this.selectAllAppsBtn.UseVisualStyleBackColor = true;
            this.selectAllAppsBtn.Click += new System.EventHandler(this.selectAllAppsBtn_Click);
            // 
            // appList
            // 
            this.appList.AutoScroll = true;
            this.appList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appList.Location = new System.Drawing.Point(0, 0);
            this.appList.Name = "appList";
            this.appList.Size = new System.Drawing.Size(995, 657);
            this.appList.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.browseDataPath);
            this.panel4.Controls.Add(this.dataPath);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(269, 63);
            this.panel4.TabIndex = 3;
            // 
            // browseDataPath
            // 
            this.browseDataPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.browseDataPath.Location = new System.Drawing.Point(0, 40);
            this.browseDataPath.Name = "browseDataPath";
            this.browseDataPath.Size = new System.Drawing.Size(269, 23);
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
            this.dataPath.Size = new System.Drawing.Size(269, 23);
            this.dataPath.TabIndex = 1;
            this.dataPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataPath_KeyDown);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Path:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // processButton
            // 
            this.processButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.processButton.Location = new System.Drawing.Point(0, 614);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(269, 43);
            this.processButton.TabIndex = 4;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.attributeList);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.processButton);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(995, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 657);
            this.panel2.TabIndex = 1;
            // 
            // attributeList
            // 
            this.attributeList.AutoScroll = true;
            this.attributeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributeList.Location = new System.Drawing.Point(0, 97);
            this.attributeList.Name = "attributeList";
            this.attributeList.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.attributeList.Size = new System.Drawing.Size(269, 343);
            this.attributeList.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 34);
            this.panel3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 34);
            this.label3.TabIndex = 0;
            this.label3.Text = "Attributes";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rootNameDisplay);
            this.panel5.Controls.Add(this.invertSelectAttsBtn);
            this.panel5.Controls.Add(this.unselectAllAttsBtn);
            this.panel5.Controls.Add(this.selectAllAttsBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 440);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(269, 174);
            this.panel5.TabIndex = 5;
            // 
            // rootNameDisplay
            // 
            this.rootNameDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootNameDisplay.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rootNameDisplay.ForeColor = System.Drawing.SystemColors.Control;
            this.rootNameDisplay.Location = new System.Drawing.Point(0, 90);
            this.rootNameDisplay.Name = "rootNameDisplay";
            this.rootNameDisplay.Size = new System.Drawing.Size(269, 84);
            this.rootNameDisplay.TabIndex = 5;
            this.rootNameDisplay.Text = "Current Root: \r\nDESKTOP";
            // 
            // invertSelectAttsBtn
            // 
            this.invertSelectAttsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.invertSelectAttsBtn.Location = new System.Drawing.Point(0, 60);
            this.invertSelectAttsBtn.Name = "invertSelectAttsBtn";
            this.invertSelectAttsBtn.Size = new System.Drawing.Size(269, 30);
            this.invertSelectAttsBtn.TabIndex = 4;
            this.invertSelectAttsBtn.Text = "Invert Attribute Selection";
            this.invertSelectAttsBtn.UseVisualStyleBackColor = true;
            this.invertSelectAttsBtn.Click += new System.EventHandler(this.invertSelectAttributesBtn_Click);
            // 
            // unselectAllAttsBtn
            // 
            this.unselectAllAttsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.unselectAllAttsBtn.Location = new System.Drawing.Point(0, 30);
            this.unselectAllAttsBtn.Name = "unselectAllAttsBtn";
            this.unselectAllAttsBtn.Size = new System.Drawing.Size(269, 30);
            this.unselectAllAttsBtn.TabIndex = 3;
            this.unselectAllAttsBtn.Text = "Unselect All Attributes";
            this.unselectAllAttsBtn.UseVisualStyleBackColor = true;
            this.unselectAllAttsBtn.Click += new System.EventHandler(this.unselectAllAttributesBtn_Click);
            // 
            // selectAllAttsBtn
            // 
            this.selectAllAttsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectAllAttsBtn.Location = new System.Drawing.Point(0, 0);
            this.selectAllAttsBtn.Name = "selectAllAttsBtn";
            this.selectAllAttsBtn.Size = new System.Drawing.Size(269, 30);
            this.selectAllAttsBtn.TabIndex = 2;
            this.selectAllAttsBtn.Text = "Select All Attributes";
            this.selectAllAttsBtn.UseVisualStyleBackColor = true;
            this.selectAllAttsBtn.Click += new System.EventHandler(this.selectAllAttributesBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractJSONToolStripMenuItem,
            this.injectJSONToolStripMenuItem,
            this.backupSettingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // extractJSONToolStripMenuItem
            // 
            this.extractJSONToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromLoadedToolStripMenuItem,
            this.fromFileToolStripMenuItem});
            this.extractJSONToolStripMenuItem.Name = "extractJSONToolStripMenuItem";
            this.extractJSONToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.extractJSONToolStripMenuItem.Text = "Extract JSON";
            // 
            // fromLoadedToolStripMenuItem
            // 
            this.fromLoadedToolStripMenuItem.Name = "fromLoadedToolStripMenuItem";
            this.fromLoadedToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.fromLoadedToolStripMenuItem.Text = "From Loaded";
            this.fromLoadedToolStripMenuItem.Click += new System.EventHandler(this.fromLoadedToolStripMenuItem_Click);
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.fromFileToolStripMenuItem.Text = "From File";
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.fromFileToolStripMenuItem_Click);
            // 
            // injectJSONToolStripMenuItem
            // 
            this.injectJSONToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.injectLoadedToolStripMenuItem,
            this.injectOtherToolStripMenuItem});
            this.injectJSONToolStripMenuItem.Name = "injectJSONToolStripMenuItem";
            this.injectJSONToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.injectJSONToolStripMenuItem.Text = "Inject JSON";
            // 
            // injectLoadedToolStripMenuItem
            // 
            this.injectLoadedToolStripMenuItem.Name = "injectLoadedToolStripMenuItem";
            this.injectLoadedToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.injectLoadedToolStripMenuItem.Text = "Inject Loaded";
            // 
            // injectOtherToolStripMenuItem
            // 
            this.injectOtherToolStripMenuItem.Name = "injectOtherToolStripMenuItem";
            this.injectOtherToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.injectOtherToolStripMenuItem.Text = "Inject Other";
            // 
            // backupSettingsToolStripMenuItem
            // 
            this.backupSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.backupSettingsToolStripMenuItem.Name = "backupSettingsToolStripMenuItem";
            this.backupSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.backupSettingsToolStripMenuItem.Text = "Backup";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private Label label2;
        private Panel panel1;
        private Panel appList;
        private Panel panel4;
        private Button browseDataPath;
        private TextBox dataPath;
        private Label label1;
        private Button processButton;
        private Panel panel2;
        private Panel panel5;
        private Label rootNameDisplay;
        private Button invertSelectAttsBtn;
        private Button unselectAllAttsBtn;
        private Button selectAllAttsBtn;
        private Panel attributeList;
        private Panel panel3;
        private Label label3;
        private Panel panel6;
        private Panel panel7;
        private Button invertAppBtn;
        private Button unselectAppsBtn;
        private Button selectAllAppsBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem extractJSONToolStripMenuItem;
        private ToolStripMenuItem injectJSONToolStripMenuItem;
        private ToolStripMenuItem backupSettingsToolStripMenuItem;
        private ToolStripMenuItem fromLoadedToolStripMenuItem;
        private ToolStripMenuItem fromFileToolStripMenuItem;
        private ToolStripMenuItem injectLoadedToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem injectOtherToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
    }
}