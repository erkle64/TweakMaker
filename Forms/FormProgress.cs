using BlueMystic;

namespace TweakMaker
{
    public partial class FormProgress : Form
    {
        public CancellationTokenSource cancellationTokenSource;
        private ProgressInfo _progressInfo;

        public FormProgress()
        {
            InitializeComponent();

            cancellationTokenSource = new CancellationTokenSource();

            _progressInfo = new ProgressInfo
            {
                label = "",
                step = -1,
                maximum = 100
            };

            new DarkModeCS(this);
        }

        public void SetProgress(ProgressInfo progressInfo)
        {
            if (progressInfo.label != _progressInfo.label) label.Text = progressInfo.label;
            progressBar.Maximum = progressInfo.maximum;
            progressBar.SetProgressNoAnimation(progressInfo.step);
            _progressInfo = progressInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            Application.Exit();
        }

        public struct ProgressInfo
        {
            public string label;
            public int step;
            public int maximum;
            public bool done;
        }
    }
}
