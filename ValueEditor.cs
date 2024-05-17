using Newtonsoft.Json.Linq;

namespace TweakMaker
{
    public abstract class ValueEditor
    {
        protected string _labelText = string.Empty;
        protected JObject _template = [];
        protected string _key = string.Empty;
        protected DumpData _dump = new();
        protected string[] _extraValues = [];

        private Label? _label;

        public string Key => _key;

        public T? GetOriginalValue<T>()
        {
            return _template.TryGetValue(_key, out var value) && value != null ? value.Value<T>() : default;
        }

        public JToken? GetOriginalToken()
        {
            return _template[_key];
        }

        public abstract JToken? GetNewToken();

        public void Initialize(string labelText, JObject template, string key, DumpData dump, string[] extraValues)
        {
            _labelText = labelText;
            _template = template;
            _key = key;
            _dump = dump;
            _extraValues = extraValues;
        }

        public virtual void InitializeComponents(TableLayoutPanel table, int rowIndex)
        {
            _label = new();
            table.Controls.Add(_label, 0, rowIndex);

            _label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _label.TextAlign = ContentAlignment.MiddleRight;
            _label.Text = _labelText;
            _label.AutoSize = true;
        }
    }
}
