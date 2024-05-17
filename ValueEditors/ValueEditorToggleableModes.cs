using Newtonsoft.Json.Linq;
using TweakMaker.Controls;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorToggleableModes : ValueEditor
    {
        private ToggleableModesControl? _toggleableModesControl;

        public override JToken? GetNewToken()
        {
            return _toggleableModesControl?.BuildData();
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _toggleableModesControl = new();
            table.Controls.Add(_toggleableModesControl, 1, rowIndex);

            _toggleableModesControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _toggleableModesControl.Name = $"ToggleableModes_{_labelText}";
            _toggleableModesControl.TabIndex = rowIndex + 1;
            _toggleableModesControl.LoadData(_dump, GetOriginalToken() as JObject);
        }
    }
}
