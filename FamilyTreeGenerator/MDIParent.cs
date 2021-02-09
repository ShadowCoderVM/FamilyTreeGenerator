using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FamilyTreeGenerator.TreeGeneratorFiles;
using FamilyTreeGenerator.Dictionaries;
namespace FamilyTreeGenerator
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;
        private uint maxDepth = 3;
        private string path;
        private FilePaths filePaths;
        private ParseSettings parseSettings;
        private FullNameDictionaries dictionaries;
        public MDIParent()
        {
            InitializeComponent();
            parseSettings = new ParseSettings
            {
                MaleNames = new ParseTableSettings(0, 3),
                MalePathronic = new ParseTableSettings(1, 3),
                FemalePathronic = new ParseTableSettings(2, 3),
                FemaleNames = new ParseTableSettings(0, 1),
                MaleSurnames = new ParseTableSettings(0, 2),
                FemaleSurnames = new ParseTableSettings(1, 2)
            };
            CheckDefaultDictionaries();
        }
        private void ShowNewForm_Click(object sender, EventArgs e)
        {
            TreeForm childForm = new TreeForm();
            childForm.MdiParent = this;
            childForm.Text = "Окно " + childFormNumber++;
            childForm.Show();
        }
        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Бинарные файлы (*.bin)|*.bin|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowNewForm_Click(sender, e);
                TreeForm ChildForm = (TreeForm)ActiveMdiChild;
                path = openFileDialog.FileName;
                ChildForm.LoadTree(path);
                ChildForm.Text = path;
            }
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path != null)
            {
                SaveTreeForm();
            }
            else
            {
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
        private void AddRootElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
            if (filePaths == null)
            {
                ChangeDictionariesPathsToolStripMenu_Click(sender, e);
            }
            if (filePaths != null && dictionaries.CheckFillingDictionary())
            {
                TakeFullNameForm TIF = new TakeFullNameForm( dictionaries);
                TIF.Text = "Добавление корневого элемента";
                if (TIF.ShowDialog() == DialogResult.OK)
                {
                    TreeForm ChildForm = (TreeForm)ActiveMdiChild;
                    ChildForm.AddRootElement(TIF.Node);
                }
            }
        }
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
            if (filePaths == null)
            {
                ChangeDictionariesPathsToolStripMenu_Click(sender, e);
            }
            if (filePaths != null && dictionaries.CheckFillingDictionary())
            {
                TakeFullNameForm TIF = new TakeFullNameForm(dictionaries);
                TIF.Text = "Добавление элемента";
                if (TIF.ShowDialog() == DialogResult.OK)
                {
                    TreeForm ChildForm = (TreeForm)ActiveMdiChild;
                    ChildForm.AddElement(TIF.Node);
                }
            }
        }
        private void DeleteElementToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
            TreeForm ChildForm = (TreeForm)ActiveMdiChild;
            ChildForm.DeleteElement();
        }
        private void RenameElementToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
            TreeForm ChildForm = (TreeForm)ActiveMdiChild;
            
            if (dictionaries.CheckFillingDictionary())
            {
                ChildForm.RenameElement(dictionaries);
            }
        }
        private void LoadDictionaries()
        {
            if (parseSettings == null) return;
            dictionaries = new FullNameDictionaries();
            dictionaries.LoadDictionaries(filePaths, parseSettings);
        }
        private void GenerateFamilyTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
            TakeDictionariesPaths TD = new TakeDictionariesPaths();
            if (dictionaries == null 
                && dictionaries.CheckFillingDictionary()
                && TD.ShowDialog() == DialogResult.OK)
            {
                filePaths = TD.FilePaths;
            }
            TreeForm ChildForm = (TreeForm)ActiveMdiChild;
            ChildForm.GenerateTree(dictionaries, maxDepth);
        }
        private void ChangeDictionariesPathsToolStripMenu_Click(object sender, EventArgs e)
        {
            TakeDictionariesPaths TD = new TakeDictionariesPaths();
            if (filePaths != null)
            {
                TD.FilePaths = filePaths;
            }
            if (TD.ShowDialog() == DialogResult.OK)
            {
                filePaths = TD.FilePaths;
                LoadDictionaries();
            }
        }
        private void CheckDefaultDictionaries()
        {
            DirectoryInfo directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            directory = directory.Parent;
            directory = directory.Parent;
            string pathDirectory = directory.FullName + "\\resources";
            string[] NamesFile = GetDefaultNameFiles(pathDirectory);
            if (NamesFile.Length >= 3 &&
                CheckFile(pathDirectory, NamesFile[0])
                & CheckFile(pathDirectory, NamesFile[1])
                & CheckFile(pathDirectory, NamesFile[2]))
            {
                filePaths = new FilePaths
                {
                    MaleNamesAndPathronic = pathDirectory + "\\" + NamesFile[0],
                    FemaleNames = pathDirectory + "\\" + NamesFile[1],
                    Surnames = pathDirectory + "\\" + NamesFile[2]
                };
                LoadDictionaries();

            }
        }
        private string[] GetDefaultNameFiles(string path)
        {
            path = path + "\\DefaultFileName.txt";
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                string text;
                using (StreamReader sw = new StreamReader(path, Encoding.Default))
                {
                    text = sw.ReadToEnd();
                }
                text = text.Replace("\r\n", "'");
                return text.Split('\'');
            }
            return null;
        }
        private bool CheckFile(string path, string nameFile)
        {
            FileInfo fileInfo = new FileInfo(path +
                "\\" + nameFile);
            return fileInfo.Exists;
        }
        private void GenerateSettingsToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            TakeGenerateSettingsForm TGSF = new TakeGenerateSettingsForm();
            if (TGSF.ShowDialog() == DialogResult.OK)
            {
                maxDepth = TGSF.Depth;
            }
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Программа для работы с фамильными деревьями Семина С.К",
                "О программе"
                );
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
            ChildForm.InsertSavedElement();
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
    }
}
