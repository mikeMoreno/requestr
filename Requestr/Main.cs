using Requestr.Forms;
using Requestr.PostmanImporter;
using static System.Windows.Forms.TabControl;

namespace Requestr
{
    public partial class Main : Form
    {
        private readonly RequestImporter requestImporter;

        public Main(RequestImporter requestImporter)
        {
            InitializeComponent();

            tabRequests.TabPages.Clear();

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
                    Key = requestItem.Key,
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

            var (existingTab, index) = tabRequests.FindByKey(node.Key);

            if (existingTab != null)
            {
                tabRequests.SelectedIndex = index;

                return;
            }

            var tabPage = new RequestTab()
            {
                Key = node.RequestItem!.Key,
                Text = node.RequestItem!.Name,
                ContextMenuStrip = new ContextMenuStrip(),
            };

            var itemClose = new ToolStripMenuItem
            {
                Text = "Close",
            };

            itemClose.Click += (sender, e) =>
            {
                tabRequests.TabPages.Remove(tabRequests.SelectedTab);
            };

            tabPage.ContextMenuStrip.Items.Add(itemClose);

            var requestPanel = new RequestPanel
            {
                Dock = DockStyle.Fill
            };

            tabPage.Controls.Add(requestPanel);

            tabRequests.TabPages.Add(tabPage);

            requestPanel.cmboMethod.SelectedItem = node.RequestItem!.Request.Method;
            requestPanel.txtUrl.Text = node.RequestItem.Request.Url.Raw;

            tabRequests.SelectedTab = tabPage;
        }

        private void ItemClose_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    static class TabControlExtensions
    {
        public static (RequestTab?, int) FindByKey(this TabControl tabControl, Guid key)
        {
            int i = 0;

            foreach (var tabPage in tabControl.TabPages)
            {
                i++;

                if (tabPage is not RequestTab tab)
                {

                    continue;
                }

                if (tab.Key == key)
                {
                    return (tab, i - 1);
                }
            }

            return (null, i);
        }
    }
}