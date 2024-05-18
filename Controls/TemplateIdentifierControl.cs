using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace TweakMaker
{
    public partial class TemplateIdentifierControl : UserControl
    {
        private readonly DumpData _dump;
        private readonly string _dumpCategory;

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user changes text")]
        public event EventHandler? ValueChanged;

        public string Identifier
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public TemplateIdentifierControl(DumpData dump, string dumpCategory)
        {
            InitializeComponent();
            _dump = dump;
            _dumpCategory = dumpCategory;
        }

        private void button_Click(object sender, EventArgs e)
        {
            var dialog = new DialogSelectTemplate("Select Template", _dump, _dumpCategory, Identifier);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Identifier = dialog.SelectedIdentifier;
            }
            dialog.Dispose();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
    }
}
