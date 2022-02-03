using Requestr.PostmanImporter;

namespace Requestr
{
    public partial class Main : Form
    {
        private readonly RequestImporter requestImporter;

        public Main(RequestImporter requestImporter)
        {
            InitializeComponent();

            this.requestImporter = requestImporter;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {

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

            var contents = File.ReadAllText(openFileDialog.FileName);

            Collection requests;

            try
            {
                requests = requestImporter.Import(contents);
            }
            catch (UnsupportedCollectionFormatVersionException unsupportedErr)
            {
                MessageBox.Show(unsupportedErr.Message);
                
                return;
            }
            catch (Exception unknownErr)
            {
                MessageBox.Show($"Unknown error while importing collection: {unknownErr.Message}");

                return;
            }

            Console.WriteLine(requests);
        }
    }
}