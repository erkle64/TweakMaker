using Newtonsoft.Json.Linq;
using TweakMaker.ValueEditors;

namespace TweakMaker
{
    public partial class DialogChangeRecipe : Form
    {
        private readonly JObject _template;
        private readonly DumpData _dump;

        private readonly List<ValueEditor> _valueEditors = [];

        public DialogChangeRecipe(JObject template, DumpData dump)
        {
            InitializeComponent();

            _template = template;
            _dump = dump;

            Text = $"Editing {template["name"]?.Value<string>() ?? "Item"}";

            tableTemplate.SuspendLayout();

            tableTemplate.RowCount = 0;
            tableTemplate.RowStyles.Clear();

            AddRow<ValueEditorString>("Mod Identifier", "modIdentifier");
            AddRow<ValueEditorString>("Name", "name");
            AddRow<ValueEditorIconIdentifier>("Icon Identifier", "icon_identifier");
            AddRow<ValueEditorString>("Category Identifier", "category_identifier");
            AddRow<ValueEditorString>("Row Group Identifier", "rowGroup_identifier");
            AddRow<ValueEditorBoolean>("Is Hidden In Crafting Frame", "isHiddenInCharacterCraftingFrame");
            AddRow<ValueEditorBoolean>("Is Hidden By Narrative Trigger", "isHiddenByNarrativeTrigger");
            AddRow<ValueEditorBoolean>("Is Never Unseen Recipe", "isNeverUnseenRecipe");
            AddRow<ValueEditorString>("Narrative Trigger", "narrativeTrigger");
            AddRow<ValueEditorRecipeInputs>("Item Inputs", "input_data");
            AddRow<ValueEditorRecipeOutputs>("Item Outputs", "output_data");
            AddRow<ValueEditorRecipeInputFluids>("Fluid Inputs", "inputElemental_data");
            AddRow<ValueEditorRecipeOutputFluids>("Fluid Outputs", "outputElemental_data");
            AddRow<ValueEditorItemIdentifier>("Related Item Template Identifier", "relatedItemTemplateIdentifier");

            tableTemplate.ResumeLayout();
            tableTemplate.PerformLayout();
        }

        public JObject BuildTemplate()
        {
            var template = new JObject();
            foreach (var editor in _valueEditors)
            {
                var originalToken = editor.GetOriginalToken();
                var newToken = editor.GetNewToken();
                if (originalToken != null && newToken != null && !JToken.DeepEquals(originalToken, newToken))
                {
                    template[editor.Key] = newToken;
                }
            }

            return template;
        }

        private void AddRow<T>(string labelText, string key) where T : ValueEditor, new()
        {
            var rowIndex = tableTemplate.RowCount;
            tableTemplate.RowCount++;
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            var editor = new T();
            editor.Initialize(labelText, _template, key, _dump);
            editor.InitializeComponents(tableTemplate, rowIndex);
            _valueEditors.Add(editor);
        }

        private void panelScroll_Resize(object sender, EventArgs e)
        {
            tableTemplate.Width = panelScroll.ClientSize.Width;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            using (new CenterWinDialog(this))
            {
                if (MessageBox.Show("All changes will be lost.\nCancel anyway?", "Cancel", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
        }

        private void DialogChangeRecipe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK) return;

            using (new CenterWinDialog(this))
            {
                if (MessageBox.Show("All changes will be lost.\nCancel anyway?", "Cancel", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
