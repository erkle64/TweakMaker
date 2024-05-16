namespace TweakMaker
{
    public static class ExtensionMethods
    {
        public static void SetProgressNoAnimation(this ProgressBar pb, int value)
        {
            if (value == pb.Maximum)
            {
                pb.Maximum = value + 1;
                pb.Value = value + 1;
                pb.Maximum = value;
            }
            else
            {
                pb.Value = value + 1;
                pb.Value = value;
            }
        }
    }
}
