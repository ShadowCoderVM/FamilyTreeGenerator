using System;
using System.Windows.Forms;
namespace FamilyTreeGenerator
{
    public partial class TakeGenerateSettingsForm : Form
    {
        public TakeGenerateSettingsForm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }
        public uint Depth
        {
            set
            {
                numericUpDownDepth.Value = value;
            }
            get
            {
                return Convert.ToUInt32(numericUpDownDepth.Value);
            }
        }     
    }
}
