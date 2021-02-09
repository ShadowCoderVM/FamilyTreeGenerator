using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using FamilyTreeGenerator.Dictionaries;
using FamilyTreeGenerator.TreeGeneratorFiles;
namespace FamilyTreeGenerator
{
    public partial class TreeForm : Form
    {
        private TreeNode savedTreeNode;
        private TreeNode SavedTreeNode
        {
            set
            {
                savedTreeNode = (TreeNode)value.Clone();
            }
            get
            {
                return (TreeNode)savedTreeNode.Clone();
            }
        }
        public TreeForm()
        {
            InitializeComponent();
        }
        public void AddRootElement(TreeNode node)
        {
            treeView.Nodes.Add(node);
            treeView.SelectedNode = treeView.Nodes[0];
        }
        private void AddСhildElement(TreeNode node)
        {
            treeView.SelectedNode.Nodes.Add(node);
        }
        public void AddElement(TreeNode node)
        {
            if (treeView.SelectedNode == null)
            {
                AddRootElement(node);
            }
            else
            {
                AddСhildElement(node);
            }
        }
        public void SaveElement()
        {
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode != null) SavedTreeNode = selectedNode;
        }
        public void InsertSavedElement()
        {
            if (SavedTreeNode != null)
            {
                treeView.SelectedNode.Nodes.Add(SavedTreeNode);
            }
        }
        public void InsertRootElement()
        {
            if (SavedTreeNode != null)
            {
                treeView.Nodes.Add(SavedTreeNode);
            }
        }
        public void DeleteElement()
        {
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode != null) selectedNode.Remove();
        }
       
        public void RenameElement(FullNameDictionaries dictionaries)
        {
            if (treeView.SelectedNode == null) return;

            TreeNode selectedNode = treeView.SelectedNode;
            TreeNode parenNode = selectedNode.Parent;

            TakeFullNameForm TIF = new TakeFullNameForm(dictionaries);
            TIF.Node = selectedNode;
            TIF.Text = "Переименование элемента";

            if (TIF.ShowDialog() == DialogResult.OK)
            {
                TreeNode newNode = TIF.Node;
                TreeNodeCollection treeNodeCollection = selectedNode.Nodes;
                parenNode.Nodes.Remove(selectedNode);
               
                foreach (TreeNode x in treeNodeCollection)
                {
                    newNode.Nodes.Add(x);
                }
                parenNode.Nodes.Insert(selectedNode.Index, newNode);
            }
        }
        public void SaveTree(string path)
        {
            TreeNodeCollection allNodes = treeView.Nodes;
            if (allNodes == null) return;
            TreeNode mainNode = new TreeNode();
            foreach (TreeNode x in allNodes)
            {
                mainNode.Nodes.Add((TreeNode)x.Clone());
            }
            BinaryFormatter formater = new BinaryFormatter();
            using (var stream = File.Create(path))
            {
                formater.Serialize(stream, mainNode);
            }
        }
        public void LoadTree(string path)
        {
            BinaryFormatter formater = new BinaryFormatter();
            using (var stream = File.Open(path, FileMode.Open))
            {
                TreeNode mainNode = (TreeNode)formater.Deserialize(stream);
                foreach (TreeNode x in mainNode.Nodes)
                {
                    treeView.Nodes.Add(x);
                }
            }
        }
        public void GenerateTree(FullNameDictionaries dictionaries, uint maxDepth)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            TakeDictionariesPaths TD = new TakeDictionariesPaths();
            if (selectedNode != null)
            {
                TreeGenerator TG = new TreeGenerator(dictionaries, maxDepth);
                TG.GenerateTree(selectedNode);
            }
        }
        
    }
}
