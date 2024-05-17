using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorBlastFurnaceModeIdentifier : ValueEditor
    {
        private TemplateIdentifierControl? _templateIdentifierControl;

        public override JToken? GetNewToken()
        {
            return new JValue(_templateIdentifierControl?.Identifier ?? string.Empty);
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _templateIdentifierControl = new(_dump.blastFurnaceModes.Values);
            table.Controls.Add(_templateIdentifierControl, 1, rowIndex);

            _templateIdentifierControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _templateIdentifierControl.Name = $"BlastFurnaceModeIdentifier_{_labelText}";
            _templateIdentifierControl.TabIndex = rowIndex + 1;
            _templateIdentifierControl.Identifier = GetOriginalValue<string>() ?? string.Empty;
        }
    }
}
