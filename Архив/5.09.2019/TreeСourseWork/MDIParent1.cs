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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        
        string path;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm_Click(object sender, EventArgs e)
        {
            ShowNewForm();
        }
        private void ShowNewForm()
        {
            TreeForm childForm = new TreeForm();
            childForm.MdiParent = this;
            childForm.Text = "Окно " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Бинарные файлы (*.bin)|*.bin|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowNewForm();   
                TreeForm ChildForm = (TreeForm)ActiveMdiChild;
                path = openFileDialog.FileName;

                ChildForm.LoadTree(path);
                ChildForm.Text = path;
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path != null)
            {
                SaveTreeForm();
            }
            else {
                SaveAsToolStripMenuItem_Click(sender, e);
            }
        }
        
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Бинарные файлы (*.bin)|*.bin|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                SaveTreeForm();
            }
        }
        
        private void SaveTreeForm()
        {
            TreeForm ChildForm = (TreeForm)ActiveMdiChild;
            ChildForm.SaveTree(path);
            ChildForm.Text = path;
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;

            TreeForm ChildForm = (TreeForm)ActiveMdiChild;
            ChildForm.SaveElement();
            ChildForm.DeleteElement();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
            TreeForm ChildForm = (TreeForm)ActiveMdiChild;
            ChildForm.SaveElement();
           
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;

            TreeForm ChildForm = (TreeForm)ActiveMdiChild;
            ChildForm.InsertElement();
        }

        private void PasteRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;

            TreeForm ChildForm = (TreeForm)ActiveMdiChild;
            ChildForm.InsertRootElement();
        }


        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;

            TakeInfoForm TIF = new TakeInfoForm();
            if (TIF.ShowDialog() == DialogResult.OK)
            {              
                TreeForm ChildForm = (TreeForm)ActiveMdiChild;
                ChildForm.AddRootElement(TIF.TextValue);
            }
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;

            TakeInfoForm TIF = new TakeInfoForm();
            if (TIF.ShowDialog() == DialogResult.OK)
            { 
                TreeForm ChildForm = (TreeForm)ActiveMdiChild;
                ChildForm.AddElement(TIF.TextValue);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;

            TreeForm ChildForm = (TreeForm)ActiveMdiChild;
            ChildForm.DeleteElement();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
            TakeInfoForm TIF = new TakeInfoForm();
            if (TIF.ShowDialog() == DialogResult.OK)
            {
                TreeForm ChildForm = (TreeForm)ActiveMdiChild;
                ChildForm.RenameElement(TIF.TextValue);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Программа для работы с древовидными структурами Семина С.К",
                "О программе"
                );
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
        }

        private void генераторToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
