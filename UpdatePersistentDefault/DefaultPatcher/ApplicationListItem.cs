using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DefaultPatcher
{
    public partial class ApplicationListItem : UserControl
    {
        public bool OverWrite { get; private set; }
        public LGHUB.Profile Profile { get; private set; }
        public string AppName { get; private set; }
        private Action<ApplicationListItem> m_onRootSelectedCall;


        public ApplicationListItem()
        {
            InitializeComponent();
        }

        public void Init(string imagePath, string appName, bool overwrite, Action<ApplicationListItem> onRootSelected, LGHUB.Profile profile)
        {
            SetAppName(appName);
            SetImage(imagePath);
            SetOverWrite(overwrite);
            m_onRootSelectedCall = onRootSelected;
            Profile = profile;
        }

        public void SetRoot(bool isRoot)
        {
            rootProfile.Checked = isRoot;
            appOverwrite.Enabled = !isRoot;
        }

        private void appImage_Click(object sender, EventArgs e)
        {
            SetOverWrite(!appOverwrite.Checked);
        }

        private void appName_Click(object sender, EventArgs e)
        {
            SetOverWrite(!appOverwrite.Checked);
        }

        private void appOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            OverWrite = appOverwrite.Checked;
        }

        private void SetImage(string path)
        {
            appImage.ImageLocation = path;
        }

        private void SetAppName(string name)
        {
            AppName = name;
            appName.Text = name;
        }

        public void SetOverWrite(bool overwrite)
        {
            OverWrite = overwrite;
            appOverwrite.Checked = overwrite;
        }

        private void rootProfile_CheckedChanged(object sender, EventArgs e)
        {
            if(rootProfile.Checked)
            {
                m_onRootSelectedCall?.Invoke(this);
            }
        }
    }
}
