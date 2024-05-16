using System.ComponentModel;

namespace TweakMaker
{
    public partial class ItemIdentifierControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user changes text")]
        public event EventHandler? ValueChanged;

        private readonly DumpData? _dump;

        public string Identifier
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public ItemIdentifierControl(DumpData? dumpData)
        {
            InitializeComponent();
            _dump = dumpData;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (_dump == null) return;

            var dialog = new DialogSelectTemplate(_dump.items.Values, Identifier);
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
