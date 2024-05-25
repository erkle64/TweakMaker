namespace TweakMaker
{
    public partial class Vector3IntControl : UserControl
    {
        public int X
        {
            get => (int)numericUpDownX.Value;
            set => numericUpDownX.Value = value;
        }

        public int Y
        {
            get => (int)numericUpDownY.Value;
            set => numericUpDownY.Value = value;
        }

        public int Z
        {
            get => (int)numericUpDownZ.Value;
            set => numericUpDownZ.Value = value;
        }

        public Vector3IntControl()
        {
            InitializeComponent();
        }
    }
}
