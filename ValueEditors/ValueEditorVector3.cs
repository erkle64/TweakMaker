using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorVector3 : ValueEditor
    {
        private Vector3Control? _vector3Control;

        public override JToken? GetNewToken()
        {
            var x = (object)_vector3Control!.X;
            var y = (object)_vector3Control!.Y;
            var z = (object)_vector3Control!.Z;

            var original = GetOriginalToken();
            if (original?["x"]?.Type == JTokenType.Integer && (float)x == (int)(float)x) x = (int)(float)x;
            if (original?["y"]?.Type == JTokenType.Integer && (float)y == (int)(float)y) y = (int)(float)y;
            if (original?["z"]?.Type == JTokenType.Integer && (float)z == (int)(float)z) z = (int)(float)z;

            return new JObject
            {
                { "x", new JValue(x) },
                { "y", new JValue(y) },
                { "z", new JValue(z) }
            };
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _vector3Control = new();
            table.Controls.Add(_vector3Control, 1, rowIndex);

            _vector3Control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _vector3Control.Name = $"Vector3_{_labelText}";
            _vector3Control.TabIndex = rowIndex + 1;
            if (GetOriginalToken() is JObject original)
            {
                _vector3Control.X = original["x"]?.Value<float>() ?? 0.0f;
                _vector3Control.Y = original["y"]?.Value<float>() ?? 0.0f;
                _vector3Control.Z = original["z"]?.Value<float>() ?? 0.0f;
            }
        }
    }
}
