using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class GenericItemActionsControl : UserControl
    {
        public GenericItemActionsControl()
        {
            InitializeComponent();
        }

        public void LoadData(JArray? data)
        {
            listView.Items.Clear();
            if (data != null)
            {
                foreach (JObject entry in data.Cast<JObject>())
                {
                    var action = entry?["action"]?.ToString() ?? "";
                    var hotkey = entry?["hotkey"]?.ToString() ?? "";
                    listView.Items.Add(new ListViewItem(new string[] { action, hotkey }));
                }
            }
        }

        public JArray BuildData()
        {
            var data = new JArray();

            foreach (ListViewItem item in listView.Items)
            {
                var action = item.SubItems[0].Text;
                var hotkey = item.SubItems[1].Text;

                var entry = new JObject
                {
                    { "action", action },
                    { "hotkey", hotkey }
                };
                data.Add(entry);
            }

            return data;
        }

        private void listView_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            if (e.Item != null)
            {
                listView.StartEditing(textBox, e.Item, e.SubItem);
            }
        }

        private static readonly string[] defaultItems = ["action", ""];
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listView.Items.Add(new ListViewItem(defaultItems));
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
