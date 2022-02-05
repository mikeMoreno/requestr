using Requestr.Forms;
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
        private readonly RequestPanelFactory requestPanelFactory;


        public Main(
            ImportService importService,
            CollectionService collectionService,
            RequestService requestService,
            RequestPanelFactory requestPanelFactory
        )
        {
            InitializeComponent();

            tabsRequests.TabPages.Clear();

            this.importService = importService;
            this.collectionService = collectionService;
            this.requestService = requestService;
            this.requestPanelFactory = requestPanelFactory;

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
                tabsRequests.TabPages.Remove(tabsRequests.SelectedTab);
            };

            tabPage.ContextMenuStrip.Items.Add(itemClose);

            var request = new Request()
            {
                Name = "Untitled",
                Method = "GET",
                Url = "https://example.com",
            };

            var requestPanel = requestPanelFactory.Build(request);

            tabPage.Controls.Add(requestPanel);

            tabsRequests.TabPages.Add(tabPage);

            tabsRequests.SelectedTab = tabPage;
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

        private static TreeNode GetNode(Collection collection)
        {
            var collectionNode = new CollectionNode()
            {
                Id = collection.Id,
                Text = collection.Name,
                Collection = collection,
            };

            foreach (var request in collection.Requests)
            {
                var requestNode = GetNode(request);

                collectionNode.Nodes.Add(requestNode);
            }

            return collectionNode;
        }

        private static TreeNode GetNode(Request request)
        {
            var requestNode = new RequestNode()
            {
                Id = request.Id,
                Text = request.Name,
                Request = request,
            };

            return requestNode;
        }

        private void TreeCollections_DoubleClick(object sender, EventArgs e)
        {
            if (treeCollections.SelectedNode is not RequestNode node)
            {
                return;
            }

            var existingTab = tabsRequests.TabPages.OfType<RequestTab>().SingleOrDefault(t => t.Id == node.Id);

            if (existingTab != null)
            {
                tabsRequests.SelectedTab = existingTab;

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
                tabsRequests.TabPages.Remove(tabsRequests.SelectedTab);
            };

            tabPage.ContextMenuStrip.Items.Add(itemClose);

            var requestPanel = requestPanelFactory.Build(node.Request);

            tabPage.Controls.Add(requestPanel);

            tabsRequests.TabPages.Add(tabPage);

            tabsRequests.SelectedTab = tabPage;
        }

        private void TreeCollections_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
                var answer = MessageBox.Show($"Really delete Request: {requestNode.Text}?", caption: "Confirm", MessageBoxButtons.YesNo);

                if (answer == DialogResult.No)
                {
                    return;
                }

                await requestService.DeleteAsync(requestNode.Id);

                treeCollections.Nodes.Remove(requestNode);
            }
        }

        private async void CollectionTreeRename_Click(object sender, EventArgs e)
        {
            var selected = treeCollections.SelectedNode;

            if (selected is CollectionNode collectionNode)
            {
                var inputBox = new InputBox(collectionNode.Text)
                {
                    Text = "Rename Collection",
                };

                var ans = inputBox.ShowDialog();

                if (ans != DialogResult.OK)
                {
                    return;
                }

                var collection = collectionNode.Collection;
                collection.Name = inputBox.TextEntered;

                await collectionService.UpdateAsync(collection);

                collectionNode.Text = collection.Name;
            }
            else if (selected is RequestNode requestNode)
            {
                var inputBox = new InputBox(requestNode.Text)
                {
                    Text = "Rename Request",
                };

                var ans = inputBox.ShowDialog();

                if (ans != DialogResult.OK)
                {
                    return;
                }

                var request = requestNode.Request;
                request.Name = inputBox.TextEntered;

                await requestService.UpdateAsync(request);

                requestNode.Text = request.Name;
            }
        }

        private async void CollectionTreeClone_Click(object sender, EventArgs e)
        {
            var selected = treeCollections.SelectedNode;

            if (selected is CollectionNode collectionNode)
            {
                var collection = collectionNode.Collection;

                var clonedCollection = await collectionService.CloneAsync(collection);

                var clonedNode = GetNode(clonedCollection);

                treeCollections.Nodes.Add(clonedNode);
            }
            else if (selected is RequestNode requestNode)
            {
                var request = requestNode.Request;

                var clonedRequest = await requestService.CloneAsync(request);

                // TODO: GetNode method for requests also?

                var clonedNode = new RequestNode()
                {
                    Id = clonedRequest.Id,
                    Text = clonedRequest.Name,
                    Request = clonedRequest,
                };

                requestNode.Parent.Nodes.Add(clonedNode);
            }
        }
    }
}