using Newtonsoft.Json.Linq;
using System.Globalization;

namespace TweakMaker
{
    public class DumpData(DumpData? parent = null)
    {
        private readonly DumpData? _parent = parent;
        private readonly Dictionary<string, Dictionary<string, JObject>> _templates = [];
        private readonly Dictionary<string, Image?> _icons = [];

        public DumpData? Parent => _parent;
        public Dictionary<string, JObject> Items => GetOrCreateTemplateMap("items");
        public Dictionary<string, JObject> Elements => GetOrCreateTemplateMap("elements");
        public Dictionary<string, JObject> Buildings => GetOrCreateTemplateMap("buildings");
        public Dictionary<string, JObject> Recipes => GetOrCreateTemplateMap("recipes");
        public Dictionary<string, JObject> Researches => GetOrCreateTemplateMap("research");
        public Dictionary<string, JObject> BlastFurnaceModes => GetOrCreateTemplateMap("blastFurnaceModes");
        public Dictionary<string, JObject> AssemblyLineObjects => GetOrCreateTemplateMap("assemblyLineObjects");
        public Dictionary<string, JObject> TerrainBlocks => GetOrCreateTemplateMap("terrain");
        public Dictionary<string, JObject> Reservoirs => GetOrCreateTemplateMap("reservoirs");
        public Dictionary<string, Image?> Icons => _icons;

        public void Clear()
        {
            _templates.Clear();
            _icons.Clear();
        }

        public bool HasIdentifier(string category, string identifier)
        {
            if (_templates.TryGetValue(category, out var items) && items.ContainsKey(identifier)) return true;
            return _parent?.HasIdentifier(category, identifier) ?? false;
        }

        public Dictionary<string, JObject> GetOrCreateTemplateMap(string category)
        {
            if (_templates.TryGetValue(category, out var items)) return items;
            var templateMap = new Dictionary<string, JObject>();
            _templates.Add(category, templateMap);
            return templateMap;
        }

        public JObject? GetTemplate(string category, string identifier)
        {
            if (_templates.TryGetValue(category, out var templateMap)
                && templateMap.TryGetValue(identifier, out var template))
            {
                return template;
            }

            return _parent?.GetTemplate(category, identifier);
        }

        public JToken? GetTemplateField(string category, string identifier, string field)
        {
            if (_templates.TryGetValue(category, out var templateMap)
                && templateMap.TryGetValue(identifier, out var template)
                && template.TryGetValue(field, out var fieldToken) && fieldToken != null)
            {
                return fieldToken;
            }

            return _parent?.GetTemplateField(category, identifier, field);
        }

        public T? GetTemplateValue<T>(string category, string identifier, string field)
        {
            if (_templates.TryGetValue(category, out var templateMap)
                && templateMap.TryGetValue(identifier, out var template)
                && template.TryGetValue(field, out var fieldToken) && fieldToken != null)
            {
                return fieldToken.Value<T>();
            }

            return _parent != null ? _parent.GetTemplateValue<T>(category, identifier, field) : default;
        }

        public string GetTemplateName(string category, string identifier)
        {
            var name = GetTemplateValue<string>(category, identifier, "name");
            if (!string.IsNullOrEmpty(name)) return name;
            return new CultureInfo("en").TextInfo.ToTitleCase((identifier.StartsWith("_base_") ? identifier[6..] : identifier).ToLower().Replace("_", " ")); ;
        }

        public Dictionary<string, JObject> Flatten(string category)
        {
            var dictionary = new Dictionary<string, JObject>();
            Flatten(category, dictionary);
            return dictionary;
        }

        private void Flatten(string category, Dictionary<string, JObject> dictionary)
        {
            _parent?.Flatten(category, dictionary);

            if (_templates.TryGetValue(category, out var templateMap))
            {
                foreach (var kv in templateMap)
                {
                    if (kv.Value != null)
                    {
                        if (dictionary.TryGetValue(kv.Key, out var existing))
                        {
                            existing.Merge(kv.Value, new JsonMergeSettings
                            {
                                MergeArrayHandling = MergeArrayHandling.Replace,
                                MergeNullValueHandling = MergeNullValueHandling.Ignore,
                                PropertyNameComparison = StringComparison.InvariantCulture
                            });
                        }
                        else
                        {
                            dictionary.Add(kv.Key, (JObject)kv.Value.DeepClone());
                        }
                    }
                }
            }
        }

        public JObject? Flatten(string category, string identifier)
        {
            JObject? flattened = null;
            Flatten(category, identifier, ref flattened);
            return flattened;
        }

        private void Flatten(string category, string identifier, ref JObject? flattened)
        {
            _parent?.Flatten(category, identifier, ref flattened);

            if (_templates.TryGetValue(category, out var templateMap) && templateMap.TryGetValue(identifier, out var template))
            {
                if (flattened == null)
                {
                    flattened = (JObject)template.DeepClone();
                }
                else
                {
                    flattened.Merge(template, new JsonMergeSettings
                    {
                        MergeArrayHandling = MergeArrayHandling.Replace,
                        MergeNullValueHandling = MergeNullValueHandling.Ignore,
                        PropertyNameComparison = StringComparison.InvariantCulture
                    });
                }
            }
        }

        public string GetItemName(string identifier) => GetTemplateName("items", identifier);
        public string GetElementName(string identifier) => GetTemplateName("elements", identifier);
        public string GetResearchName(string identifier) => GetTemplateName("research", identifier);
        public string GetBlastFurnaceModeName(string identifier) => GetTemplateName("blastFurnaceModes", identifier);
        public string GetAssemblyLineObjectName(string identifier) => GetTemplateName("assemblyLineObjects", identifier);
        public string GetTerrainBlockName(string identifier) => GetTemplateName("terrain", identifier);
        public string GetReservoirName(string identifier) => GetTemplateName("reservoirs", identifier);

        public bool IsEmpty(string dumpCategory)
        {
            if (_templates.TryGetValue(dumpCategory, out var templateMap) && templateMap.Count != 0) return false;
            return _parent?.IsEmpty(dumpCategory) ?? true;
        }
    }
}
