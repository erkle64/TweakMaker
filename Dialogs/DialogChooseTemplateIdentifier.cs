using BlueMystic;

namespace TweakMaker.Dialogs
{
    public partial class DialogChooseTemplateIdentifier : Form
    {
        private readonly DumpData _dump;
        private readonly string _dumpCategory;

        public DialogChooseTemplateIdentifier(DumpData dump, string dumpCategory, string defaultIdentifier)
        {
            InitializeComponent();

            new DarkModeCS(this);

            _dump = dump;
            _dumpCategory = dumpCategory;

            textBoxTemplateIdentifier.Text = defaultIdentifier;

            if (string.IsNullOrEmpty(textBoxTemplateIdentifier.Text))
            {
                buttonCreate.Enabled = false;
                labelConflict.Text = "Must be non-empty!";
            }
            else if (_dump.HasIdentifier(_dumpCategory, textBoxTemplateIdentifier.Text))
            {
                buttonCreate.Enabled = false;
                labelConflict.Text = "Identifier conflict!";
            }
            else
            {
                labelConflict.Text = "No conflicts.";
                buttonCreate.Enabled = true;
            }
        }

        public string SelectedIdentifier => textBoxTemplateIdentifier.Text;

        private void textBoxTemplateIdentifier_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTemplateIdentifier.Text))
            {
                buttonCreate.Enabled = false;
                labelConflict.Text = "Must be non-empty!";
            }
            else if (_dump.HasIdentifier(_dumpCategory, textBoxTemplateIdentifier.Text))
            {
                buttonCreate.Enabled = false;
                labelConflict.Text = "Identifier conflict!";
            }
            else
            {
                labelConflict.Text = "No conflicts.";
                buttonCreate.Enabled = true;
            }
        }
    }
}
