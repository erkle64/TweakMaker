using Newtonsoft.Json.Linq;
using TweakMaker.Controls;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorAABB3DList : ValueEditor
    {
        private AABB3DListControl? _AABB3DListControl;

        public override JToken? GetNewToken()
        {
            return _AABB3DListControl?.BuildData();
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _AABB3DListControl = new();
            table.Controls.Add(_AABB3DListControl, 1, rowIndex);

            _AABB3DListControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _AABB3DListControl.Name = $"AABB3DList_{_labelText}";
            _AABB3DListControl.TabIndex = rowIndex + 1;
            _AABB3DListControl.LoadData(GetOriginalToken() as JArray);
        }
    }
}
