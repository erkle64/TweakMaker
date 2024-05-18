using Newtonsoft.Json.Linq;

namespace TweakMaker.ValueEditors
{
    public class ValueEditorColor : ValueEditor
    {
        private Panel? _colorPanel;
        private bool _hasChanged = false;

        public override JToken? GetNewToken()
        {
            var original = GetOriginalToken();
            if (!_hasChanged) return original;

            var color = _colorPanel!.BackColor;
            var r = (object)(MathF.Round((float)(color.R / 255.0f) * 10000000.0f) / 10000000.0f);
            var g = (object)(MathF.Round((float)(color.G / 255.0f) * 10000000.0f) / 10000000.0f);
            var b = (object)(MathF.Round((float)(color.B / 255.0f) * 10000000.0f) / 10000000.0f);
            var a = (object)(MathF.Round((float)(color.A / 255.0f) * 10000000.0f) / 10000000.0f);

            if (original?["r"]?.Type == JTokenType.Integer && (float)r == (int)(float)r) r = (int)(float)r;
            if (original?["g"]?.Type == JTokenType.Integer && (float)g == (int)(float)g) g = (int)(float)g;
            if (original?["b"]?.Type == JTokenType.Integer && (float)b == (int)(float)b) b = (int)(float)b;
            if (original?["a"]?.Type == JTokenType.Integer && (float)a == (int)(float)a) a = (int)(float)a;

            return new JObject
            {
                { "r", new JValue(r) },
                { "g", new JValue(g) },
                { "b", new JValue(b) },
                { "a", new JValue(a) }
            };
        }

        public override void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            base.InitializeComponents(table, rowIndex);

            _colorPanel = new();
            table.Controls.Add(_colorPanel, 1, rowIndex);

            _colorPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            _colorPanel.Name = $"Color_{_labelText}";
            _colorPanel.TabIndex = rowIndex + 1;
            _colorPanel.BorderStyle = BorderStyle.FixedSingle;
            _colorPanel.Height = 40;
            _colorPanel.Width = 100;
            _colorPanel.BackColor = Color.Magenta;
            _colorPanel.Click += colorPanel_Click;
            if (GetOriginalToken() is JObject original)
            {
                var r = original["r"]?.Value<float>() ?? 1.0f;
                var g = original["g"]?.Value<float>() ?? 1.0f;
                var b = original["b"]?.Value<float>() ?? 1.0f;
                var a = original["a"]?.Value<float>() ?? 1.0f;
                _colorPanel.BackColor = Color.FromArgb((int)(a * 255), (int)(r * 255), (int)(g * 255), (int)(b * 255));
            }
            else
            {
                _colorPanel.BackColor = Color.White;
            }
        }

        private void colorPanel_Click(object? sender, EventArgs e)
        {
            var colorPicker = new ColorDialog
            {
                Color = _colorPanel!.BackColor,
                AnyColor = true,
                SolidColorOnly = false
            };
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                _colorPanel!.BackColor = colorPicker.Color;
                _hasChanged = true;
            }
        }
    }
}
