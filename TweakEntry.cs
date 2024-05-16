using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace TweakMaker
{
    internal abstract class TweakEntry(TweakEntry? parent, string key, JToken? token)
    {
        public TweakEntry? Parent => parent;
        public string Key => key;
        public JToken? Token => token;

        public int Depth
        {
            get
            {
                int depth = 0;
                var current = Parent;
                while (current != null)
                {
                    depth++;
                    current = current.Parent;
                }
                return depth;
            }
        }

        public abstract bool isExpandable { get; }
        public abstract IList<TweakEntry> children { get; }

        public virtual void DeleteChild(TweakEntry child)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            Debug.Assert(Parent != null);
            Parent.DeleteChild(this);
        }
    }

    internal class TweakEntryObject(TweakEntry? parent, string key, JToken? token) : TweakEntry(parent, key, token)
    {
        private readonly IList<TweakEntry> _children = [];

        public override bool isExpandable => true;
        public override IList<TweakEntry> children => _children;

        public override void DeleteChild(TweakEntry child)
        {
            var jobject = Token as JObject;
            Debug.Assert(jobject != null);
            jobject.Remove(child.Key);
            _children.Remove(child);
        }
    }

    internal class TweakEntryArray(TweakEntry? parent, string key, JToken? token) : TweakEntry(parent, key, token)
    {
        private readonly IList<TweakEntry> _children = [];

        public override bool isExpandable => true;
        public override IList<TweakEntry> children => _children;

        public override void DeleteChild(TweakEntry child)
        {
            var jarray = Token as JArray;
            Debug.Assert(jarray != null);
            Debug.Assert(child.Token != null);
            jarray.Remove(child.Token);
            _children.Remove(child);
        }
    }

    internal class TweakEntryValue<T>(TweakEntry? parent, string key, T value, JToken? token) : TweakEntry(parent, key, token)
    {
        private T _value = value;

        public T Value { get => _value; set => _value = value; }
        public override bool isExpandable => false;
        public override IList<TweakEntry> children => throw new NotImplementedException();
    }
}
