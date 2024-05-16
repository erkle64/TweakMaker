using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorInteger : ValueEditor
    {
        private NumericUpDown? _numericUpDown;

        public override JToken? GetNewToken()
        {
            return new JValue((int)(_numericUpDown?.Value ?? 0));
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _numericUpDown = new();
            table.Controls.Add(_numericUpDown, 1, rowIndex);

            ((System.ComponentModel.ISupportInitialize)_numericUpDown).BeginInit();
            _numericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _numericUpDown.Name = $"numericUpDown_{_labelText}";
            _numericUpDown.TabIndex = rowIndex + 1;
            _numericUpDown.Value = GetOriginalValue<int>();
            ((System.ComponentModel.ISupportInitialize)_numericUpDown).EndInit();
        }
    }
}
