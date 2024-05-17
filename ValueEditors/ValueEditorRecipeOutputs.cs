using Newtonsoft.Json.Linq;
using TweakMaker.Controls;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorRecipeOutputs : ValueEditor
    {
        private RecipeItemControl? _recipeItemControl;

        public override JToken? GetNewToken()
        {
            return _recipeItemControl?.BuildData(true);
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _recipeItemControl = new();
            table.Controls.Add(_recipeItemControl, 1, rowIndex);

            _recipeItemControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _recipeItemControl.Name = $"ItemOutputs_{_labelText}";
            _recipeItemControl.TabIndex = rowIndex + 1;
            _recipeItemControl.LoadData(_dump, GetOriginalToken() as JObject, true);
        }
    }
}
