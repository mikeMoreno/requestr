using Requestr.Forms;
using Requestr.PostmanImporter;

namespace Requestr
{
    public partial class Main : Form
    {
        private readonly RequestImporter requestImporter;

        public Main(RequestImporter requestImporter)
        {
            InitializeComponent();

            tabsRequest.TabPages.Clear();

            this.requestImporter = requestImporter;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;

            var result = openFileDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            var fileContents = File.ReadAllText(openFileDialog.FileName);

            try
            {
                var nodes = GetNodes(fileContents);

                treeCollections.Nodes.Add(nodes);
            }
            catch (UnsupportedCollectionFormatVersionException unsupportedErr)
            {
                MessageBox.Show(unsupportedErr.Message);
            }
            catch (Exception unknownErr)
            {
                MessageBox.Show($"Unknown error while importing collection: {unknownErr.Message}");
            }
        }

        private TreeNode GetNodes(string fileContents)
        {
            var collection = requestImporter.Import(fileContents);

            var collectionNode = new CollectionNode()
            {
                Text = collection.Info.Name,
            };

            foreach (var requestItem in collection.Item)
            {
                var requestNode = new RequestNode()
                {
                    Text = requestItem.Name,
                    RequestItem = requestItem,
                };

                collectionNode.Nodes.Add(requestNode);
            }

            return collectionNode;
        }

        private void TreeCollections_DoubleClick(object sender, EventArgs e)
        {
            if (treeCollections.SelectedNode is not RequestNode node)
            {
                return;
            }

            var tabPage = new TabPage()
            {
                Text = node.RequestItem!.Name,
            };

            var requestPanel = new RequestPanel
            {
                Dock = DockStyle.Fill
            };

            tabPage.Controls.Add(requestPanel);

            tabsRequest.TabPages.Add(tabPage);

            requestPanel.cmboMethod.SelectedItem = node.RequestItem!.Request.Method;
            requestPanel.txtUrl.Text = node.RequestItem.Request.Url.Raw;
        }
    }
}