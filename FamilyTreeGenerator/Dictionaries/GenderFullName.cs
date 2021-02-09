using System.Collections.Generic;
using FamilyTreeGenerator.GenderEnum;
namespace FamilyTreeGenerator.Dictionaries
{
    public class GenderFullName
    {
        public List<string> Names;
        public List<string> Surnames;
        public List<string> Patronymic;
        public Gender gender;
        public GenderFullName(Gender gender)
        {
            Names = new List<string>();
            Surnames = new List<string>();
            Patronymic = new List<string>();
            this.gender = gender;
        }
        public void Clear()
        {
            Names.Clear();
            Surnames.Clear();
            Patronymic.Clear();
        }
    }
}
