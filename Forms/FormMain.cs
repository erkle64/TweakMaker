using BrightIdeasSoftware;
using Narod.SteamGameFinder;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace TweakMaker
{
    public partial class FormMain : Form
    {
        private TweakEntryObject? _treeRoot = null;
        private JObject _jsonRoot;

        private readonly DumpData _dump = new();
        private readonly FormProgress _progressBox;

        private readonly string _baseTitle = string.Empty;
        private string _currentTweakPath = string.Empty;
        private bool _isTweakChanged = false;

        private readonly int[] _iconSizes = [
                256, 512, 0, 64, 96, 128
            ];

        public FormMain()
        {
            InitializeComponent();

            _baseTitle = Text;

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

            _jsonRoot = [];
            _treeRoot = new TweakEntryObject(null, "tweak", _jsonRoot);
            BuildTreeView(_jsonRoot, _treeRoot);
            treeViewTweak.Roots = new TweakEntry[] { _treeRoot };
            treeViewTweak.ExpandAll();
        }

        private void SetFoundryPath(string path)
        {
            inputFoundryPath.Text = path;

            if (!string.IsNullOrEmpty(path))
            {
                menuStripMain.Enabled = false;
                panelOuter.Enabled = false;
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
                        _progressBox.Close();
                    }
                });
                Task.Run(() => LoadDumpData(_progressBox.cancellationTokenSource.Token, progress), _progressBox.cancellationTokenSource.Token);
            }
        }

        private void LoadDumpData(CancellationToken cancellationToken, IProgress<FormProgress.ProgressInfo> progress)
        {
            _dump.buildings.Clear();
            var buildingFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, @"tweakificator\\Dumps\\Buildings"));
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
                    _dump.buildings[json["identifier"]?.ToString() ?? ""] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.items.Clear();
            var itemFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, @"tweakificator\\Dumps\\Items"));
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
                    _dump.items[json["identifier"]?.ToString() ?? ""] = json;

                    if ((json["flags"]?.ToString() ?? "").Contains("BUILDABLE_OBJECT"))
                    {
                        var bot = json["buildableObjectIdentifer"]?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(bot) && _dump.buildings.TryGetValue(bot, out JObject? value) && value is JObject botObject)
                        {
                            botObject.Add("name", json["name"]);
                        }
                    }
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.fluids.Clear();
            var fluidFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, @"tweakificator\\Dumps\\Elements"));
            progressInfo = new FormProgress.ProgressInfo
            {
                label = "Loading fluids...",
                step = 0,
                maximum = fluidFilePaths.Length,
                done = false
            };
            progress.Report(progressInfo);
            foreach (var filePath in fluidFilePaths)
            {
                if (cancellationToken.IsCancellationRequested) return;

                var json = JObject.Parse(File.ReadAllText(filePath));
                if (json.ContainsKey("identifier"))
                {
                    _dump.fluids[json["identifier"]?.ToString() ?? ""] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.recipes.Clear();
            var recipeFilePaths = Directory.GetFiles(Path.Combine(inputFoundryPath.Text, @"tweakificator\\Dumps\\Recipes"));
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
                if (json.ContainsKey("identifier") && !(json["skipForRunningIdxGeneration"]?.Value<bool>() ?? false))
                {
                    _dump.recipes[json["identifier"]?.ToString() ?? ""] = json;
                }

                progressInfo.step++;
                progress.Report(progressInfo);
            }

            _dump.icons.Clear();
            var iconNames = File.ReadAllLines(Path.Combine(inputFoundryPath.Text, @"tweakificator\\Dumps\\Icons\\__icons.txt"))
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
                var iconFile = Path.Combine(inputFoundryPath.Text, @"tweakificator\\Dumps\\Icons", $"{iconName}.png");
                if (File.Exists(iconFile))
                {
                    image = Image.FromFile(iconFile);
                }
                else
                {
                    foreach (var size in _iconSizes)
                    {
                        iconFile = Path.Combine(inputFoundryPath.Text, @"tweakificator\\Dumps\\Icons", $"{iconName}_{size}.png");
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

                _dump.icons[iconName] = image;

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

        private void ChangeRecipe(string identifier)
        {
            var originalTemplate = (JObject)_dump.recipes[identifier].DeepClone();
            if (TryGetTweak(out var tweakTemplate, "changes", "recipes", identifier))
            {
                originalTemplate.Merge(tweakTemplate, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Replace,
                    MergeNullValueHandling = MergeNullValueHandling.Ignore,
                    PropertyNameComparison = StringComparison.InvariantCulture
                });
            }

            var dialogChangeRecipe = new DialogChangeRecipe(originalTemplate, _dump);
            if (dialogChangeRecipe.ShowDialog(this) == DialogResult.OK)
            {
                var newTemplate = dialogChangeRecipe.BuildTemplate();

                if (TryGetTweak(out var currentTemplate, "changes", "recipes", identifier))
                {
                    currentTemplate.Merge(newTemplate, new JsonMergeSettings
                    {
                        MergeArrayHandling = MergeArrayHandling.Replace,
                        MergeNullValueHandling = MergeNullValueHandling.Ignore,
                        PropertyNameComparison = StringComparison.InvariantCulture
                    });
                    SetTweak(currentTemplate, "changes", "recipes", identifier);
                }
                else
                {
                    SetTweak(newTemplate, "changes", "recipes", identifier);
                }

                _treeRoot = new TweakEntryObject(null, "tweak", _jsonRoot);
                BuildTreeView(_jsonRoot, _treeRoot);
                treeViewTweak.Roots = new TweakEntry[] { _treeRoot };
                treeViewTweak.ExpandAll();

                SetTweakChanged();
            }
            dialogChangeRecipe.Dispose();
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
                    switch (MessageBox.Show("Do you want to save changes?", "Tweak Maker", MessageBoxButtons.YesNoCancel))
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
            Application.Exit();
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
            var dialog = new DialogSelectTemplate(_dump.items.Values, string.Empty);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                var form = new FormChangeItem(_dump.items[dialog.SelectedIdentifier], _dump);
                form.Show(this);
            }
            dialog.Dispose();
        }

        private void recipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogSelectTemplate = new DialogSelectTemplate(_dump.recipes.Values, string.Empty);
            if (dialogSelectTemplate.ShowDialog(this) == DialogResult.OK)
            {
                var identifier = dialogSelectTemplate.SelectedIdentifier;
                ChangeRecipe(identifier);
            }
            dialogSelectTemplate.Dispose();
        }

        private void treeViewTweak_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (e.ColumnIndex != 0) return;
            if (e.Model is not TweakEntry tweakEntry) return;

            if (tweakEntry.Depth == 3 || tweakEntry.Depth == 4)
            {
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

            if (tweakEntry.Parent?.Key == "recipes")
            {
                if (tweakEntry.Parent?.Parent?.Key == "changes")
                {
                    ChangeRecipe(tweakEntry.Key);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuTweak.Tag is not TweakEntry tweakEntry) return;

            using (new CenterWinDialog(this))
            {
                if (MessageBox.Show($"Delete {tweakEntry.Key}?", tweakEntry.Depth == 3 ? "Delete Tweak Entry" : "Delete Tweak Field", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
    }
}
