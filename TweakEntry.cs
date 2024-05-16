namespace TweakMaker
{
    internal abstract class TweakEntry
    {
        private string _key;

        public string Key => _key;

        public abstract bool isExpandable { get; }
        public abstract IList<TweakEntry> children { get; }

        protected TweakEntry(string key)
        {
            _key = key;
        }
    }

    internal class TweakEntryObject : TweakEntry
    {
        private IList<TweakEntry> _children;

        public override bool isExpandable => true;
        public override IList<TweakEntry> children => _children;

        public TweakEntryObject(string key) : base(key)
        {
            _children = new List<TweakEntry>();
        }
    }

    internal class TweakEntryArray : TweakEntry
    {
        private IList<TweakEntry> _children;

        public override bool isExpandable => true;
        public override IList<TweakEntry> children => _children;

        public TweakEntryArray(string key) : base(key)
        {
            _children = new List<TweakEntry>();
        }
    }

    internal class TweakEntryValue<T> : TweakEntry
    {
        private T _value;

        public T Value { get => _value; set => _value = value; }
        public override bool isExpandable => false;
        public override IList<TweakEntry> children => throw new NotImplementedException();

        public TweakEntryValue(string key, T value) : base(key)
        {
            _value = value;
        }
    }
}
