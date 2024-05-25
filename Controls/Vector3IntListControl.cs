using BlueMystic;
using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class Vector3IntListControl : UserControl
    {
        public Vector3IntListControl()
        {
            InitializeComponent();

            numericUpDownAmount.Minimum = int.MinValue;
            numericUpDownAmount.Maximum = int.MaxValue;
        }

        public void LoadData(JArray? data)
        {
            listView.Items.Clear();
            if (data != null)
            {
                foreach (var entry in data)
                {
                    var x = entry?["x"]?.ToString() ?? "0";
                    var y = entry?["y"]?.ToString() ?? "0";
                    var z = entry?["z"]?.ToString() ?? "0";
                    listView.Items.Add(new ListViewItem(new string[] { x, y, z }));
                }
            }
        }

        public JArray BuildData()
        {
            var data = new JArray();

            foreach (ListViewItem item in listView.Items)
            {
                var x = 0;
                try { x = Convert.ToInt32(item.SubItems[0].Text); }
                catch { }

                var y = 0;
                try { y = Convert.ToInt32(item.SubItems[1].Text); }
                catch { }

                var z = 0;
                try { z = Convert.ToInt32(item.SubItems[2].Text); }
                catch { }

                var entry = new JObject
                {
                    { "x", x },
                    { "y", y },
                    { "z", z },
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
                    case 1:
                    case 2:
                        listView.StartEditing(numericUpDownAmount, e.Item, e.SubItem);
                        break;
                }
            }
        }

        private static readonly string[] defaultSubItems = ["0", "0", "0"];
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listView.Items.Add(new ListViewItem(defaultSubItems));
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count > 0)
            {
                var names = string.Join(", ", listView.SelectedIndices.Cast<int>().Select(i => $"({listView.Items[i].SubItems[0].Text}, {listView.Items[i].SubItems[1].Text}, {listView.Items[i].SubItems[2].Text})"));
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

        private void Vector3IntListControl_Resize(object sender, EventArgs e)
        {
            listView.ResizeAutoSizeColumn(listView.Columns.Count - 1);
        }

        private void listView_Layout(object sender, LayoutEventArgs e)
        {
            listView.ResizeAutoSizeColumn(listView.Columns.Count - 1);
        }
    }
}
