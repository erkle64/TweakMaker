using BlueMystic;
using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class ToggleableModesControl : UserControl
    {
        private DumpData _dump;

        public ToggleableModesControl()
        {
            InitializeComponent();

            _dump = new DumpData();
        }

        public void LoadData(DumpData dump, JObject? data)
        {
            _dump = dump;

            listView.Items.Clear();
            if (data != null)
            {
                foreach (var entry in data)
                {
                    var name = entry.Value?["name"]?.ToString() ?? "";
                    var icon_identifier = entry.Value?["icon_identifier"]?.ToString() ?? "";
                    var isDefault = entry.Value?["isDefault"]?.Value<bool>() ?? false;
                    listView.Items.Add(new ListViewItem(new string[] { entry.Key, name, icon_identifier, isDefault.ToString() }));
                }
            }
        }

        public JObject BuildData()
        {
            var data = new JObject();

            foreach (ListViewItem item in listView.Items)
            {
                var identifier = item.SubItems[0].Text;

                var name = item.SubItems[1].Text;
                var icon_identifier = item.SubItems[2].Text;
                var isDefault = item.SubItems[3].Text == "True";

                var entry = new JObject
                {
                    { "name", name },
                    { "icon_identifier", icon_identifier },
                    { "isDefault", isDefault }
                };
                data.Add(identifier, entry);
            }

            return data;
        }

        private void listView_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            if (e.Item != null)
            {
                switch (e.SubItem)
                {
                    case 0:
                        {
                            var dialog = new DialogSelectTemplate("Select Building", _dump, "buildings", listView.Items[e.Item.Index].SubItems[e.SubItem].Text);
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                var identifier = dialog.SelectedIdentifier;
                                if (!string.IsNullOrEmpty(identifier))
                                {
                                    foreach (ListViewItem item in listView.Items)
                                    {
                                        if (item != e.Item && item.SubItems[0].Text == identifier)
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

                                    listView.Items[e.Item.Index].SubItems[0].Text = identifier;
                                }
                            }
                            dialog.Dispose();
                        }
                        break;

                    case 1:
                        listView.StartEditing(textBox, e.Item, e.SubItem);
                        break;

                    case 2:
                        {
                            var dialog = new DialogSelectIcon(_dump.Icons, listView.Items[e.Item.Index].SubItems[e.SubItem].Text);
                            if (dialog.ShowDialog(this) == DialogResult.OK)
                            {
                                listView.Items[e.Item.Index].SubItems[2].Text = dialog.SelectedIconName;
                            }
                        }
                        break;

                    case 3:
                        listView.Items[e.Item.Index].SubItems[3].Text = listView.Items[e.Item.Index].SubItems[3].Text == "True" ? "False" : "True";
                        break;
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dialog = new DialogSelectTemplate("Select Building", _dump, "buildings", "");
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

                    listView.Items.Add(new ListViewItem(new string[] { identifier, "unnamed", "", "false" }));
                }
            }
            dialog.Dispose();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count > 0)
            {
                var names = string.Join(", ", listView.SelectedIndices.Cast<int>().Select(i => listView.Items[i].SubItems[1].Text));
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
