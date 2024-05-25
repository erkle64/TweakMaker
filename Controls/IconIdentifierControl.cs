using System.ComponentModel;

namespace TweakMaker
{
    public partial class IconIdentifierControl : UserControl
    {
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user changes text")]
        public event EventHandler? ValueChanged;

        private readonly DumpData? _dump;

        public string IconIdentifier
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public IconIdentifierControl(DumpData? dumpData)
        {
            InitializeComponent();
            _dump = dumpData;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (_dump == null) return;

            var dump = _dump;
            while (dump.Parent != null) dump = dump.Parent;
            var dialog = new DialogSelectIcon(dump.Icons, IconIdentifier);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IconIdentifier = dialog.SelectedIconName;
            }
            dialog.Dispose();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
    }
}
