using Requestr.Forms;
using Requestr.Forms.Controls;
using Requestr.Lib;
using Requestr.Lib.Exceptions;
using Requestr.Lib.Models;

namespace Requestr
{
    public partial class Main : Form
    {
        private readonly ImportService importService;
        private readonly CollectionService collectionService;
        private readonly RequestService requestService;

        public Main(
            ImportService importService,
            CollectionService collectionService,
            RequestService requestService
        )
        {
            InitializeComponent();

            tabRequests.TabPages.Clear();

            this.importService = importService;
            this.collectionService = collectionService;
            this.requestService = requestService;

            var collections = collectionService.LoadAsync().Result;

            var nodes = collections.Select(c => GetNode(c)).ToArray();

            treeCollections.Nodes.AddRange(nodes);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnNewRequest_Click(object sender, EventArgs e)
        {
            var tabPage = new RequestTab()
            {
                Id = Guid.NewGuid(),
                Text = "Untitled",
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

            var requestItem = new Request()
            {
                Name = "Untitled",
                Method = "GET",
                Url = "https://example.com",
            };

            var requestPanel = new RequestPanel
            {
                Dock = DockStyle.Fill,
                RequestItem = requestItem,
            };

            tabPage.Controls.Add(requestPanel);

            tabRequests.TabPages.Add(tabPage);

            tabRequests.SelectedTab = tabPage;
        }

        private async void BtnImport_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "JSON Files (*.json)|*.json";

            var result = openFileDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            var fileContents = File.ReadAllText(openFileDialog.FileName);

            try
            {
                var node = await GetNodeAsync(fileContents);

                treeCollections.Nodes.Add(node);
            }
            catch (ImportException unsupportedErr)
            {
                MessageBox.Show(unsupportedErr.Message);
            }
            catch (Exception unknownErr)
            {
                MessageBox.Show($"Unknown error while importing collection: {unknownErr.Message}");
            }
        }

        private async Task<TreeNode> GetNodeAsync(string fileContents)
        {
            var collection = await importService.ImportAsync(fileContents);

            return GetNode(collection);
        }

        private TreeNode GetNode(Collection collection)
        {
            var collectionNode = new CollectionNode()
            {
                Id = collection.Id,
                Text = collection.Name,
            };

            foreach (var request in collection.Requests)
            {
                var requestNode = new RequestNode()
                {
                    Id = request.Id,
                    Text = request.Name,
                    Request = request,
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

            var (existingTab, index) = tabRequests.FindByKey(node.Id);

            if (existingTab != null)
            {
                tabRequests.SelectedIndex = index;

                return;
            }

            var tabPage = new RequestTab()
            {
                Id = node.Request.Id,
                Text = node.Request.Name,
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
                Dock = DockStyle.Fill,
                RequestItem = node.Request,
            };

            tabPage.Controls.Add(requestPanel);

            tabRequests.TabPages.Add(tabPage);

            tabRequests.SelectedTab = tabPage;
        }

        private void treeCollections_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            treeCollectionsContextMenu.Show();

        }

        private async void CollectionTreeDelete_Click(object sender, EventArgs e)
        {
            var selected = treeCollections.SelectedNode;

            if (selected is CollectionNode collectionNode)
            {
                var answer = MessageBox.Show($"Really delete Collection: {collectionNode.Text}?", caption: "Confirm", MessageBoxButtons.YesNo);

                if (answer == DialogResult.No)
                {
                    return;
                }

                await collectionService.DeleteAsync(collectionNode.Id);

                treeCollections.Nodes.Remove(collectionNode);
            }
            else if (selected is RequestNode requestNode)
            {
                var answer = MessageBox.Show($"Really delete Request:skds {requestNode.Text}?", caption: "Confirm", MessageBoxButtons.YesNo);

                if (answer == DialogResult.No)
                {
                    return;
                }

                await requestService.DeleteAsync(requestNode.Id);

                treeCollections.Nodes.Remove(requestNode);
            }
        }
    }

    static class TabControlExtensions
    {
        public static (RequestTab, int) FindByKey(this TabControl tabControl, Guid key)
        {
            int i = 0;

            foreach (var tabPage in tabControl.TabPages)
            {
                i++;

                if (tabPage is not RequestTab tab)
                {

                    continue;
                }

                if (tab.Id == key)
                {
                    return (tab, i - 1);
                }
            }

            return (null, i);
        }
    }
}