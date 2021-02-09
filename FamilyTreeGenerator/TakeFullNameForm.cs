using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FamilyTreeGenerator.Dictionaries;
using FamilyTreeGenerator.GenderEnum;
using FamilyTreeGenerator.FullNameFiles;
namespace FamilyTreeGenerator
{
    public partial class TakeFullNameForm : Form
    {
        public TakeFullNameForm(FullNameDictionaries dictionaries)
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            this.dictionaries = dictionaries;
            ViewDictionaries();
        }
        private FullNameDictionaries dictionaries;
        private void ViewDictionaries()
        {
            Gender gender = SelectedGender();
            if (gender == Gender.Man)
            {
                LoadDictionary(dictionaries.Males);
            }
            else if (gender == Gender.Woman)
            {
                LoadDictionary(dictionaries.Female);
            }
        }
        private void LoadDictionary(GenderFullName genderFullName)
        {
            ClearComboBoxs();
            FillComboBox(comboBoxNames, genderFullName.Names);
            FillComboBox(comboBoxPatronymic, genderFullName.Patronymic);
            FillComboBox(comboBoxSurnames, genderFullName.Surnames);
        }
        private void ClearComboBoxs()
        {
            comboBoxNames.Items.Clear();
            comboBoxPatronymic.Items.Clear();
            comboBoxSurnames.Items.Clear();
        }
        private void FillComboBox(ComboBox comboBox, List<String> namePart)
        {
            foreach (String x in namePart)
            {
                comboBox.Items.Add(x);
            }
            if (comboBox.Items.Count > 0) comboBox.SelectedIndex = 0;
        }
        private Gender SelectedGender()
        {
            if (MaleRadioButton.Checked) return Gender.Man;
            else if (FemaleRadioButton.Checked) return Gender.Woman;
            throw new Exception("RadioButton don't checked");
        }
        public TreeNode Node
        {
            get
            {
                NameParts namePartS = new NameParts(
                    comboBoxSurnames.SelectedItem.ToString(),
                    comboBoxNames.SelectedItem.ToString(),
                    comboBoxPatronymic.SelectedItem.ToString(),
                    SelectedGender()
                    );

                IdFullName idFullName = new IdFullName(
                    (uint)comboBoxSurnames.SelectedIndex,
                    (uint)comboBoxNames.SelectedIndex,
                    (uint)comboBoxPatronymic.SelectedIndex
                    );

                FullName fullName = new FullName(namePartS,idFullName);
                return fullName.GetNode();
            }
            set
            {
                if (value != null)
                {
                    FullName fullName = new FullName(value);

                    NameParts namePartS = fullName.NamePart;
                    IdFullName idFullName = fullName.IdFullName;

                    if (namePartS.GetGender() == Gender.Man)
                        MaleRadioButton.Checked = true;
                    else if (namePartS.GetGender() == Gender.Woman)
                        FemaleRadioButton.Checked = true;

                    comboBoxSurnames.SelectedIndex = comboBoxSurnames.FindStringExact(namePartS.Surname);
                    comboBoxNames.SelectedIndex = comboBoxNames.FindStringExact(namePartS.Name);
                    comboBoxPatronymic.SelectedIndex = comboBoxPatronymic.FindStringExact(namePartS.Pathronic);
                }
            }
        }
        private void Button_CheckedChanged(object sender, EventArgs e)
        {
            ViewDictionaries();
        }
    }
}
