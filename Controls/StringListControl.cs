using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class StringListControl : UserControl
    {
        private DumpData _dump;

        public StringListControl()
        {
            InitializeComponent();

            _dump = new DumpData();
        }

        public void LoadData(DumpData dump, JArray? data)
        {
            _dump = dump;

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
