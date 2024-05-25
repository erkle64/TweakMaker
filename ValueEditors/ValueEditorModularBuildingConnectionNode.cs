using Newtonsoft.Json.Linq;
using TweakMaker.Controls;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorModularBuildingConnectionNode : ValueEditor
    {
        private ModularBuildingConnectionNodeControl? _modularBuildingConnectionNodeControl;

        public override JToken? GetNewToken()
        {
            return _modularBuildingConnectionNodeControl?.BuildData();
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _modularBuildingConnectionNodeControl = new();
            table.Controls.Add(_modularBuildingConnectionNodeControl, 1, rowIndex);

            _modularBuildingConnectionNodeControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _modularBuildingConnectionNodeControl.Name = $"ModularBuildingConnectionNode_{_labelText}";
            _modularBuildingConnectionNodeControl.TabIndex = rowIndex + 1;
            _modularBuildingConnectionNodeControl.LoadData(_dump, GetOriginalToken() as JArray);
        }
    }
}
