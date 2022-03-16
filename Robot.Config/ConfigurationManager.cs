using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Robot.Config
{
    public partial class ConfigurationManager : Form
    {

        public ConfigurationManager()
        {
            InitializeComponent();

        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void treeViewConfig_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var x = e.Node;
            statusBar1.Panels[0].Text = x.FullPath;
            GetAttributes(x);

        }

        private void GetAttributes(TreeNode node)
        {
            dataGridViewAttributes.Rows.Clear();
            var reader = new XmlTextReader(treeViewConfig.Tag.ToString());
            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Element && reader.Name == node.Text)
                {
                    var attributeCount = reader.AttributeCount;
                    if (attributeCount > 0)
                    {
                     
                        for (var i = 0; i < attributeCount; i++)
                        {
                            reader.MoveToAttribute(i);
                            dataGridViewAttributes.Rows.Add(reader.Name, reader.Value);
                            
                        }
                    
                    }
                }

            }

        }


        private void ConfigurationManagement_Load(object sender, EventArgs e)
        {
            treeViewConfig.Nodes.Clear();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.DefultDocPath))
                
            {
                try
                {
                    LoadXml(Properties.Settings.Default.DefultDocPath);
                    textBoxLoad.Text = Properties.Settings.Default.DefultDocPath;
                }
                catch
                {
                    statusBar1.Panels[0].Text = "file not found...";
                }
            }
        }

        private void LoadXml(string fileName)
        {
            treeViewConfig.Tag = fileName;
                XmlTextReader reader = null;
                try
                {
                    treeViewConfig.BeginUpdate();
                    reader = new XmlTextReader(fileName);
                    var n = new TreeNode(fileName);
                    treeViewConfig.Nodes.Add(n);
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            var isEmptyElement = reader.IsEmptyElement;
                            var text = new StringBuilder();
                            text.Append(reader.Name);
                          

                            if (isEmptyElement)
                            {
                                n.Nodes.Add(text.ToString());
                            }
                            else
                            {
                                n = n.Nodes.Add(text.ToString());
                            }
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement)
                        {
                            n = n.Parent;
                        }
                        else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                        {

                        }
                        else if (reader.NodeType == XmlNodeType.None)
                        {
                            return;
                        }
                        else if (reader.NodeType == XmlNodeType.Text)
                        {
                            n.Nodes.Add(reader.Value);
                        }

                    }
                }
                finally
                {
                    treeViewConfig.EndUpdate();

                    if (reader != null) reader.Close();
                }
        }
        

        private void buttonSetDefult_Click(object sender, EventArgs e)
        {
            if (treeViewConfig.Tag == null)
            {
                MessageBox.Show("Please Load a File...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.DefultDocPath = treeViewConfig.Tag.ToString();
            Properties.Settings.Default.Save();
            statusBar1.Panels[0].Text = "Current XML set to default document";
        }

        private void buttonLoad_MouseLeave(object sender, EventArgs e)
        {
            statusBar1.Panels[0].Text = "Ready";
        }

        private void buttonSetDefult_MouseEnter(object sender, EventArgs e)
        {
            statusBar1.Panels[0].Text = "Set loaded XML to default document ";
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            statusBar1.Panels[0].Text = "Apply new value to loaded attribute and close configuration manager";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            statusBar1.Panels[0].Text = "Apply new value to loaded attribute";
        }

        private void buttonLoadPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxLoad.Text = openFileDialog.FileName;
                LoadXml(textBoxLoad.Text);
            }
        }

        private static void EditAttribute(TreeNode treeNode , int index ,string newValue , string path)
        {
   
            var doc = new XmlDocument();
            doc.Load(path);
            var x =doc.GetElementsByTagName(treeNode.Text)[0];
            if (x.Attributes != null) x.Attributes[index].Value = newValue;
            doc.Save(path);
        }

        private void dataGridViewAttributes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxValue.Text = dataGridViewAttributes.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridViewAttributes.SelectedRows.Count<=0)return;
            dataGridViewAttributes.SelectedRows[0].Cells[1].Value = textBoxValue.Text;
            buttonApply.Text = "&Apply";
            EditAttribute(treeViewConfig.SelectedNode,dataGridViewAttributes.SelectedRows[0].Index,textBoxValue.Text,treeViewConfig.Tag.ToString());

        }

        private void textBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            buttonApply.Text = "&Apply*";
        }

    }
}
