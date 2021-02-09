using System;
using System.Windows.Forms;
namespace FamilyTreeGenerator
{
    public partial class TakeDictionariesPaths : Form
    {
        public TakeDictionariesPaths()
        {
            InitializeComponent();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "табличные файлы  (*.csv)|*.csv|Все файлы (*.*)|*.*";
            buttonCansel.DialogResult = DialogResult.Cancel;
            filePaths = new FilePaths();
        }
        private FilePaths filePaths;
        public FilePaths FilePaths
        {
            get {
                return filePaths;
            }
            set{
                filePaths = value;
                ViewFilePaths();
            }  
        }
        private void ViewFilePaths()
        {
            textBoxMaleNamesAndPathronic.Text = filePaths.MaleNamesAndPathronic;
            textBoxFemaleNames.Text = filePaths.FemaleNames;
            textBoxSurname.Text = filePaths.Surnames;
        }
        private void TakeFileMaleNamesAndPathronic(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePaths.MaleNamesAndPathronic = openFileDialog.FileName;
                textBoxMaleNamesAndPathronic.Text = openFileDialog.FileName;
            }
        }
        private void TakeFileFemalеNames(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePaths.FemaleNames = openFileDialog.FileName;
                textBoxFemaleNames.Text = openFileDialog.FileName;
            }
        }
        private void TakeFileSurname(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePaths.Surnames = openFileDialog.FileName;
                textBoxSurname.Text = openFileDialog.FileName;
            }
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (filePaths.MaleNamesAndPathronic != null | filePaths.FemaleNames != null | filePaths.Surnames != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
