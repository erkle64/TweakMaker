using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorIconIdentifier : ValueEditor
    {
        private IconIdentifierControl? _iconIdentifierControl;

        public override JToken? GetNewToken()
        {
            return new JValue(_iconIdentifierControl?.IconIdentifier ?? string.Empty);
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _iconIdentifierControl = new(_dump);
            table.Controls.Add(_iconIdentifierControl, 1, rowIndex);

            _iconIdentifierControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _iconIdentifierControl.Name = $"IconIdentifier_{_labelText}";
            _iconIdentifierControl.TabIndex = rowIndex + 1;
            _iconIdentifierControl.IconIdentifier = GetOriginalValue<string>() ?? string.Empty;
        }
    }
}
