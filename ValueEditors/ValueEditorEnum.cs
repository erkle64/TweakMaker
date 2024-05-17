using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorEnum : ValueEditor
    {
        private ComboBox? _comboBox;

        public override JToken? GetNewToken()
        {
            return new JValue(_comboBox?.Text ?? "");
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _comboBox = new();
            table.Controls.Add(_comboBox, 1, rowIndex);

            _comboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _comboBox.Name = $"Enums_{_labelText}";
            _comboBox.TabIndex = rowIndex + 1;
            _comboBox.Items.Clear();
            _comboBox.Items.AddRange(_extraValues);
            _comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboBox.SelectedIndex = _comboBox.Items.IndexOf(GetOriginalValue<string>()) != -1 ? _comboBox.Items.IndexOf(GetOriginalValue<string>()) : 0;
        }
    }
}
