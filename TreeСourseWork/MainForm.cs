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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateNewForm(object sender, EventArgs e)
        {
            TreeForm ChildForm = new TreeForm();
            ChildForm.MdiParent = this;
            ChildForm.Text = "Новое окно";
            ChildForm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;

            TreeForm ChildForm = (TreeForm) ActiveMdiChild;
            ChildForm.AddRootElement("gg");
        }
    }
}
