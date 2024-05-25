namespace TweakMaker.Controls
{
    partial class ModularBuildingConnectionNodeDataControl
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
            ColumnHeader columnHeaderIdentifier;
            ColumnHeader columnHeaderX;
            ColumnHeader columnHeaderName;
            Label labelAttachmentPointPreviewPosition;
            Label labelX;
            Label labelY;
            Label labelZ;
            columnHeaderY = new ColumnHeader();
            listView = new ListViewEx.ListViewEx();
            columnHeaderZ = new ColumnHeader();
            columnHeaderOrientation = new ColumnHeader();
            buttonAdd = new Button();
            buttonRemove = new Button();
            numericUpDown = new NumericUpDown();
            comboBoxOrientation = new ComboBox();
            numericUpDownX = new NumericUpDown();
            numericUpDownY = new NumericUpDown();
            numericUpDownZ = new NumericUpDown();
            columnHeaderIdentifier = new ColumnHeader();
            columnHeaderX = new ColumnHeader();
            columnHeaderName = new ColumnHeader();
            labelAttachmentPointPreviewPosition = new Label();
            labelX = new Label();
            labelY = new Label();
            labelZ = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownZ).BeginInit();
            SuspendLayout();
            // 
            // columnHeaderIdentifier
            // 
            columnHeaderIdentifier.Text = "Identifier";
            columnHeaderIdentifier.Width = 0;
            // 
            // columnHeaderX
            // 
            columnHeaderX.Text = "X";
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 180;
            // 
            // labelAttachmentPointPreviewPosition
            // 
            labelAttachmentPointPreviewPosition.AutoSize = true;
            labelAttachmentPointPreviewPosition.Location = new Point(3, 3);
            labelAttachmentPointPreviewPosition.Name = "labelAttachmentPointPreviewPosition";
            labelAttachmentPointPreviewPosition.Size = new Size(191, 15);
            labelAttachmentPointPreviewPosition.TabIndex = 5;
            labelAttachmentPointPreviewPosition.Text = "Attachment Point Preview Position";
            // 
            // labelX
            // 
            labelX.Location = new Point(0, 21);
            labelX.Name = "labelX";
            labelX.Size = new Size(23, 23);
            labelX.TabIndex = 6;
            labelX.Text = "X";
            labelX.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelY
            // 
            labelY.Location = new Point(151, 21);
            labelY.Name = "labelY";
            labelY.Size = new Size(23, 23);
            labelY.TabIndex = 8;
            labelY.Text = "Y";
            labelY.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelZ
            // 
            labelZ.Location = new Point(302, 21);
            labelZ.Name = "labelZ";
            labelZ.Size = new Size(23, 23);
            labelZ.TabIndex = 10;
            labelZ.Text = "Z";
            labelZ.TextAlign = ContentAlignment.TopCenter;
            // 
            // columnHeaderY
            // 
            columnHeaderY.Text = "Y";
            // 
            // listView
            // 
            listView.AllowColumnReorder = true;
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listView.Columns.AddRange(new ColumnHeader[] { columnHeaderIdentifier, columnHeaderName, columnHeaderX, columnHeaderY, columnHeaderZ, columnHeaderOrientation });
            listView.DoubleClickActivation = true;
            listView.FullRowSelect = true;
            listView.Location = new Point(3, 51);
            listView.Name = "listView";
            listView.Size = new Size(737, 92);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.SubItemClicked += listView_SubItemClicked;
            listView.Layout += listView_Layout;
            // 
            // columnHeaderZ
            // 
            columnHeaderZ.Text = "Z";
            // 
            // columnHeaderOrientation
            // 
            columnHeaderOrientation.Text = "Orientation";
            columnHeaderOrientation.Width = 100;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAdd.Location = new Point(746, 51);
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
            buttonRemove.Location = new Point(746, 80);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(75, 23);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(7, 75);
            numericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(120, 23);
            numericUpDown.TabIndex = 3;
            numericUpDown.Visible = false;
            // 
            // comboBoxOrientation
            // 
            comboBoxOrientation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOrientation.FormattingEnabled = true;
            comboBoxOrientation.Items.AddRange(new object[] { "xPos", "zNeg", "xNeg", "zPos" });
            comboBoxOrientation.Location = new Point(7, 104);
            comboBoxOrientation.Name = "comboBoxOrientation";
            comboBoxOrientation.Size = new Size(121, 23);
            comboBoxOrientation.TabIndex = 4;
            // 
            // numericUpDownX
            // 
            numericUpDownX.Location = new Point(23, 19);
            numericUpDownX.Name = "numericUpDownX";
            numericUpDownX.Size = new Size(120, 23);
            numericUpDownX.TabIndex = 7;
            // 
            // numericUpDownY
            // 
            numericUpDownY.Location = new Point(171, 19);
            numericUpDownY.Name = "numericUpDownY";
            numericUpDownY.Size = new Size(120, 23);
            numericUpDownY.TabIndex = 9;
            // 
            // numericUpDownZ
            // 
            numericUpDownZ.Location = new Point(322, 19);
            numericUpDownZ.Name = "numericUpDownZ";
            numericUpDownZ.Size = new Size(120, 23);
            numericUpDownZ.TabIndex = 11;
            // 
            // ModularBuildingConnectionNodeDataControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(numericUpDownZ);
            Controls.Add(labelZ);
            Controls.Add(numericUpDownY);
            Controls.Add(labelY);
            Controls.Add(numericUpDownX);
            Controls.Add(labelX);
            Controls.Add(labelAttachmentPointPreviewPosition);
            Controls.Add(comboBoxOrientation);
            Controls.Add(numericUpDown);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(listView);
            Name = "ModularBuildingConnectionNodeDataControl";
            Padding = new Padding(3);
            Size = new Size(824, 149);
            Resize += ModularBuildingConnectionNodeDataControl_Resize;
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownZ).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListViewEx.ListViewEx listView;
        private Button buttonAdd;
        private Button buttonRemove;
        private ColumnHeader columnHeaderY;
        private NumericUpDown numericUpDown;
        private ColumnHeader columnHeaderZ;
        private ColumnHeader columnHeaderOrientation;
        private ComboBox comboBoxOrientation;
        private Label labelX;
        private NumericUpDown numericUpDownX;
        private NumericUpDown numericUpDownY;
        private Label labelY;
        private NumericUpDown numericUpDownZ;
        private Label labelZ;
    }
}
