using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class RecipeItemControl : UserControl
    {
        private DumpData _dump;

        public RecipeItemControl()
        {
            InitializeComponent();

            _dump = new DumpData();
        }

        public void LoadData(DumpData dump, JObject? data, bool showPercentage)
        {
            _dump = dump;

            listView.Items.Clear();
            if (data != null)
            {
                foreach (var entry in data)
                {
                    var name = dump.GetItemName(entry.Key);
                    var amount = entry.Value?["amount"]?.ToString() ?? "0";
                    var percentage_str = entry.Value?["percentage_str"]?.ToString() ?? "1";
                    var percentage = 100;
                    try
                    {
                        percentage = (int)Math.Round(Convert.ToSingle(percentage_str) * 100.0f);
                    }
                    catch (Exception) { }
                    listView.Items.Add(new ListViewItem(new string[] { entry.Key, name, amount, percentage.ToString() }));
                }
            }

            if (!showPercentage) columnHeaderPercentage.Width = 0;
        }

        public JObject BuildData()
        {
            var data = new JObject();

            foreach (ListViewItem item in listView.Items)
            {
                var identifier = item.SubItems[0].Text;

                int amount;
                try { amount = Convert.ToInt32(item.SubItems[2].Text); }
                catch { amount = 0; }

                int percentage;
                try { percentage = Convert.ToInt32(item.SubItems[3].Text); }
                catch { percentage = 0; }

                var entry = new JObject
                {
                    { "amount", amount },
                    { "percentage_str", $"{percentage/100.0f:0.##}" }
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
                            var dialog = new DialogSelectTemplate(_dump.items.Values, listView.Items[e.Item.Index].SubItems[e.SubItem].Text);
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
                                                    MessageBox.Show(this, "Item already exists in list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            return;
                                        }
                                    }

                                    listView.Items[e.Item.Index].SubItems[0].Text = identifier;
                                    listView.Items[e.Item.Index].SubItems[1].Text = _dump.GetItemName(identifier);
                                }
                            }
                            dialog.Dispose();
                        }
                        break;

                    case 2:
                        listView.StartEditing(numericUpDownAmount, e.Item, e.SubItem);
                        break;

                    case 3:
                        listView.StartEditing(numericUpDownPercentage, e.Item, e.SubItem);
                        break;
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dialog = new DialogSelectTemplate(_dump.items.Values, "");
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
                                    MessageBox.Show(this, "Item already exists in list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            return;
                        }
                    }

                    listView.Items.Add(new ListViewItem(new string[] { identifier, _dump.GetItemName(identifier), "1", "100" }));
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
                        if (MessageBox.Show(
                            this,
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
    }
}
