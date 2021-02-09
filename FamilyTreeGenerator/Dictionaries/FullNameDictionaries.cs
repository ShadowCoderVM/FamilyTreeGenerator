using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FamilyTreeGenerator.GenderEnum;
using FamilyTreeGenerator.TreeGeneratorFiles;
namespace FamilyTreeGenerator.Dictionaries
{
    public class FullNameDictionaries
    {
        public GenderFullName Males;
        public GenderFullName Female;
        public FullNameDictionaries()
        {
            Males = new GenderFullName(Gender.Man);
            Female = new GenderFullName(Gender.Woman);
        }
        public void Clear()
        {
            Males.Clear();
            Female.Clear();
        }
        public void LoadDictionaries(FilePaths paths, ParseSettings settingDictionaries)
        {
            Males.Names = LoadDictionary(paths.MaleNamesAndPathronic, settingDictionaries.MaleNames);
            Female.Names = LoadDictionary(paths.FemaleNames, settingDictionaries.FemaleNames);

            Males.Surnames = LoadDictionary(paths.Surnames,  settingDictionaries.MaleSurnames);
            Female.Surnames = LoadDictionary(paths.Surnames,  settingDictionaries.FemaleSurnames);

            Males.Patronymic = LoadDictionary(paths.MaleNamesAndPathronic,  settingDictionaries.MalePathronic);
            Female.Patronymic =LoadDictionary(paths.MaleNamesAndPathronic, settingDictionaries.FemalePathronic);
        }
        private List<string> LoadDictionary(string path, ParseTableSettings settingDictionary)
        {
            
            List<string> namePart = ParseCSV(LoadFile(path), settingDictionary);
            return namePart;
        }
        private String LoadFile(String path)
        {
            string text;
            using (StreamReader sw = new StreamReader(path, Encoding.Default))
            {
                text = sw.ReadToEnd();
            }
            return text;
        }
        private List<string> ParseCSV(String text, ParseTableSettings setting)
        {
            List<string> namePart = new List<string>();

            text = text.Replace("\r\n", "'");
            if (text.EndsWith("'"))
            {
                text = text.Substring(0, text.Length - 1);
            }
            string[] NameParts = text.Split(new char[] { '\'', ';' });

            for (int i = setting.Offset; i < NameParts.Length; i += setting.RowOffset)
            {
                if (NameParts[i].Length >= 1) namePart.Add(NameParts[i].Trim());
            }

            return namePart;
        }
        public bool CheckFillingDictionary()
        {
            if (Males.Names.Count == 0
                | Males.Surnames.Count == 0
                | Males.Patronymic.Count == 0
                | Female.Names.Count == 0
                | Female.Surnames.Count == 0
                | Female.Patronymic.Count == 0
                )
                return false;
            else return true;
        }
    }
}
