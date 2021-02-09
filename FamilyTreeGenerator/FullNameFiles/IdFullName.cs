using System;

namespace FamilyTreeGenerator.FullNameFiles
{
    class IdFullName
    {
        public uint IdSurname { private set; get; }
        public uint IdName { private set; get; }
        public uint IdPathronic { private set; get; }
        public IdFullName(uint idSurname, uint idName, uint idPathronic)
        {
            IdName = idName;
            IdPathronic = idPathronic;
            IdSurname = idSurname;
        }
        public IdFullName(string parentKey)
        {
            String[] idNamePart = parentKey.Split('|');
            this.IdSurname = Convert.ToUInt32(idNamePart[0]);
            this.IdName = Convert.ToUInt32(idNamePart[1]);
            this.IdPathronic = Convert.ToUInt32(idNamePart[2]);
        }
        public IdFullName()
        {

        }
        public string GetKeyId()
        {
            return IdSurname + "|" + IdName + "|" + IdPathronic;
        }
    }
}
