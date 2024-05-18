
namespace TweakMaker
{
    partial class DialogEditTemplate
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableTemplate = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            numericUpDown4 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            buttonCancel = new Button();
            buttonSave = new Button();
            panelScroll = new Panel();
            toolTips = new ToolTip(components);
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            panelScroll.SuspendLayout();
            SuspendLayout();
            // 
            // tableTemplate
            // 
            tableTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableTemplate.AutoSize = true;
            tableTemplate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableTemplate.ColumnCount = 2;
            tableTemplate.ColumnStyles.Add(new ColumnStyle());
            tableTemplate.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableTemplate.Location = new Point(0, 0);
            tableTemplate.Margin = new Padding(0);
            tableTemplate.Name = "tableTemplate";
            tableTemplate.RowCount = 1;
            tableTemplate.RowStyles.Add(new RowStyle());
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableTemplate.Size = new Size(825, 0);
            tableTemplate.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel2.Controls.Add(numericUpDown4, 2, 0);
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(200, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown4.DecimalPlaces = 3;
            numericUpDown4.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown4.Location = new Point(135, 3);
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(62, 23);
            numericUpDown4.TabIndex = 2;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown5.DecimalPlaces = 3;
            numericUpDown5.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown5.Location = new Point(69, 3);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(60, 23);
            numericUpDown5.TabIndex = 1;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(762, 11);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSave.AutoSize = true;
            buttonSave.Location = new Point(666, 11);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(90, 25);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save Changes";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // panelScroll
            // 
            panelScroll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelScroll.AutoScroll = true;
            panelScroll.Controls.Add(tableTemplate);
            panelScroll.Location = new Point(12, 39);
            panelScroll.Name = "panelScroll";
            panelScroll.Size = new Size(825, 506);
            panelScroll.TabIndex = 3;
            panelScroll.Resize += panelScroll_Resize;
            // 
            // toolTips
            // 
            toolTips.AutomaticDelay = 1500;
            toolTips.IsBalloon = true;
            // 
            // DialogEditTemplate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(849, 557);
            Controls.Add(panelScroll);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Name = "DialogEditTemplate";
            Text = "DialogEditTemplate";
            FormClosing += DialogChangeRecipe_FormClosing;
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            panelScroll.ResumeLayout(false);
            panelScroll.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableTemplate;
        private TableLayoutPanel tableLayoutPanel2;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown5;
        private Button buttonCancel;
        private Button buttonSave;
        private Panel panelScroll;
        private ToolTip toolTips;
    }
}