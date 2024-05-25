using BlueMystic;
using Newtonsoft.Json.Linq;

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
            var names = _dump.BuildNameMap(_dumpCategory);
            listBoxSelectTemplate.Items.Clear();
            listBoxSelectTemplate.Items.AddRange(names.Where(x => !string.IsNullOrEmpty(x.Value.name)).Select(kv => new TemplateData(kv.Key, kv.Value)).ToArray());
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

        public class TemplateData(string identifier, DumpData.NameMap nameMap)
        {
            public string identifier = identifier;
            public string name = nameMap.name;
            public JObject json = nameMap.template;

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
