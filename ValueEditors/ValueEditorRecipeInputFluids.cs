using Newtonsoft.Json.Linq;
using TweakMaker.Controls;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorRecipeInputFluids : ValueEditor
    {
        private RecipeFluidControl? _recipeFluidControl;

        public override JToken? GetNewToken()
        {
            return _recipeFluidControl?.BuildData();
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _recipeFluidControl = new();
            table.Controls.Add(_recipeFluidControl, 1, rowIndex);

            _recipeFluidControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _recipeFluidControl.Name = $"FluidInput_{_labelText}";
            _recipeFluidControl.TabIndex = rowIndex + 1;
            _recipeFluidControl.LoadData(_dump, GetOriginalToken() as JObject);
        }
    }
}
