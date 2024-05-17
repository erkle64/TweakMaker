using Newtonsoft.Json.Linq;
using static TweakMaker.DialogSelectIcon;

namespace TweakMaker
{
    public partial class DialogSelectTemplate : Form
    {
        private readonly IEnumerable<JObject> _templates;
        private readonly string _defaultSelection;

        public DialogSelectTemplate(string title, IEnumerable<JObject> templates, string defaultSelection)
        {
            InitializeComponent();

            Text = title;

            _templates = templates;
            _defaultSelection = defaultSelection;
            listBoxSelectTemplate.Items.Clear();
            listBoxSelectTemplate.Items.AddRange(_templates.Where(json => json.ContainsKey("name")).Select(json => new TemplateData(json)).ToArray());
            if (templates.Any()) listBoxSelectTemplate.SelectedIndex = 0;
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
