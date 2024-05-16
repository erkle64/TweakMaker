using Newtonsoft.Json.Linq;

namespace TweakMaker
{
    public partial class FormChangeItem : Form
    {
        private readonly JObject _template;
        private readonly DumpData _dump;

        public FormChangeItem(JObject template, DumpData dump)
        {
            InitializeComponent();

            _template = template;
            _dump = dump;

            Text = $"Editing {template["name"]?.Value<string>() ?? "Item"}";

            textBoxName.Text = _template["name"]?.Value<string>() ?? "";

            checkBoxIncludeInCreativeMode.Checked = _template["includeInCreativeMode"]?.Value<bool>() ?? false;

            textBoxCreativeModeCategory.Text = _template["creativeModeCategory_str"]?.Value<string>() ?? "";

            textBoxIconIdentifier.Text = _template["icon_identifier"]?.Value<string>() ?? "";

            numericStackSize.Value = _template["stackSize"]?.Value<int>() ?? 1;

            var flags = (_template["flags"]?.ToString() ?? "").Split(',').Select(x => x.Trim());
            System.Collections.IList list = checkedListBoxFlags.Items;
            for (int i = 0; i < list.Count; i++)
            {
                object? item = list[i];
                checkedListBoxFlags.SetItemChecked(i, flags.Contains(item?.ToString() ?? "_error_"));
            }

            comboBoxToggleableModeType.Text = _template["toggleableModeType"]?.Value<string>() ?? "";

            listBoxToggleableModes.Items.Clear();
            if (_template["toggleableModes"] is JObject toggleableModes)
            {
                foreach (var entry in toggleableModes)
                {
                    listBoxToggleableModes.Items.Add(new ListViewItem(new string[] {
                        entry.Value?["name"]?.ToString() ?? entry.Key,
                        entry.Key,
                        entry.Value?["icon_identifier"]?.ToString() ?? ""
                    }));
                }
            }

            comboBoxItemDestroyFlags.Text = _template["itemDestroyFlags"]?.Value<string>() ?? "";

            textBoxBuildableObjectIdentifier.Text = _template["buildableObjectIdentifer"]?.Value<string>() ?? "";

            comboBoxHandheldSubType.Text = _template["handheldSubType"]?.Value<string>() ?? "";

            checkBoxShakeRightArmOnUse.Checked = _template["handheld_miner_shakeRightArmOnUse"]?.Value<bool>() ?? false;

            textBoxDefaultPowerpoleItemTemplate.Text = _template["handheld_defaultPowerPoleItemTemplate_str"]?.Value<string>() ?? "";

            checkBoxSupportFocusMode.Checked = _template["supportsFocusMode"]?.Value<bool>() ?? false;

            numericMiningTimeReduction.Value = (decimal)(_template["miningTimeReductionInSec"]?.Value<float>() ?? 0.0f);

            numericMiningRange.Value = (decimal)(_template["miningRange"]?.Value<float>() ?? 0.0f);

            numericExplosionRadius.Value = (decimal)(_template["explosionRadius"]?.Value<float>() ?? 0.0f);

            try
            {
                numericBurnableFuelValue.Value = (decimal)(_template["burnable_fuelValueKJ_str"]?.Value<float>() ?? 0.0f);
            }
            catch (Exception)
            {
                numericBurnableFuelValue.Value = 0;
            }

            textBoxBurnableResidualItemTemplate.Text = _template["burnable_residualItemTemplate_str"]?.Value<string>() ?? "";

            numericBurnableResidualItemCount.Value = _template["burnable_residualItemCount"]?.Value<int>() ?? 0;
        }

        private void buttonIconIdentifierBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new DialogSelectIcon(_dump.icons, textBoxIconIdentifier.Text);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxIconIdentifier.Text = dialog.SelectedIconName;
            }
            dialog.Dispose();
        }

        private void buttonBuildableObjectIdentifier_Click(object sender, EventArgs e)
        {
            var dialog = new DialogSelectTemplate(_dump.buildings.Values, textBoxBuildableObjectIdentifier.Text);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxBuildableObjectIdentifier.Text = dialog.SelectedIdentifier;
            }
            dialog.Dispose();
        }

        private void buttonDefaultPowerpoleItemTemplate_Click(object sender, EventArgs e)
        {
            var dialog = new DialogSelectTemplate(_dump.items.Values, textBoxDefaultPowerpoleItemTemplate.Text);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDefaultPowerpoleItemTemplate.Text = dialog.SelectedIdentifier;
            }
            dialog.Dispose();
        }

        private void buttonBurnableResidualItemTemplate_Click(object sender, EventArgs e)
        {
            var dialog = new DialogSelectTemplate(_dump.items.Values, textBoxBurnableResidualItemTemplate.Text);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxBurnableResidualItemTemplate.Text = dialog.SelectedIdentifier;
            }
            dialog.Dispose();
        }

        private void panelScroll_Resize(object sender, EventArgs e)
        {
            tableTemplate.Width = panelScroll.ClientSize.Width;
        }
    }
}
