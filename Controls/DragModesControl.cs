using BlueMystic;
using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class DragModesControl : UserControl
    {
        public DragModesControl()
        {
            InitializeComponent();
        }

        public void LoadData(JArray? data)
        {
            listView.Items.Clear();
            if (data != null)
            {
                foreach (var entry in data.Cast<JObject>())
                {
                    var name = entry?["name"]?.ToString() ?? "";
                    var isDefault = entry?["isDefault"]?.Value<bool>() ?? false;
                    listView.Items.Add(new ListViewItem(new string[] { name, isDefault.ToString() }));
                }
            }
        }

        public JArray BuildData()
        {
            var data = new JArray();

            foreach (ListViewItem item in listView.Items)
            {
                var name = item.SubItems[0].Text;
                var isDefault = item.SubItems[1].Text == "True";

                var entry = new JObject {
                    { "name", name },
                    { "isDefault", isDefault }
                };
                data.Add(entry);
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
                        listView.StartEditing(textBox, e.Item, e.SubItem);
                        break;

                    case 1:
                        listView.Items[e.Item.Index].SubItems[e.SubItem].Text = listView.Items[e.Item.Index].SubItems[e.SubItem].Text == "True" ? "False" : "True";
                        break;
                }
            }
        }

        private static readonly string[] _defaultSubItems = ["unnamed", "False"];
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listView.Items.Add(new ListViewItem(_defaultSubItems));
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
