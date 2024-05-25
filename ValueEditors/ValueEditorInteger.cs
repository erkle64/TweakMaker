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
            _numericUpDown.Minimum = int.MinValue;
            _numericUpDown.Maximum = int.MaxValue;
            _numericUpDown.Value = GetOriginalValue<int>();
            if (_extraValues != null)
            {
                if (_extraValues.Length == 1)
                {
                    try { _numericUpDown.Maximum = Convert.ToInt32(_extraValues[0]); }
                    catch(Exception) { }
                }
                else if (_extraValues.Length == 2)
                {
                    try { _numericUpDown.Minimum = Convert.ToInt32(_extraValues[0]); }
                    catch (Exception) { }
                    try { _numericUpDown.Maximum = Convert.ToInt32(_extraValues[1]); }
                    catch (Exception) { }
                }
            }
            ((System.ComponentModel.ISupportInitialize)_numericUpDown).EndInit();
        }
    }
}
