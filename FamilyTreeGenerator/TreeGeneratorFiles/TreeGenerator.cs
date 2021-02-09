using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using FamilyTreeGenerator.Dictionaries;
using FamilyTreeGenerator.GenderEnum;
using FamilyTreeGenerator.FullNameFiles;
namespace FamilyTreeGenerator.TreeGeneratorFiles
{
    internal class TreeGenerator
    {
        private uint maxDepth;
        private Random rand;
        private FullNameDictionaries dictionaries;
        public TreeGenerator(FullNameDictionaries dictionaries, uint maxDepth)
        {
            this.maxDepth = maxDepth;
            this.dictionaries = dictionaries;
            rand = new Random();
        }
        public void GenerateTree(TreeNode node)
        {
            if (node.Level < maxDepth)
            {
                node.Nodes.Add(GetNewNode(Gender.Man, node.ImageKey));
                GenerateTree(node.FirstNode);
                node.Nodes.Add(GetNewNode(Gender.Woman, node.ImageKey));
                GenerateTree(node.LastNode);
            }
        }
        private TreeNode GetNewNode(Gender gender, string parentKey)
        {
            FullName newFullName = new FullName();
            IdFullName parentIdFullName = new IdFullName(parentKey);
            IdFullName idNewFullName = new IdFullName();
            if (gender == Gender.Man)
            {
                idNewFullName = GetIdFullName(dictionaries.Males, parentIdFullName);
                newFullName = CreateFullName(dictionaries.Males, idNewFullName);

            }
            else if (gender == Gender.Woman)
            {
                idNewFullName = GetIdFullName(dictionaries.Female, parentIdFullName);
                newFullName = CreateFullName(dictionaries.Female, idNewFullName);
            } 
            return newFullName.GetNode();
        }
       
        private IdFullName GetIdFullName(GenderFullName dictionaries, IdFullName parentIdFullName )
        {
            IdFullName idFullName = new IdFullName();
            if (dictionaries.gender == Gender.Man)
            {
                idFullName = new IdFullName(
                parentIdFullName.IdSurname,
                parentIdFullName.IdPathronic,
                GenerateRandomId(dictionaries.Patronymic)
                );
            }
            else if (dictionaries.gender == Gender.Woman)
            {
                idFullName = new IdFullName(
                 GenerateRandomId(dictionaries.Surnames),
                 GenerateRandomId(dictionaries.Names),
                 GenerateRandomId(dictionaries.Patronymic));
            }

            return idFullName;
        }
        private FullName CreateFullName(GenderFullName dictionaries, IdFullName idFullName)
        {
            string name = dictionaries.Names[(int)idFullName.IdName];
            string surname = dictionaries.Surnames[(int)idFullName.IdSurname];
            string pathronic = dictionaries.Patronymic[(int)idFullName.IdPathronic];
            NameParts namePartS = new NameParts(surname, name, pathronic, dictionaries.gender);

            FullName fullName = new FullName(namePartS, idFullName);
            return fullName;
        }
        private uint GenerateRandomId(List<string> partName)
        {
            Thread.Sleep(15);
            int max = partName.Count;
            return (uint)rand.Next(max);
        }
    }
}