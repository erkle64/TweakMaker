using BlueMystic;
using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class StringListControl : UserControl
    {
        public StringListControl()
        {
            InitializeComponent();
        }

        public void LoadData(JArray? data)
        {
            listView.Items.Clear();
            if (data != null)
            {
                foreach (var entry in data)
                {
                    listView.Items.Add(new ListViewItem([entry.ToString()]));
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

        private void listView_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            if (e.Item != null)
            {
                if (e.SubItem == 0)
                {
                    listView.StartEditing(textBox, e.Item, e.SubItem);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listView.Items.Add(new ListViewItem(["new tag"]));
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
