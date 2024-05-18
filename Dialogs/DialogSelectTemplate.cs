using BlueMystic;
using Newtonsoft.Json.Linq;
using static TweakMaker.DialogSelectIcon;

namespace TweakMaker
{
    public partial class DialogSelectTemplate : Form
    {
        private readonly DumpData _dump;
        private readonly string _dumpCategory;
        private readonly string _defaultSelection;

        public DialogSelectTemplate(string title, DumpData dump, string dumpCategory, string defaultSelection)
        {
            InitializeComponent();

            Text = title;

            _dump = dump;
            _dumpCategory = dumpCategory;
            _defaultSelection = defaultSelection;
            var names = _dump.Flatten(_dumpCategory);
            listBoxSelectTemplate.Items.Clear();
            listBoxSelectTemplate.Items.AddRange(names.Where(x => x.Value.ContainsKey("name")).Select(kv => new TemplateData(kv.Value)).ToArray());
            if (!_dump.IsEmpty(_dumpCategory)) listBoxSelectTemplate.SelectedIndex = 0;

            new DarkModeCS(this);
        }

        private void DialogSelectTemplate_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_defaultSelection))
            {
                listBoxSelectTemplate.SelectedIndex = listBoxSelectTemplate.Items.OfType<TemplateData>().ToList().FindIndex(x => x.identifier == _defaultSelection);
            }
        }

        public string SelectedIdentifier
        {
            get
            {
                return (listBoxSelectTemplate.SelectedItem as TemplateData)?.identifier ?? "";
            }
        }

        public TemplateData? SelectedTemplate
        {
            get
            {
                return listBoxSelectTemplate.SelectedItem as TemplateData;
            }
        }

        public class TemplateData(JObject json)
        {
            public string identifier = json["identifier"]?.ToString() ?? "_error_";
            public string name = json["name"]?.ToString() ?? "_error_";
            public JObject json = json;

            public override string? ToString() => name;
        }

        private void listBoxSelectTemplate_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedIdentifier))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
