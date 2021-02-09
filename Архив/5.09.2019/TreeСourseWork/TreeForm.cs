using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace TreeСourseWork
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
        public void AddRootElement(string text)
        {
            TreeNodeCollection TNC = treeView1.Nodes;
            TNC.Add(text);
        }
        public void AddElement(string text)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode == null)
            {
                AddRootElement(text);
            }
            else
            {
                selectedNode.Nodes.Add(text);
            }
        }
        public void SaveElement()
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null) SavedTreeNode = selectedNode;
        }
        public void InsertElement()
        {
            if(SavedTreeNode!= null)
            {
                treeView1.SelectedNode.Nodes.Add(SavedTreeNode);
            }
        }
        public void InsertRootElement()
        {
            if (SavedTreeNode != null)
            {
                treeView1.Nodes.Add(SavedTreeNode);
            } 
        }
        public void DeleteElement()
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null) selectedNode.Remove();
        }
        public void RenameElement(string text)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null) selectedNode.Text = text;
            
        }
        public void SaveTree(string path)
        {
            TreeNodeCollection allNodes = treeView1.Nodes;
            
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
                    treeView1.Nodes.Add(x);
                }

            }
        }
    }
}
