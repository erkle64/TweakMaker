namespace TweakMaker
{
    public partial class Vector4Control : UserControl
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

        public float W
        {
            get => (float)numericUpDownW.Value;
            set => numericUpDownW.Value = (decimal)value;
        }

        public Vector4Control()
        {
            InitializeComponent();
        }
    }
}
