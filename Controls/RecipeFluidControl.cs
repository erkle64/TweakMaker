using BlueMystic;
using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class RecipeFluidControl : UserControl
    {
        private DumpData _dump;

        public RecipeFluidControl()
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
                    var name = dump.GetElementName(entry.Key);
                    var amount = entry.Value?["amount_str"]?.ToString() ?? "0";
                    listView.Items.Add(new ListViewItem(new string[] { entry.Key, name, amount }));
                }
            }
        }

        public JObject BuildData()
        {
            var data = new JObject();

            foreach (ListViewItem item in listView.Items)
            {
                var identifier = item.SubItems[0].Text;

                var amount = item.SubItems[2].Text;

                var entry = new JObject
                {
                    { "amount_str", amount }
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
                    case 1:
                        {
                            var dialog = new DialogSelectTemplate("Select Fluid", _dump, "elements", listView.Items[e.Item.Index].SubItems[e.SubItem].Text);
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
                                                    Messenger.MessageBox("Fluid already exists in list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            return;
                                        }
                                    }

                                    listView.Items[e.Item.Index].SubItems[0].Text = identifier;
                                    listView.Items[e.Item.Index].SubItems[1].Text = _dump.GetElementName(identifier);
                                }
                            }
                            dialog.Dispose();
                        }
                        break;

                    case 2:
                        listView.StartEditing(numericUpDownAmount, e.Item, e.SubItem);
                        break;
                }
            }
        }

        private void listView_SubItemEndEditing(object sender, ListViewEx.SubItemEndEditingEventArgs e)
        {
            if (!e.Cancel && e.SubItem == 2)
            {
                try
                {
                    var amount = Convert.ToSingle(e.DisplayText);
                    e.DisplayText = $"{amount:0.##}";
                }
                catch (Exception)
                {
                    if (e.Item != null)
                    {
                        e.DisplayText = listView.Items[e.Item.Index].SubItems[2].Text;
                    }
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dialog = new DialogSelectTemplate("Select Fluid", _dump, "elements", "");
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
                                    Messenger.MessageBox("Fluid already exists in list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            return;
                        }
                    }

                    listView.Items.Add(new ListViewItem(new string[] { identifier, _dump.GetElementName(identifier), "1" }));
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
