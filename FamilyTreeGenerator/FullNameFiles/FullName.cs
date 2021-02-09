using System.Collections.Generic;
using System.Windows.Forms;
using FamilyTreeGenerator.Dictionaries;
namespace FamilyTreeGenerator.FullNameFiles
{
    internal class FullName
    {
        public NameParts NamePart { private set; get; }
        public IdFullName IdFullName { private set; get; }

        public FullName(TreeNode node)
        {
            NamePart = new NameParts(node.Text, node.Name);
            IdFullName = new IdFullName(node.ImageKey);
        }
        public FullName(NameParts namePartS, IdFullName idFullName)
        {
            this.NamePart = namePartS;
            this.IdFullName = idFullName;
        }
        public FullName(NameParts namePartS)
        {
            this.NamePart = namePartS;
        }
        public FullName() { }

        public TreeNode GetNode()
        {
            TreeNode node = new TreeNode(NamePart.GetFullName());
            node.ImageKey = IdFullName.GetKeyId();
            node.Name = NamePart.GetGender().ToString("G");

            return node;
        }
        public void FindFullNameId(FullNameDictionaries dictionaries)
        {
            FindNamePartId(dictionaries.Males);
            FindNamePartId(dictionaries.Female);
        }

        private void FindNamePartId(GenderFullName genderFullname)
        {
            uint resultPathronicId = 0;
            uint resultSurnameId = 0;
            uint resultNameId = 0;

            bool isExistPathronic = FindId(genderFullname.Patronymic, NamePart.Pathronic, out resultPathronicId);
            bool isExistSurname = FindId(genderFullname.Surnames, NamePart.Surname, out resultSurnameId);
            bool isExistName = FindId(genderFullname.Names, NamePart.Name, out resultNameId);

            bool FullNameIsExist = isExistPathronic && isExistSurname && isExistName;

            if (FullNameIsExist)
            {
                IdFullName = new IdFullName(resultSurnameId, resultNameId, resultPathronicId);
            }
        }
        private bool FindId(List<string> namePart, string sourceNamePart, out uint id)
        {
            bool result = false;
            int resId = 0;

            resId = namePart.IndexOf(sourceNamePart);
            if (resId != -1) result = true;
            else result = false;

            id = (uint)resId;
            return result;
        }
    }
}
