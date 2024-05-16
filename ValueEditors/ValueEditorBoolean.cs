using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorBoolean : ValueEditor
    {
        private CheckBox? _checkBox;

        public override JToken? GetNewToken()
        {
            return new JValue(_checkBox?.Checked);
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _checkBox = new CheckBox();
            table.Controls.Add(_checkBox, 1, rowIndex);

            _checkBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _checkBox.Name = $"checkBox_{_labelText}";
            _checkBox.TabIndex = rowIndex + 1;
            _checkBox.Text = string.Empty;
            _checkBox.Checked = GetOriginalValue<bool>();
        }
    }
}
