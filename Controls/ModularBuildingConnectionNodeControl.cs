using BlueMystic;
using Newtonsoft.Json.Linq;

namespace TweakMaker.Controls
{
    public partial class ModularBuildingConnectionNodeControl : UserControl
    {
        private DumpData _dump;

        public ModularBuildingConnectionNodeControl()
        {
            InitializeComponent();

            _dump = new DumpData();
        }

        public void LoadData(DumpData dump, JArray? data)
        {
            _dump = dump;

            tableLayoutPanelData.SuspendLayout();
            tableLayoutPanelData.Controls.Clear();
            if (data != null)
            {
                var rowIndex = 0;
                foreach (var entry in data)
                {
                    tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                    var dataControl = new ModularBuildingConnectionNodeDataControl();
                    dataControl.LoadData(_dump, entry as JObject);
                    tableLayoutPanelData.Controls.Add(dataControl, 0, rowIndex);

                    ++rowIndex;
                }
            }
            tableLayoutPanelData.ResumeLayout();
            tableLayoutPanelData.PerformLayout();
        }

        public JArray BuildData()
        {
            var data = new JArray();

            return data;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
        }
    }
}
