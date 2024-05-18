using BlueMystic;
using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class TemplateIdentifierListControl : UserControl
    {
        private readonly DumpData _dump;
        private readonly string _dumpCategory;

        public TemplateIdentifierListControl(DumpData dump, string dumpCategory)
        {
            InitializeComponent();
            _dump = dump;
            _dumpCategory = dumpCategory;
        }

        public void LoadData(JArray? data)
        {
            listView.Items.Clear();
            if (data != null)
            {
                foreach (var entry in data)
                {
                    var identifier = entry.ToString();
                    listView.Items.Add(new ListViewItem([identifier, _dump.GetTemplateName(_dumpCategory, identifier)]));
                }
            }
        }

        public JArray BuildData()
        {
            var data = new JArray();

            foreach (ListViewItem item in listView.Items)
            {
                data.Add(new JValue(item.SubItems[0].Text));
            }

            return data;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dialog = new DialogSelectTemplate("Select Template", _dump, _dumpCategory, "");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var identifier = dialog.SelectedIdentifier;
                if (!string.IsNullOrEmpty(identifier))
                {
                    foreach (ListViewItem item in listView.Items)
                    {
                        if (item.SubItems[0].Text == identifier)
                        {
                            var form = FindForm();
                            if (form != null)
                            {
                                using (new CenterWinDialog(form))
                                {
                                    Messenger.MessageBox("Item already exists in list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            return;
                        }
                    }

                    listView.Items.Add(new ListViewItem([identifier, dialog.SelectedTemplate!.name]));
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count > 0)
            {
                var names = string.Join(", ", listView.SelectedIndices.Cast<int>().Select(i => listView.Items[i].SubItems[0].Text));
                var form = FindForm();
                if (form != null)
                {
                    using (new CenterWinDialog(form))
                    {
                        if (Messenger.MessageBox(
                            $"Remove {names}?",
                            "Remove",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            try
                            {
                                listView.BeginUpdate();
                                foreach (ListViewItem item in listView.SelectedItems)
                                {
                                    listView.Items.Remove(item);
                                }
                            }
                            finally
                            {
                                listView.EndUpdate();
                            }
                        }
                    }
                }
            }
        }

        private void listView_Resize(object sender, EventArgs e)
        {
            listView.ResizeAutoSizeColumn(listView.Columns.Count - 1);
        }
    }
}
