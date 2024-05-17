using TweakMaker.ValueEditors;

namespace TweakMaker
{
    public static class Templates
    {
        public struct Field(Type editor, string label, string identifier)
        {
            public Type editor = editor;
            public string label = label;
            public string identifier = identifier;
        }

        public static readonly Field[] recipe = [
            new Field(typeof(ValueEditorString), "Mod Identifier", "modIdentifier"),
            new Field(typeof(ValueEditorString), "Name", "name"),
            new Field(typeof(ValueEditorIconIdentifier), "Icon Identifier", "icon_identifier"),
            new Field(typeof(ValueEditorString), "Category Identifier", "category_identifier"),
            new Field(typeof(ValueEditorString), "Row Group Identifier", "rowGroup_identifier"),
            new Field(typeof(ValueEditorBoolean), "Is Hidden In Crafting Frame", "isHiddenInCharacterCraftingFrame"),
            new Field(typeof(ValueEditorBoolean), "Is Hidden By Narrative Trigger", "isHiddenByNarrativeTrigger"),
            new Field(typeof(ValueEditorBoolean), "Is Never Unseen Recipe", "isNeverUnseenRecipe"),
            new Field(typeof(ValueEditorString), "Narrative Trigger", "narrativeTrigger"),
            new Field(typeof(ValueEditorRecipeInputs), "Item Inputs", "input_data"),
            new Field(typeof(ValueEditorRecipeOutputs), "Item Outputs", "output_data"),
            new Field(typeof(ValueEditorRecipeInputFluids), "Fluid Inputs", "inputElemental_data"),
            new Field(typeof(ValueEditorRecipeOutputFluids), "Fluid Outputs", "outputElemental_data"),
            new Field(typeof(ValueEditorItemIdentifier), "Related Item Template Identifier", "relatedItemTemplateIdentifier"),
            new Field(typeof(ValueEditorInteger), "Sorting Order In Row Group", "sortingOrderWithinRowGroup"),
            new Field(typeof(ValueEditorInteger), "Crafting Time(milliseconds)", "timeMs"),
            new Field(typeof(ValueEditorStringList), "tags", "tags"),
            new Field(typeof(ValueEditorBoolean), "Force Show Outputs In Tooltips", "forceShowOutputsAtTooltips"),
            new Field(typeof(ValueEditorStringMultiline), "Extra Info Tooltip Text", "extraInfoTooltipText"),
        ];
    }
}
