namespace TweakMaker.Controls
{
    partial class ModularBuildingConnectionNodeControl
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
            buttonAdd = new Button();
            buttonRemove = new Button();
            tableLayoutPanelData = new TableLayoutPanel();
            SuspendLayout();
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAdd.Location = new Point(751, 0);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRemove.Location = new Point(751, 29);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(75, 23);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // tableLayoutPanelData
            // 
            tableLayoutPanelData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelData.AutoSize = true;
            tableLayoutPanelData.ColumnCount = 1;
            tableLayoutPanelData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelData.Location = new Point(0, 0);
            tableLayoutPanelData.Name = "tableLayoutPanelData";
            tableLayoutPanelData.RowCount = 1;
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelData.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelData.Size = new Size(745, 92);
            tableLayoutPanelData.TabIndex = 3;
            // 
            // ModularBuildingConnectionNodeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(tableLayoutPanelData);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Name = "ModularBuildingConnectionNodeControl";
            Size = new Size(826, 92);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonAdd;
        private Button buttonRemove;
        private TableLayoutPanel tableLayoutPanelData;
    }
}
