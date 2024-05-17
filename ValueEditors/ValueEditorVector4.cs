using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorVector4 : ValueEditor
    {
        private Vector4Control? _vector4Control;

        public override JToken? GetNewToken()
        {
            var x = (object)_vector4Control!.X;
            var y = (object)_vector4Control!.Y;
            var z = (object)_vector4Control!.Z;
            var w = (object)_vector4Control!.W;

            var original = GetOriginalToken();
            if (original?["x"]?.Type == JTokenType.Integer && (float)x == (int)(float)x) x = (int)(float)x;
            if (original?["y"]?.Type == JTokenType.Integer && (float)y == (int)(float)y) y = (int)(float)y;
            if (original?["z"]?.Type == JTokenType.Integer && (float)z == (int)(float)z) z = (int)(float)z;
            if (original?["w"]?.Type == JTokenType.Integer && (float)w == (int)(float)w) w = (int)(float)w;

            return new JObject
            {
                { "x", new JValue(x) },
                { "y", new JValue(y) },
                { "z", new JValue(z) },
                { "w", new JValue(w) }
            };
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _vector4Control = new();
            table.Controls.Add(_vector4Control, 1, rowIndex);

            _vector4Control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _vector4Control.Name = $"Vector4_{_labelText}";
            _vector4Control.TabIndex = rowIndex + 1;
            var original = GetOriginalToken() as JObject;
            if (original != null)
            {
                _vector4Control.X = original["x"]?.Value<float>() ?? 0.0f;
                _vector4Control.Y = original["y"]?.Value<float>() ?? 0.0f;
                _vector4Control.Z = original["z"]?.Value<float>() ?? 0.0f;
                _vector4Control.W = original["w"]?.Value<float>() ?? 1.0f;
            }
        }
    }
}
