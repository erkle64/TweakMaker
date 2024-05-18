namespace TweakMaker.Dialogs
{
    public partial class DialogChooseTemplateIdentifier : Form
    {
        private readonly DumpData _dump;
        private readonly string _dumpCategory;

        public DialogChooseTemplateIdentifier(DumpData dump, string dumpCategory, string defaultIdentifier)
        {
            InitializeComponent();
            _dump = dump;
            _dumpCategory = dumpCategory;

            textBoxTemplateIdentifier.Text = defaultIdentifier;
        }

        public string SelectedIdentifier => textBoxTemplateIdentifier.Text;

        private void textBoxTemplateIdentifier_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTemplateIdentifier.Text))
            {
                buttonCreate.Enabled = false;
                labelConflict.Text = "";
            }
            else if (_dump.HasIdentifier(_dumpCategory, textBoxTemplateIdentifier.Text))
            {
                buttonCreate.Enabled = false;
                labelConflict.Text = "Identifier conflict!";
            }
            else
            {
                labelConflict.Text = "";
                buttonCreate.Enabled = true;
            }
        }
    }
}
