namespace TweakMaker
{
    partial class Vector3Control
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label labelX;
            Label labelY;
            Label labelZ;
            numericUpDownX = new NumericUpDown();
            numericUpDownY = new NumericUpDown();
            numericUpDownZ = new NumericUpDown();
            labelX = new Label();
            labelY = new Label();
            labelZ = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownZ).BeginInit();
            SuspendLayout();
            // 
            // labelX
            // 
            labelX.Location = new Point(0, 0);
            labelX.Name = "labelX";
            labelX.Size = new Size(23, 23);
            labelX.TabIndex = 1;
            labelX.Text = "X";
            labelX.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelY
            // 
            labelY.Location = new Point(130, 0);
            labelY.Name = "labelY";
            labelY.Size = new Size(23, 23);
            labelY.TabIndex = 3;
            labelY.Text = "Y";
            labelY.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelZ
            // 
            labelZ.Location = new Point(260, 0);
            labelZ.Name = "labelZ";
            labelZ.Size = new Size(23, 23);
            labelZ.TabIndex = 4;
            labelZ.Text = "Z";
            labelZ.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownX
            // 
            numericUpDownX.DecimalPlaces = 2;
            numericUpDownX.Location = new Point(23, 0);
            numericUpDownX.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownX.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numericUpDownX.Name = "numericUpDownX";
            numericUpDownX.Size = new Size(100, 23);
            numericUpDownX.TabIndex = 5;
            // 
            // numericUpDownY
            // 
            numericUpDownY.DecimalPlaces = 2;
            numericUpDownY.Location = new Point(153, 0);
            numericUpDownY.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownY.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numericUpDownY.Name = "numericUpDownY";
            numericUpDownY.Size = new Size(100, 23);
            numericUpDownY.TabIndex = 6;
            // 
            // numericUpDownZ
            // 
            numericUpDownZ.DecimalPlaces = 2;
            numericUpDownZ.Location = new Point(283, 0);
            numericUpDownZ.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownZ.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numericUpDownZ.Name = "numericUpDownZ";
            numericUpDownZ.Size = new Size(100, 23);
            numericUpDownZ.TabIndex = 7;
            // 
            // Vector3Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numericUpDownZ);
            Controls.Add(numericUpDownY);
            Controls.Add(numericUpDownX);
            Controls.Add(labelZ);
            Controls.Add(labelY);
            Controls.Add(labelX);
            Name = "Vector3Control";
            Size = new Size(383, 23);
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownZ).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown numericUpDownX;
        private NumericUpDown numericUpDownY;
        private NumericUpDown numericUpDownZ;
    }
}
