using BlueMystic;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace TweakMaker
{
    public partial class DialogSelectIcon : Form
    {
        private readonly Dictionary<string, Image?> _icons;
        private readonly string _defaultSelection;

        public DialogSelectIcon(Dictionary<string, Image?> icons, string defaultSelection)
        {
            InitializeComponent();

            _icons = icons;
            _defaultSelection = defaultSelection;
            listBoxSelectIcon.Items.Clear();
            listBoxSelectIcon.Items.AddRange(_icons.Select(kv => new IconData(kv.Key, kv.Value)).ToArray());

            new DarkModeCS(this);
        }

        private void DialogSelectIcon_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_defaultSelection))
            {
                listBoxSelectIcon.SelectedIndex = listBoxSelectIcon.Items.OfType<IconData>().ToList().FindIndex(x => x.name == _defaultSelection);
            }
        }

        public string SelectedIconName
        {
            get
            {
                return (listBoxSelectIcon.SelectedItem as IconData)?.name ?? "";
            }
        }

        public class IconData(string name, Image? image)
        {
            public string name = name;
            public Image? image = image;

            public override string? ToString() => name;
        }

        private void listBoxSelectTemplate_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedIconName))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void listBoxSelectIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSelectIcon.SelectedItem is IconData selectedIcon)
            {
                pictureBoxIconPreview.Image = selectedIcon.image;
            }
            else
            {
                pictureBoxIconPreview.Image = null;
            }
        }
    }
}
