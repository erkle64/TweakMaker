using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace TweakMaker
{
    public partial class TemplateIdentifierControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user changes text")]
        public event EventHandler? ValueChanged;

        private readonly IEnumerable<JObject> _templates;

        public string Identifier
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public TemplateIdentifierControl(IEnumerable<JObject> templates)
        {
            InitializeComponent();
            _templates = templates;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (_templates == null) return;

            var dialog = new DialogSelectTemplate("Select Template", _templates, Identifier);
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
