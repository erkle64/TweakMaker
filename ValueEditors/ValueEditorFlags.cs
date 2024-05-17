using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorFlags : ValueEditor
    {
        private CheckedListBox? _checkedListBox;

        public override JToken? GetNewToken()
        {
            if (_checkedListBox?.CheckedItems.Count == 0) return new JValue("0");
            return new JValue(string.Join(", ", _checkedListBox!.CheckedItems.Cast<string>() ?? []));
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _checkedListBox = new();
            table.Controls.Add(_checkedListBox, 1, rowIndex);

            _checkedListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _checkedListBox.Name = $"Flags_{_labelText}";
            _checkedListBox.TabIndex = rowIndex + 1;
            _checkedListBox.Items.Clear();
            _checkedListBox.Items.AddRange(_extraValues);
            _checkedListBox.MinimumSize = new Size(0, 100);
            foreach (var value in GetOriginalValue<string>()?.Split(',').Select(x => x.Trim()).ToArray() ?? [])
            {
                var index = _checkedListBox.Items.IndexOf(value);
                if (index >= 0) _checkedListBox.SetItemChecked(index, true);
            }
        }
    }
}
