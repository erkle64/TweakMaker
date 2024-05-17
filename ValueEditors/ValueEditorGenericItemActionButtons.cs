using Newtonsoft.Json.Linq;
using TweakMaker.Controls;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorGenericItemActionButtons : ValueEditor
    {
        private GenericItemActionsControl? _genericItemActionsControl;

        public override JToken? GetNewToken()
        {
            return _genericItemActionsControl?.BuildData();
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _genericItemActionsControl = new();
            table.Controls.Add(_genericItemActionsControl, 1, rowIndex);

            _genericItemActionsControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _genericItemActionsControl.Name = $"GenericItemActions_{_labelText}";
            _genericItemActionsControl.TabIndex = rowIndex + 1;
            _genericItemActionsControl.LoadData(GetOriginalToken() as JArray);
        }
    }
}
