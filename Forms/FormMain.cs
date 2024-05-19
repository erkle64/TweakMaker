using BlueMystic;
using BrightIdeasSoftware;
using Narod.SteamGameFinder;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using TweakMaker.Dialogs;

namespace TweakMaker
{
    public partial class FormMain : Form
    {
        private const string dumpPathBuildings = @"tweakificator\Dumps\Buildings";
        private const string dumpPathItems = @"tweakificator\Dumps\Items";
        private const string dumpPathElements = @"tweakificator\Dumps\Elements";
        private const string dumpPathRecipes = @"tweakificator\Dumps\Recipes";
        private const string dumpPathResearch = @"tweakificator\Dumps\Research";
        private const string dumpPathBlastFurnaceModes = @"tweakificator\Dumps\BlastFurnaceModes";
        private const string dumpPathAssemblyLineObjects = @"tweakificator\Dumps\AssemblyLineObjects";
        private const string dumpPathTerrainBlocks = @"tweakificator\Dumps\TerrainBlocks";
        private const string dumpPathReservoirs = @"tweakificator\Dumps\Reservoirs";
        private const string dumpPathIconsList = @"tweakificator\Dumps\Icons\__icons.txt";
        private const string dumpPathIcons = @"tweakificator\Dumps\Icons";
        private const string missingDumpText = @"Tweakificator dumps required.
How to generate dump:
1. Install Tweakificator v2.0.2+
2. Run FOUNDRY to the title screen at least once
3. Set the dumpTemplates value to true in Config\erkle64.Tweakificator.ini
4. Run FOUNDRY to the title screen again
5. Open TweakMaker again";

        private TweakEntryObject? _treeRoot = null;
        private JObject _jsonRoot;

        private readonly DumpData _dump;
        private readonly DumpData _tweakAdditionsDump;
        private readonly DumpData _tweakChangesDump;
        private readonly FormProgress _progressBox;
        private readonly DarkModeCS _darkMode;
        private readonly string _baseTitle = string.Empty;
        private string _currentTweakPath = string.Empty;
        private bool _isTweakChanged = false;

        private readonly int[] _iconSizes = [
                256, 512, 0, 64, 96, 128
            ];

        public FormMain()
        {
            InitializeComponent();

            _darkMode = new DarkModeCS(this);
            if (_darkMode.IsDarkMode)
            {
                treeViewTweak.AlternateRowBackColor = Color.FromArgb(68, 68, 68);
            }

            _baseTitle = Text;

            _dump = new();
            _tweakChangesDump = new(_dump);
            _tweakAdditionsDump = new(_tweakChangesDump);

            _progressBox = new FormProgress();

            if (string.IsNullOrEmpty(inputFoundryPath.Text))
            {
                var steamGameLocator = new SteamGameLocator();
                if (steamGameLocator.getIsSteamInstalled())
                {
                    var gameInfo = steamGameLocator.getGameInfoByFolder("FOUNDRY");
                    if (!string.IsNullOrEmpty(gameInfo.steamGameLocation))
                    {
                        SetFoundryPath(gameInfo.steamGameLocation.Replace(@"\\", @"\"));
                    }
                }
            }

            treeViewTweak.CanExpandGetter = delegate (object x)
            {
                return (x as TweakEntry)?.isExpandable ?? false;
            };

            treeViewTweak.ChildrenGetter = delegate (object x)
            {
                return (x as TweakEntry)?.children;
            };

            columnHeaderKeys.FreeSpaceProportion = 4;
            columnHeaderValues.FreeSpaceProportion = 3;

            _jsonRoot = [];
            _treeRoot = new TweakEntryObject(null, "tweak", _jsonRoot);
            BuildTreeView(_jsonRoot, _treeRoot);
            treeViewTweak.Roots = new TweakEntry[] { _treeRoot };
            treeViewTweak.ExpandAll();
            BuildTweakDump();
        }

        private void SetFoundryPath(string path)
        {
            inputFoundryPath.Text = path;

            if (!string.IsNullOrEmpty(path))
            {
                newToolStripMenuItem.Enabled = false;
                openToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                changeToolStripMenuItem.Enabled = false;
                addToolStripMenuItem.Enabled = false;
                treeViewTweak.Enabled = false;

                if (!Directory.Exists(Path.Combine(inputFoundryPath.Text, dumpPathBuildings))
                    || !Directory.Exists(Path.Combine(inputFoundryPath.Text, dumpPathItems))
                    || !Directory.Exists(Path.Combine(inputFoundryPath.Text, dumpPathRecipes))
                    || !Directory.Exists(Path.Combine(inputFoundryPath.Text, dumpPathResearch))
                    || !Directory.Exists(Path.Combine(inputFoundryPath.Text, dumpPathElements))
                    || !Directory.Exists(Path.Combine(inputFoundryPath.Text, dumpPathReservoirs))
                    || !Directory.Exists(Path.Combine(inputFoundryPath.Text, dumpPathBlastFurnaceModes))
                    || !Directory.Exists(Path.Combine(inputFoundryPath.Text, dumpPathBuildings))
                    || !Directory.Exists(Path.Combine(inputFoundryPath.Text, dumpPathTerrainBlocks))
                    || !Directory.Exists(Path.Combine(inputFoundryPath.Text, dumpPathIcons))
                    || !File.Exists(Path.Combine(inputFoundryPath.Text, dumpPathIconsList)))
                {
                    Messenger.MessageBox(missingDumpText, "Missing Dumps!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                newToolStripMenuItem.Enabled = true;
                openToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                changeToolStripMenuItem.Enabled = true;
                addToolStripMenuItem.Enabled = true;
                treeViewTweak.Enabled = true;

                menuStripMain.Enabled = false;
                panelOuter.Enabled = false;
                treeViewTweak.Visible = false;
                _progressBox.Show(this);
                _progressBox.Location = new Point(
                    Location.X + Width / 2 - _progressBox.ClientSize.Width / 2,
                    Location.Y + Height / 2 - _progressBox.ClientSize.Height / 2
                    );

                openFileDialog.InitialDirectory = Path.Combine(inputFoundryPath.Text, "tweaks");
                saveAsFileDialog.InitialDirectory = Path.Combine(inputFoundryPath.Text, "tweaks");

                var progress = new Progress<FormProgress.ProgressInfo>(progressInfo =>
                {
                    _progressBox.SetProgress(progressInfo);
                    if (progressInfo.done)
                    {
                        menuStripMain.Enabled = true;
                        panelOuter.Enabled = true;
                        treeViewTweak.Visible = true;
                        _progressBox.Close();
                    }
                });
                Task.Run(() => LoadDumpData(_progressBox.cancellationTokenSource.Token, progress), _progressBox.cancellationTokenSource.Token);
            }
        }

        private void LoadDumpData(CancellationToken cancellationToken, IProgress<FormProgress.ProgressInfo> progress)
        {
            _dump.Buildings.Clear();
            var buildingFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, dumpPathBuildings));
            var progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading buildings...",
                step = 0,
                maximum = buildingFilePaths.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var filePath in buildingFilePaths)
            {
                if (cancellationToken.IsCancellationRequested) return;

                var json = JObject.Parse(File.ReadAllText(filePath));
                if (json.ContainsKey("identifier"))
                {
                    _dump.Buildings[json["identifier"]!.ToString()] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.Items.Clear();
            var itemFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, dumpPathItems));
            progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading items...",
                step = 0,
                maximum = itemFilePaths.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var filePath in itemFilePaths)
            {
                if (cancellationToken.IsCancellationRequested) return;

                var json = JObject.Parse(File.ReadAllText(filePath));
                if (json.ContainsKey("identifier") && !(json["skipForRunningIdxGeneration"]?.Value<bool>() ?? false))
                {
                    _dump.Items[json["identifier"]!.ToString()] = json;

                    if ((json["flags"]?.ToString() ?? "").Contains("BUILDABLE_OBJECT"))
                    {
                        {
                            var bot = json["buildableObjectIdentifer"]?.ToString() ?? "";
                            if (!string.IsNullOrEmpty(bot) && _dump.Buildings.TryGetValue(bot, out JObject? value) && value is JObject botObject)
                            {
                                if (!botObject.ContainsKey("name")) botObject.Add("name", json["name"]);
                            }
                        }

                        if (json["toggleableModes"] is JObject modes)
                        {
                            foreach (var mode in modes)
                            {
                                if (mode.Value is JObject modeObject && modeObject.TryGetValue("name", out var nameToken) && nameToken is JValue nameValue)
                                {
                                    var modeName = nameValue.ToString();
                                    var bot = mode.Key;
                                    if (!string.IsNullOrEmpty(bot) && _dump.Buildings.TryGetValue(bot, out JObject? value) && value is JObject botObject)
                                    {
                                        if (!botObject.ContainsKey("name"))
                                        {
                                            botObject.Add("name", $"{json["name"]?.ToString()} ({modeName})");
                                        }
                                        else
                                        {
                                            botObject["name"] = $"{json["name"]?.ToString()} ({modeName})";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.Elements.Clear();
            var elementFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, dumpPathElements));
            progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading elements...",
                step = 0,
                maximum = elementFilePaths.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var filePath in elementFilePaths)
            {
                if (cancellationToken.IsCancellationRequested) return;

                var json = JObject.Parse(File.ReadAllText(filePath));
                if (json.ContainsKey("identifier"))
                {
                    _dump.Elements[json["identifier"]!.ToString()] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.Recipes.Clear();
            var recipeFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, dumpPathRecipes));
            progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading recipes...",
                step = 0,
                maximum = recipeFilePaths.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var filePath in recipeFilePaths)
            {
                if (cancellationToken.IsCancellationRequested) return;

                var json = JObject.Parse(File.ReadAllText(filePath));
                if (json.ContainsKey("identifier"))
                {
                    _dump.Recipes[json["identifier"]!.ToString()] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.Researches.Clear();
            var researchFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, dumpPathResearch));
            progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading researches...",
                step = 0,
                maximum = researchFilePaths.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var filePath in researchFilePaths)
            {
                if (cancellationToken.IsCancellationRequested) return;

                var json = JObject.Parse(File.ReadAllText(filePath));
                if (json.ContainsKey("identifier"))
                {
                    _dump.Researches[json["identifier"]!.ToString()] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.BlastFurnaceModes.Clear();
            var blastFurnaceModeFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, dumpPathBlastFurnaceModes));
            progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading blast furnace modes...",
                step = 0,
                maximum = blastFurnaceModeFilePaths.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var filePath in blastFurnaceModeFilePaths)
            {
                if (cancellationToken.IsCancellationRequested) return;

                var json = JObject.Parse(File.ReadAllText(filePath));
                if (json.ContainsKey("identifier"))
                {
                    _dump.BlastFurnaceModes[json["identifier"]!.ToString()] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.AssemblyLineObjects.Clear();
            var assemblyLineObjectFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, dumpPathAssemblyLineObjects));
            progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading assembly line objects...",
                step = 0,
                maximum = assemblyLineObjectFilePaths.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var filePath in assemblyLineObjectFilePaths)
            {
                if (cancellationToken.IsCancellationRequested) return;

                var json = JObject.Parse(File.ReadAllText(filePath));
                if (json.ContainsKey("identifier"))
                {
                    _dump.AssemblyLineObjects[json["identifier"]!.ToString()] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.TerrainBlocks.Clear();
            var terrainBlockFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, dumpPathTerrainBlocks));
            progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading assembly line objects...",
                step = 0,
                maximum = terrainBlockFilePaths.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var filePath in terrainBlockFilePaths)
            {
                if (cancellationToken.IsCancellationRequested) return;

                var json = JObject.Parse(File.ReadAllText(filePath));
                if (json.ContainsKey("identifier"))
                {
                    _dump.TerrainBlocks[json["identifier"]!.ToString()] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.Reservoirs.Clear();
            var reservoirFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, dumpPathReservoirs));
            progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading assembly line objects...",
                step = 0,
                maximum = reservoirFilePaths.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var filePath in reservoirFilePaths)
            {
                if (cancellationToken.IsCancellationRequested) return;

                var json = JObject.Parse(File.ReadAllText(filePath));
                if (json.ContainsKey("identifier"))
                {
                    _dump.Reservoirs[json["identifier"]!.ToString()] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.Icons.Clear();
            var iconNames = File.ReadAllLines(Path.Combine(inputFoundryPath.Text, dumpPathIconsList))
                .Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading icons...",
                step = 0,
                maximum = iconNames.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var iconName in iconNames)
            {
                if (cancellationToken.IsCancellationRequested) return;

                Image? image = null;
                var iconFile = Path.Combine(inputFoundryPath.Text, dumpPathIcons, $"{iconName}.png");
                if (File.Exists(iconFile))
                {
                    image = Image.FromFile(iconFile);
                }
                else
                {
                    foreach (var size in _iconSizes)
                    {
                        iconFile = Path.Combine(inputFoundryPath.Text, dumpPathIcons, $"{iconName}_{size}.png");
                        if (File.Exists(iconFile))
                        {
                            image = Image.FromFile(iconFile);
                            break;
                        }
                    }
                }

                if (image != null)
                {
                    image = ImageTools.ResizeImage(image, 256, 256);
                }

                _dump.Icons[iconName] = image;

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            progressInfo.done = true;
            progress.Report(progressInfo);
        }

        private void BuildTreeView(JObject jsonNode, TweakEntryObject treeNode)
        {
            foreach (var entry in jsonNode)
            {
                if (entry.Value != null)
                {
                    var tweakEntry = BuildTweakEntry(treeNode, entry.Key, entry.Value);
                    if (tweakEntry != null) treeNode.children.Add(tweakEntry);
                }
            }
        }

        private void BuildTreeView(JArray jsonNode, TweakEntryArray treeNode)
        {
            var index = 0;
            foreach (var entry in jsonNode)
            {
                if (entry != null)
                {
                    var tweakEntry = BuildTweakEntry(treeNode, index.ToString(), entry);
                    if (tweakEntry != null) treeNode.children.Add(tweakEntry);
                }
                index++;
            }
        }

        private TweakEntry? BuildTweakEntry(TweakEntry? parent, string key, JToken value)
        {
            if (value is JObject objectValue)
            {
                var childNode = new TweakEntryObject(parent, key, value);
                BuildTreeView(objectValue, childNode);
                return childNode;
            }
            else if (value is JArray arrayValue)
            {
                var childNode = new TweakEntryArray(parent, key, value);
                BuildTreeView(arrayValue, childNode);
                return childNode;
            }
            else
            {
                TweakEntry? childNode = null;
                switch (value?.Type ?? JTokenType.Null)
                {
                    case JTokenType.Null:
                    case JTokenType.Undefined:
                    case JTokenType.Date:
                    case JTokenType.Raw:
                    case JTokenType.Bytes:
                    case JTokenType.Guid:
                    case JTokenType.Uri:
                    case JTokenType.TimeSpan:
                    case JTokenType.Object:
                    case JTokenType.Array:
                    case JTokenType.Constructor:
                    case JTokenType.Property:
                    case JTokenType.None: throw new Exception("Invalid JTokenType");

                    case JTokenType.Comment: break;

                    case JTokenType.Integer:
                        childNode = new TweakEntryValue<int>(parent, key, value?.Value<int>() ?? 0, value);
                        break;

                    case JTokenType.Float:
                        childNode = new TweakEntryValue<float>(parent, key, value?.Value<float>() ?? 0.0f, value);
                        break;

                    case JTokenType.String:
                        childNode = new TweakEntryValue<string>(parent, key, value?.Value<string>() ?? "", value);
                        break;

                    case JTokenType.Boolean:
                        childNode = new TweakEntryValue<bool>(parent, key, value?.Value<bool>() ?? false, value);
                        break;
                }
                return childNode;
            }
        }

        private bool TryGetTweak(out JObject tweak, params string[] keys)
        {
            tweak = [];
            if (_jsonRoot == null) return false;
            var current = _jsonRoot;
            foreach (var key in keys)
            {
                if (!current.TryGetValue(key, out var next)) return false;
                if (next is not JObject nextObject) return false;
                current = nextObject;
            }
            tweak = current;
            return true;
        }

        private void SetTweak(JToken tweak, params string[] keys)
        {
            Debug.Assert(keys.Length > 0);
            _jsonRoot ??= [];
            var current = _jsonRoot;
            for (int i = 0; i < keys.Length - 1; i++)
            {
                string? key = keys[i];
                if (!current.TryGetValue(key, out var next))
                {
                    next = new JObject();
                    current[key] = next;
                }
                if (next is not JObject nextObject) throw new Exception("Invalid JTokenType");
                current = nextObject;
            }

            var lastKey = keys[^1];
            if (current.ContainsKey(lastKey))
            {
                current[lastKey] = tweak;
            }
            else
            {
                current.Add(lastKey, tweak);
            }
        }

        private void RemoveTweak(params string[] keys)
        {
            Debug.Assert(keys.Length > 0);
            _jsonRoot ??= [];
            var current = _jsonRoot;
            for (int i = 0; i < keys.Length - 1; i++)
            {
                string? key = keys[i];
                if (!current.TryGetValue(key, out var next))
                {
                    next = new JObject();
                    current[key] = next;
                }
                if (next is not JObject nextObject) throw new Exception("Invalid JTokenType");
                current = nextObject;
            }

            var lastKey = keys[^1];
            if (current.ContainsKey(lastKey))
            {
                current.Remove(lastKey);
            }
        }

        private void BeginChangeTemplate(string title, string category)
        {
            using var dialogSelectTemplate = new DialogSelectTemplate(title, _tweakChangesDump, category, string.Empty);
            if (dialogSelectTemplate.ShowDialog(this) == DialogResult.OK)
            {
                var identifier = dialogSelectTemplate.SelectedIdentifier;
                ChangeTemplate(category, identifier);
            }
        }

        private void BeginAddTemplate(string title, string category)
        {
            using var dialogSelectTemplate = new DialogSelectTemplate(title, _dump, category, string.Empty);
            if (dialogSelectTemplate.ShowDialog(this) == DialogResult.OK)
            {
                var templateIdentifier = dialogSelectTemplate.SelectedIdentifier;
                using var dialogChooseTemplateIdentifier = new DialogChooseTemplateIdentifier(_dump, category, "");
                if (dialogChooseTemplateIdentifier.ShowDialog(this) == DialogResult.OK)
                {
                    var identifier = dialogChooseTemplateIdentifier.SelectedIdentifier;
                    AddTemplate(category, identifier, string.Empty, templateIdentifier);
                }
            }
        }

        private void ChangeTemplate(string category, string identifier)
        {
            var originalTemplate = _tweakChangesDump.Flatten(category, identifier);
            Debug.Assert(originalTemplate != null);
            DoChange(identifier, originalTemplate, category);
        }

        private void AddTemplate(string category, string identifier, string previousIdentifier, string templateIdentifier)
        {
            var originalTemplate = _tweakChangesDump.Flatten(category, templateIdentifier);
            Debug.Assert(originalTemplate != null);

            var additionTemplate = _tweakAdditionsDump.Flatten(category, previousIdentifier);
            if (additionTemplate != null)
            {
                originalTemplate = (JObject)originalTemplate.DeepClone();
                originalTemplate.Merge(additionTemplate, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Replace,
                    MergeNullValueHandling = MergeNullValueHandling.Ignore,
                    PropertyNameComparison = StringComparison.InvariantCulture
                });
            }

            DoAddition(identifier, previousIdentifier, templateIdentifier, originalTemplate, category);
        }

        private void DoChange(string identifier, JObject originalTemplate, string category)
        {
            using var dialogEditTemplate = new DialogEditTemplate(originalTemplate, _tweakAdditionsDump, Templates.Get(category));
            if (dialogEditTemplate.ShowDialog(this) == DialogResult.OK)
            {
                var newTemplate = dialogEditTemplate.BuildTemplate();
                if (newTemplate.Count == 0) return;

                if (TryGetTweak(out var currentTemplate, "changes", category, identifier))
                {
                    currentTemplate.Merge(newTemplate, new JsonMergeSettings
                    {
                        MergeArrayHandling = MergeArrayHandling.Replace,
                        MergeNullValueHandling = MergeNullValueHandling.Ignore,
                        PropertyNameComparison = StringComparison.InvariantCulture
                    });
                    SetTweak(currentTemplate, "changes", category, identifier);
                }
                else
                {
                    SetTweak(newTemplate, "changes", category, identifier);
                }

                _treeRoot = new TweakEntryObject(null, "tweak", _jsonRoot);
                BuildTreeView(_jsonRoot, _treeRoot);
                treeViewTweak.Roots = new TweakEntry[] { _treeRoot };
                treeViewTweak.ExpandAll();
                BuildTweakDump();

                SetTweakChanged();
            }
        }

        private void DoAddition(string identifier, string previousIdentifier, string templateIdentifier, JObject originalTemplate, string category)
        {
            using var dialogEditTemplate = new DialogEditTemplate(originalTemplate, _tweakAdditionsDump, Templates.Get(category));
            if (dialogEditTemplate.ShowDialog(this) == DialogResult.OK)
            {
                var newTemplate = dialogEditTemplate.BuildTemplate();

                if (newTemplate.ContainsKey("__template"))
                    newTemplate["__template"] = new JValue(templateIdentifier);
                else
                    newTemplate.Add("__template", new JValue(templateIdentifier));

                if (TryGetTweak(out var currentTemplate, "additions", category, previousIdentifier))
                {
                    currentTemplate.Merge(newTemplate, new JsonMergeSettings
                    {
                        MergeArrayHandling = MergeArrayHandling.Replace,
                        MergeNullValueHandling = MergeNullValueHandling.Ignore,
                        PropertyNameComparison = StringComparison.InvariantCulture
                    });
                    SetTweak(currentTemplate, "additions", category, identifier);
                }
                else
                {
                    SetTweak(newTemplate, "additions", category, identifier);
                }

                if (identifier != previousIdentifier)
                {
                    RemoveTweak("additions", category, previousIdentifier);
                }

                _treeRoot = new TweakEntryObject(null, "tweak", _jsonRoot);
                BuildTreeView(_jsonRoot, _treeRoot);
                treeViewTweak.Roots = new TweakEntry[] { _treeRoot };
                treeViewTweak.ExpandAll();
                BuildTweakDump();

                SetTweakChanged();
            }
        }

        private void BuildTweakDump()
        {
            _tweakAdditionsDump.Clear();
            _tweakChangesDump.Clear();

            if (_jsonRoot is null) return;

            if (_jsonRoot.TryGetValue("additions", out var additionsToken) && additionsToken is JObject additions)
            {
                foreach (var kv in additions)
                {
                    if (kv.Value is JObject categories)
                    {
                        var dumpTemplates = _tweakAdditionsDump.GetOrCreateTemplateMap(kv.Key);
                        foreach (var kv2 in categories)
                        {
                            if (kv2.Value is JObject template) dumpTemplates.Add(kv2.Key, template);
                        }
                    }
                }
            }

            if (_jsonRoot.TryGetValue("changes", out var changesToken) && changesToken is JObject changes)
            {
                foreach (var kv in changes)
                {
                    if (kv.Value is JObject categories)
                    {
                        var dumpTemplates = _tweakChangesDump.GetOrCreateTemplateMap(kv.Key);
                        foreach (var kv2 in categories)
                        {
                            if (kv2.Value is JObject template) dumpTemplates.Add(kv2.Key, template);
                        }
                    }
                }
            }
        }

        private void SetTweakChanged()
        {
            Text = string.IsNullOrEmpty(_currentTweakPath)
                ? $"{_baseTitle} *"
                : $"{_baseTitle} - {Path.GetFileName(_currentTweakPath)} *";
            _isTweakChanged = true;
        }

        private bool AskForSaveIfChanged()
        {
            if (_isTweakChanged)
            {
                using (new CenterWinDialog(this))
                {
                    switch (Messenger.MessageBox("Do you want to save changes?", "Tweak Maker", MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.Cancel:
                            return false;

                        case DialogResult.Yes:
                            return Save();
                    }
                }
            }

            return true;
        }

        private bool Save()
        {
            if (string.IsNullOrEmpty(_currentTweakPath))
            {
                return SaveAs();
            }

            File.WriteAllText(_currentTweakPath, _jsonRoot.ToString());

            Text = $"{_baseTitle} - {Path.GetFileName(_currentTweakPath)}";
            _isTweakChanged = false;

            return true;
        }

        private bool SaveAs()
        {
            if (saveAsFileDialog.ShowDialog() == DialogResult.OK)
            {
                _currentTweakPath = saveAsFileDialog.FileName;
                File.WriteAllText(_currentTweakPath, _jsonRoot.ToString());

                Text = $"{_baseTitle} - {Path.GetFileName(_currentTweakPath)}";
                _isTweakChanged = false;

                return true;
            }

            return false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AskForSaveIfChanged()) return;

            _currentTweakPath = "";
            _jsonRoot = [];
            _treeRoot = new TweakEntryObject(null, "tweak", _jsonRoot);
            BuildTreeView(_jsonRoot, _treeRoot);
            treeViewTweak.Roots = new TweakEntry[] { _treeRoot };
            treeViewTweak.ExpandAll();
            BuildTweakDump();

            Text = _baseTitle;
            _isTweakChanged = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AskForSaveIfChanged()) return;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _currentTweakPath = openFileDialog.FileName;
                _jsonRoot = JObject.Parse(File.ReadAllText(_currentTweakPath));
                _treeRoot = new TweakEntryObject(null, "tweak", _jsonRoot);
                BuildTreeView(_jsonRoot, _treeRoot);
                treeViewTweak.Roots = new TweakEntry[] { _treeRoot };
                treeViewTweak.ExpandAll();
                BuildTweakDump();

                Text = $"{_baseTitle} - {Path.GetFileName(_currentTweakPath)}";
                _isTweakChanged = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (foundryFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetFoundryPath(Path.GetDirectoryName(foundryFileDialog.FileName) ?? "");
            }
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginChangeTemplate("Select Item", "items");
        }

        private void elementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginChangeTemplate("Select Element", "elements");
        }

        private void recipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginChangeTemplate("Select Recipe", "recipes");
        }

        private void researchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginChangeTemplate("Select Research", "research");
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginAddTemplate("Select Template Item", "items");
        }

        private void addFluidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginAddTemplate("Select Template Element (Fluid)", "elements");
        }

        private void addRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginAddTemplate("Select Template Recipe", "recipes");
        }

        private void addResearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginAddTemplate("Select Template Research", "research");
        }

        private void treeViewTweak_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (e.ColumnIndex != 0) return;
            if (e.Model is not TweakEntry tweakEntry) return;

            if (tweakEntry.Depth == 3 || tweakEntry.Depth == 4)
            {
                if (tweakEntry.Depth == 4 && tweakEntry.Key == "__template") return;

                contextMenuTweak.Tag = tweakEntry;
                contextMenuTweak.Show(treeViewTweak, new Point(e.Location.X, e.Location.Y));
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuTweak.Tag is not TweakEntry tweakEntry) return;

            if (tweakEntry.Depth == 4)
            {
                Debug.Assert(tweakEntry.Parent != null);
                tweakEntry = tweakEntry.Parent;
            }

            switch (tweakEntry.Parent?.Key)
            {
                case "items":
                case "elements":
                case "recipes":
                case "research":
                    switch (tweakEntry.Parent?.Parent?.Key)
                    {
                        case "changes":
                            ChangeTemplate(tweakEntry.Parent!.Key, tweakEntry.Key);
                            break;

                        case "additions":
                            {
                                var templateIdentifier = (tweakEntry.Token as JObject)?["__template"]?.ToString();
                                if (!string.IsNullOrEmpty(templateIdentifier))
                                {
                                    using var dialogChooseTemplateIdentifier = new DialogChooseTemplateIdentifier(_tweakChangesDump, "items", tweakEntry.Key);
                                    if (dialogChooseTemplateIdentifier.ShowDialog(this) == DialogResult.OK)
                                    {
                                        var identifier = dialogChooseTemplateIdentifier.SelectedIdentifier;
                                        AddTemplate(tweakEntry.Parent!.Key, identifier, tweakEntry.Key, templateIdentifier);
                                    }
                                }
                            }
                            break;
                    }
                    break;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuTweak.Tag is not TweakEntry tweakEntry) return;

            if (tweakEntry.Depth == 4 && tweakEntry.Key == "__template") return;

            using (new CenterWinDialog(this))
            {
                if (Messenger.MessageBox($"Delete {tweakEntry.Key}?", tweakEntry.Depth == 3 ? "Delete Tweak Entry" : "Delete Tweak Field", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tweakEntry.Delete();
                    SetTweakChanged();

                    if (tweakEntry.Parent?.children?.Count == 0)
                    {
                        tweakEntry.Parent.Delete();
                        if (tweakEntry.Parent?.Parent?.children?.Count == 0)
                        {
                            tweakEntry.Parent.Parent.Delete();
                            if (tweakEntry.Depth == 4 && tweakEntry.Parent?.Parent?.Parent?.children?.Count == 0)
                            {
                                tweakEntry.Parent.Parent.Parent.Delete();
                                treeViewTweak.RefreshObject(tweakEntry.Parent.Parent.Parent.Parent);
                            }
                            else
                            {
                                Debug.Assert(tweakEntry.Parent != null);
                                treeViewTweak.RefreshObject(tweakEntry.Parent.Parent.Parent);
                            }
                        }
                        else
                        {
                            Debug.Assert(tweakEntry.Parent != null);
                            treeViewTweak.RefreshObject(tweakEntry.Parent.Parent);
                        }
                    }
                    else
                    {
                        treeViewTweak.RefreshObject(tweakEntry.Parent);
                    }
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AskForSaveIfChanged()) e.Cancel = true;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (_progressBox != null && _progressBox.Visible) _progressBox.Focus();
        }
    }
}
