using BlueMystic;
using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class ModularBuildingConnectionNodeDataControl : UserControl
    {
        private DumpData _dump;

        public ModularBuildingConnectionNodeDataControl()
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
                numericUpDownX.Value = data["attachmentPointPreviewPosition"]?["x"]?.Value<int>() ?? 0;
                numericUpDownY.Value = data["attachmentPointPreviewPosition"]?["y"]?.Value<int>() ?? 0;
                numericUpDownZ.Value = data["attachmentPointPreviewPosition"]?["z"]?.Value<int>() ?? 0;

                if (data["nodeData"] is JArray nodeData)
                {
                    foreach (var entry in nodeData)
                    {
                        var identifier = entry?["bot_identifier"]?.ToString() ?? "";
                        var name = dump.GetBuildingName(identifier);
                        var positionData = entry?["positionData"] as JObject;
                        var offset = positionData?["offset"] as JObject;
                        var x = offset?["x"]?.ToString() ?? "0";
                        var y = offset?["x"]?.ToString() ?? "0";
                        var z = offset?["x"]?.ToString() ?? "0";
                        var orientation = positionData?["orientation"]?.ToString() ?? "1";
                        listView.Items.Add(new ListViewItem(new string[] { identifier, name, x, y, z, orientation }));
                    }
                }
            }
        }

        public JObject BuildData()
        {
            var nodes = new JArray();

            foreach (ListViewItem item in listView.Items)
            {
                var identifier = item.SubItems[0].Text;

                int x;
                try { x = Convert.ToInt32(item.SubItems[2].Text); }
                catch { x = 0; }

                int y;
                try { y = Convert.ToInt32(item.SubItems[3].Text); }
                catch { y = 0; }

                int z;
                try { z = Convert.ToInt32(item.SubItems[4].Text); }
                catch { z = 0; }

                var orientation = item.SubItems[5].Text;
                var entry = new JObject
                {
                    { "bot_identifier", identifier },
                    { "positionData",
                        new JObject {
                            { "offset", new JObject
                                {
                                    { "x", x },
                                    { "y", y },
                                    { "z", z },
                                }
                            },
                            { "orientation", orientation }
                        }
                    }
                };
                nodes.Add(entry);
            }

            var ax = (int)numericUpDownX.Value;
            var ay = (int)numericUpDownY.Value;
            var az = (int)numericUpDownZ.Value;

            return new JObject
            {
                { "nodeData", nodes },
                { "attachmentPointPreviewPosition",
                    new JObject {
                        { "x", ax },
                        { "y", ay },
                        { "z", az },
                    }
                }
            };
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
                            var dialog = new DialogSelectTemplate("Select Building", _dump, "buildings", listView.Items[e.Item.Index].SubItems[0].Text);
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
                                                    Messenger.MessageBox("Building already exists in list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            return;
                                        }
                                    }

                                    listView.Items[e.Item.Index].SubItems[0].Text = identifier;
                                    listView.Items[e.Item.Index].SubItems[1].Text = _dump.GetBuildingName(identifier);
                                }
                            }
                            dialog.Dispose();
                        }
                        break;

                    case 2:
                    case 3:
                    case 4:
                        listView.StartEditing(numericUpDown, e.Item, e.SubItem);
                        break;
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dialog = new DialogSelectTemplate("Select Item", _dump, "items", "");
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

        private void ModularBuildingConnectionNodeDataControl_Resize(object sender, EventArgs e)
        {
            listView.ResizeAutoSizeColumn(listView.Columns.Count - 1);
        }

        private void listView_Layout(object sender, LayoutEventArgs e)
        {
            listView.ResizeAutoSizeColumn(listView.Columns.Count - 1);
        }
    }
}
