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
    public partial class AttributeToggleListItem : UserControl
    {
        public string AttributeName { get; private set; }
        public bool Checked { get { return checkBox1.Checked; } }

        public AttributeToggleListItem()
        {
            InitializeComponent();
        }

        public void Init(string attributeName)
        {
            checkBox1.Text = attributeName;
            AttributeName = attributeName;

            checkBox1.Checked = true;
        }

        public void SetChecked(bool isChecked)
        {
            checkBox1.Checked = isChecked;
        }
    }
}
