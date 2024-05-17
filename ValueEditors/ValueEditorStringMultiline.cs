using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorStringMultiline : ValueEditor
    {
        private TextBox? _textBox;

        public override JToken? GetNewToken()
        {
            return new JValue(_textBox?.Text ?? string.Empty);
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _textBox = new TextBox();
            table.Controls.Add(_textBox, 1, rowIndex);

            _textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _textBox.Name = $"textBox_{_labelText}";
            _textBox.TabIndex = rowIndex + 1;
            _textBox.Text = GetOriginalValue<string>();
            _textBox.Multiline = true;
            _textBox.MinimumSize = new Size(0, 100);
        }
    }
}
