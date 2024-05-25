namespace TweakMaker.Controls
{
    partial class AABB3DListControl
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
            ColumnHeader columnHeaderSizeX;
            ColumnHeader columnHeaderSizeZ;
            ColumnHeader columnHeaderSizeY;
            ColumnHeader columnHeaderOffsetX;
            ColumnHeader columnHeaderOffsetY;
            ColumnHeader columnHeaderOffsetZ;
            listView = new ListViewEx.ListViewEx();
            buttonAdd = new Button();
            buttonRemove = new Button();
            numericUpDownAmount = new NumericUpDown();
            columnHeaderSizeX = new ColumnHeader();
            columnHeaderSizeZ = new ColumnHeader();
            columnHeaderSizeY = new ColumnHeader();
            columnHeaderOffsetX = new ColumnHeader();
            columnHeaderOffsetY = new ColumnHeader();
            columnHeaderOffsetZ = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).BeginInit();
            SuspendLayout();
            // 
            // columnHeaderSizeX
            // 
            columnHeaderSizeX.Text = "Size X";
            columnHeaderSizeX.Width = 90;
            // 
            // columnHeaderSizeZ
            // 
            columnHeaderSizeZ.Text = "Size Z";
            columnHeaderSizeZ.Width = 90;
            // 
            // columnHeaderSizeY
            // 
            columnHeaderSizeY.Text = "Size Y";
            columnHeaderSizeY.Width = 90;
            // 
            // listView
            // 
            listView.AllowColumnReorder = true;
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listView.Columns.AddRange(new ColumnHeader[] { columnHeaderSizeX, columnHeaderSizeY, columnHeaderSizeZ, columnHeaderOffsetX, columnHeaderOffsetY, columnHeaderOffsetZ });
            listView.DoubleClickActivation = true;
            listView.FullRowSelect = true;
            listView.Location = new Point(0, 0);
            listView.Name = "listView";
            listView.Size = new Size(745, 92);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.SubItemClicked += listView_SubItemClicked;
            listView.Layout += listView_Layout;
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
            // numericUpDownAmount
            // 
            numericUpDownAmount.Location = new Point(8, 8);
            numericUpDownAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownAmount.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numericUpDownAmount.Name = "numericUpDownAmount";
            numericUpDownAmount.Size = new Size(120, 23);
            numericUpDownAmount.TabIndex = 3;
            numericUpDownAmount.Visible = false;
            // 
            // columnHeaderOffsetX
            // 
            columnHeaderOffsetX.Text = "Offset X";
            columnHeaderOffsetX.Width = 90;
            // 
            // columnHeaderOffsetY
            // 
            columnHeaderOffsetY.Text = "Offset Y";
            columnHeaderOffsetY.Width = 90;
            // 
            // columnHeaderOffsetZ
            // 
            columnHeaderOffsetZ.Text = "Offset Z";
            columnHeaderOffsetZ.Width = 90;
            // 
            // AABB3DListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numericUpDownAmount);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(listView);
            Name = "AABB3DListControl";
            Size = new Size(826, 92);
            Resize += AABB3DListControl_Resize;
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListViewEx.ListViewEx listView;
        private Button buttonAdd;
        private Button buttonRemove;
        private NumericUpDown numericUpDownAmount;
    }
}
