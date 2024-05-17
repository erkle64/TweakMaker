using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorFloatString : ValueEditor
    {
        private NumericUpDown? _numericUpDown;

        public override JToken? GetNewToken()
        {
            if (_numericUpDown!.Value == 0 && GetOriginalValue<string>() == string.Empty) return new JValue(string.Empty);
            return new JValue($"{(float)(_numericUpDown?.Value ?? 0):0.#######}");
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
            _numericUpDown.Minimum = decimal.MinValue;
            _numericUpDown.Maximum = decimal.MaxValue;
            try
            {
                _numericUpDown.Value = (decimal)Convert.ToSingle(GetOriginalValue<string>(), System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                _numericUpDown.Value = 0;
            }
            ((System.ComponentModel.ISupportInitialize)_numericUpDown).EndInit();
        }
    }
}
