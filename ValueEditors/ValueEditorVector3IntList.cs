using Newtonsoft.Json.Linq;
using TweakMaker.Controls;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorVector3IntList : ValueEditor
    {
        private Vector3IntListControl? _vector3IntListControl;

        public override JToken? GetNewToken()
        {
            return _vector3IntListControl?.BuildData();
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _vector3IntListControl = new();
            table.Controls.Add(_vector3IntListControl, 1, rowIndex);

            _vector3IntListControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _vector3IntListControl.Name = $"Vector3IntList_{_labelText}";
            _vector3IntListControl.TabIndex = rowIndex + 1;
            _vector3IntListControl.LoadData(GetOriginalToken() as JArray);
        }
    }
}
