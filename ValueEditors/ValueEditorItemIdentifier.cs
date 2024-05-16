using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorItemIdentifier : ValueEditor
    {
        private ItemIdentifierControl? _itemIdentifierControl;

        public override JToken? GetNewToken()
        {
            return new JValue(_itemIdentifierControl?.Identifier ?? string.Empty);
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _itemIdentifierControl = new(_dump);
            table.Controls.Add(_itemIdentifierControl, 1, rowIndex);

            _itemIdentifierControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _itemIdentifierControl.Name = $"ItemIdentifier_{_labelText}";
            _itemIdentifierControl.TabIndex = rowIndex + 1;
            _itemIdentifierControl.Identifier = GetOriginalValue<string>() ?? string.Empty;
        }
    }
}
