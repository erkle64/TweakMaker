using Newtonsoft.Json.Linq;
using TweakMaker.Controls;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorStringList : ValueEditor
    {
        private StringListControl? _stringListControl;

        public override JToken? GetNewToken()
        {
            return _stringListControl?.BuildData();
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _stringListControl = new();
            table.Controls.Add(_stringListControl, 1, rowIndex);

            _stringListControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _stringListControl.Name = $"StringList_{_labelText}";
            _stringListControl.TabIndex = rowIndex + 1;
            _stringListControl.LoadData(_dump, GetOriginalToken() as JArray);
        }
    }
}
