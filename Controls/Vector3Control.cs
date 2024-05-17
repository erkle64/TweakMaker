namespace TweakMaker
{
    public partial class Vector3Control : UserControl
    {
        public float X
        {
            get => (float)numericUpDownX.Value;
            set => numericUpDownX.Value = (decimal)value;
        }

        public float Y
        {
            get => (float)numericUpDownY.Value;
            set => numericUpDownY.Value = (decimal)value;
        }

        public float Z
        {
            get => (float)numericUpDownZ.Value;
            set => numericUpDownZ.Value = (decimal)value;
        }

        public Vector3Control()
        {
            InitializeComponent();
        }
    }
}
