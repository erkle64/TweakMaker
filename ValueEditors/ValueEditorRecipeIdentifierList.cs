using Newtonsoft.Json.Linq;
using TweakMaker.Controls;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorRecipeIdentifierList : ValueEditor
    {
        private TemplateIdentifierListControl? _templateIdentifierListControl;

        public override JToken? GetNewToken()
        {
            return _templateIdentifierListControl?.BuildData();
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _templateIdentifierListControl = new(_dump, "recipes");
            table.Controls.Add(_templateIdentifierListControl, 1, rowIndex);

            _templateIdentifierListControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _templateIdentifierListControl.Name = $"RecipeIdentifierList_{_labelText}";
            _templateIdentifierListControl.TabIndex = rowIndex + 1;
            _templateIdentifierListControl.LoadData(GetOriginalToken() as JArray);
        }
    }
}
