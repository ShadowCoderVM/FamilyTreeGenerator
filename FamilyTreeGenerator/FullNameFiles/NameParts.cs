using FamilyTreeGenerator.GenderEnum;
using System;
namespace FamilyTreeGenerator.FullNameFiles
{
    class NameParts
    {
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Pathronic { get; private set; }
        private Gender gender;

        public NameParts(string family, string name, string pathronic, string gender)
        {
            this.Surname = family;
            this.Name = name;
            this.Pathronic = pathronic;
            if (gender == "Man") this.gender = Gender.Man;
            else if (gender == "Woman") this.gender = Gender.Woman;
        }
        public NameParts(string family, string name, string pathronic, Gender gender)
        {
            this.Surname = family;
            this.Name = name;
            this.Pathronic = pathronic;
            this.gender = gender;
        }
        public NameParts(string fullName, string gender)
        {
            String[] NamePart = fullName.Split(' ');
            Surname = NamePart[0];
            Name = NamePart[1];
            Pathronic = NamePart[2];

            if (gender.Equals("Man", StringComparison.OrdinalIgnoreCase))
                this.gender = Gender.Man;
            else
                if (gender.Equals("Woman", StringComparison.OrdinalIgnoreCase))
                    this.gender = Gender.Woman;
        }
        public NameParts(string fullName, Gender gender)
        {
            String[] NamePart = fullName.Split(' ');
            Surname = NamePart[0];
            Name = NamePart[1];
            Pathronic = NamePart[2];
            this.gender = gender;
        }
        public NameParts() { }
        public Gender GetGender()
        {
            return gender;
        }
        public string GetFullName()
        {
            return Surname + " " + Name + " " + Pathronic;
        }
    }
}
