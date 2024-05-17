using Newtonsoft.Json.Linq;
using System.Globalization;

namespace TweakMaker
{
    public class DumpData
    {
        public readonly Dictionary<string, JObject> items;
        public readonly Dictionary<string, JObject> elements;
        public readonly Dictionary<string, JObject> buildings;
        public readonly Dictionary<string, JObject> recipes;
        public readonly Dictionary<string, JObject> researches;
        public readonly Dictionary<string, JObject> blastFurnaceModes;
        public readonly Dictionary<string, JObject> assemblyLineObjects;
        public readonly Dictionary<string, JObject> terrainBlocks;
        public readonly Dictionary<string, JObject> reservoirs;
        public readonly Dictionary<string, Image?> icons;

        public DumpData()
        {
            items = [];
            elements = [];
            buildings = [];
            recipes = [];
            researches = [];
            blastFurnaceModes = [];
            assemblyLineObjects = [];
            terrainBlocks = [];
            reservoirs = [];
            icons = [];
        }

        public static string GetTemplateName(Dictionary<string, JObject> templates, string identifier)
        {
            if (templates.TryGetValue(identifier, out var template) && template.TryGetValue("name", out var name)) return name.ToString();

            return new CultureInfo("en").TextInfo.ToTitleCase((identifier.StartsWith("_base_") ? identifier[6..] : identifier).ToLower().Replace("_", " "));
        }

        public string GetItemName(string identifier) => GetTemplateName(items, identifier);
        public string GetElementName(string identifier) => GetTemplateName(elements, identifier);
        public string GetResearchName(string identifier) => GetTemplateName(researches, identifier);
        public string GetBlastFurnaceModeName(string identifier) => GetTemplateName(blastFurnaceModes, identifier);
        public string GetAssemblyLineObjectName(string identifier) => GetTemplateName(assemblyLineObjects, identifier);
        public string GetTerrainBlockName(string identifier) => GetTemplateName(terrainBlocks, identifier);
        public string GetReservoirName(string identifier) => GetTemplateName(reservoirs, identifier);
    }
}
