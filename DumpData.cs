using Newtonsoft.Json.Linq;

namespace TweakMaker
{
    public class DumpData
    {
        public readonly Dictionary<string, JObject> items;
        public readonly Dictionary<string, JObject> fluids;
        public readonly Dictionary<string, JObject> buildings;
        public readonly Dictionary<string, JObject> recipes;
        public readonly Dictionary<string, Image?> icons;

        public DumpData()
        {
            items = [];
            fluids = [];
            buildings = [];
            recipes = [];
            icons = [];
        }

        public string GetItemName(string identifier)
        {
            if (items.TryGetValue(identifier, out var item) && item.TryGetValue("name", out var name)) return name.ToString();
            return string.Empty;
        }

        public string GetFluidName(string identifier)
        {
            if (fluids.TryGetValue(identifier, out var fluid) && fluid.TryGetValue("name", out var name)) return name.ToString();
            return string.Empty;
        }
    }
}
