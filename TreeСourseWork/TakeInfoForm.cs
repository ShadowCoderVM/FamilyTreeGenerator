using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeСourseWork
{
    public partial class TakeInfoForm : Form
    {
        public TakeInfoForm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }
        public string TextValue
        {
            get
            {
                return TextBoxText.Text;
            }
            set { TextBoxText.Text = value; }
        }
    }
}
