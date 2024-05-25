using BlueMystic;
using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class AABB3DListControl : UserControl
    {
        public AABB3DListControl()
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
                    var sx = entry?["size"]?["x"]?.ToString() ?? "0";
                    var sy = entry?["size"]?["y"]?.ToString() ?? "0";
                    var sz = entry?["size"]?["z"]?.ToString() ?? "0";
                    var lx = entry?["localOffset"]?["x"]?.ToString() ?? "0";
                    var ly = entry?["localOffset"]?["y"]?.ToString() ?? "0";
                    var lz = entry?["localOffset"]?["z"]?.ToString() ?? "0";
                    listView.Items.Add(new ListViewItem(new string[] { sx, sy, sz, lx, ly, lz }));
                }
            }
        }

        public JArray BuildData()
        {
            var data = new JArray();

            foreach (ListViewItem item in listView.Items)
            {
                var sx = 0;
                try { sx = Convert.ToInt32(item.SubItems[0].Text); }
                catch { }

                var sy = 0;
                try { sy = Convert.ToInt32(item.SubItems[1].Text); }
                catch { }

                var sz = 0;
                try { sz = Convert.ToInt32(item.SubItems[2].Text); }
                catch { }

                var lx = 0;
                try { lx = Convert.ToInt32(item.SubItems[3].Text); }
                catch { }

                var ly = 0;
                try { ly = Convert.ToInt32(item.SubItems[4].Text); }
                catch { }

                var lz = 0;
                try { lz = Convert.ToInt32(item.SubItems[5].Text); }
                catch { }

                var entry = new JObject
                {
                    { "size", new JObject { { "x", sx }, { "y", sy }, { "z", sz } } },
                    { "localOffset", new JObject { { "x", lx }, { "y", ly }, { "z", lz } } }
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
                    case 3:
                    case 4:
                    case 5:
                        listView.StartEditing(numericUpDownAmount, e.Item, e.SubItem);
                        break;
                }
            }
        }

        private static readonly string[] defaultSubItems = ["0", "0", "0", "0", "0", "0"];
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listView.Items.Add(new ListViewItem(defaultSubItems));
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count > 0)
            {
                var names = string.Join(", ", listView.SelectedIndices.Cast<int>().Select(i => $"({listView.Items[i].SubItems[0].Text}, {listView.Items[i].SubItems[1].Text}, {listView.Items[i].SubItems[2].Text})+({listView.Items[i].SubItems[3].Text}, {listView.Items[i].SubItems[4].Text}, {listView.Items[i].SubItems[5].Text})"));
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

        private void AABB3DListControl_Resize(object sender, EventArgs e)
        {
            listView.ResizeAutoSizeColumn(listView.Columns.Count - 1, 90);
        }

        private void listView_Layout(object sender, LayoutEventArgs e)
        {
            listView.ResizeAutoSizeColumn(listView.Columns.Count - 1, 90);
        }
    }
}
