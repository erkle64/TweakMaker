using Newtonsoft.Json.Linq;
using TweakMaker.Controls;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorDragModes : ValueEditor
    {
        private DragModesControl? _dragModesControl;

        public override JToken? GetNewToken()
        {
            return _dragModesControl?.BuildData();
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _dragModesControl = new();
            table.Controls.Add(_dragModesControl, 1, rowIndex);

            _dragModesControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _dragModesControl.Name = $"DragModes_{_labelText}";
            _dragModesControl.TabIndex = rowIndex + 1;
            _dragModesControl.LoadData(GetOriginalToken() as JArray);
        }
    }
}
