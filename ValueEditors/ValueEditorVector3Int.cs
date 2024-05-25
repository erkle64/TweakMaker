using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorVector3Int : ValueEditor
    {
        private Vector3IntControl? _vector3IntControl;

        public override JToken? GetNewToken()
        {
            return new JObject
            {
                { "x", new JValue(_vector3IntControl!.X) },
                { "y", new JValue(_vector3IntControl!.Y) },
                { "z", new JValue(_vector3IntControl!.Z) }
            };
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _vector3IntControl = new();
            table.Controls.Add(_vector3IntControl, 1, rowIndex);

            _vector3IntControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _vector3IntControl.Name = $"Vector3Int_{_labelText}";
            _vector3IntControl.TabIndex = rowIndex + 1;
            if (GetOriginalToken() is JObject original)
            {
                _vector3IntControl.X = original["x"]?.Value<int>() ?? 0;
                _vector3IntControl.Y = original["y"]?.Value<int>() ?? 0;
                _vector3IntControl.Z = original["z"]?.Value<int>() ?? 0;
            }
        }
    }
}
