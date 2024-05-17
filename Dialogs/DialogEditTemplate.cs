using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TweakMaker.ValueEditors;

namespace TweakMaker
{
    public partial class DialogEditTemplate : Form
    {
        private readonly JObject _template;
        private readonly DumpData _dump;

        private readonly List<ValueEditor> _valueEditors = [];

        public DialogEditTemplate(JObject template, DumpData dump, Templates.Field[] fields)
        {
            InitializeComponent();

            _template = template;
            _dump = dump;

            Text = $"Editing {template["name"]?.Value<string>() ?? template["identifier"]?.Value<string>() ?? "Item"}";

            tableTemplate.SuspendLayout();

            tableTemplate.RowCount = 0;
            tableTemplate.RowStyles.Clear();

            var addRow = typeof(DialogEditTemplate).GetMethod(nameof(AddRow), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            Debug.Assert(addRow != null);
            foreach (var field in fields)
            {
                addRow.MakeGenericMethod(field.editor).Invoke(this, [field.label, field.identifier, field.extraValues]);
            }

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

        private void AddRow<T>(string labelText, string key, string[] extraValues) where T : ValueEditor, new()
        {
            var rowIndex = tableTemplate.RowCount;
            tableTemplate.RowCount++;
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            var editor = new T();
            editor.Initialize(labelText, _template, key, _dump, extraValues);
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
