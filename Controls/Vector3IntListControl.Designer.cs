namespace TweakMaker.Controls
{
    partial class Vector3IntListControl
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
            ColumnHeader columnHeaderX;
            ColumnHeader columnHeaderZ;
            ColumnHeader columnHeaderY;
            listView = new ListViewEx.ListViewEx();
            buttonAdd = new Button();
            buttonRemove = new Button();
            numericUpDownAmount = new NumericUpDown();
            columnHeaderX = new ColumnHeader();
            columnHeaderZ = new ColumnHeader();
            columnHeaderY = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).BeginInit();
            SuspendLayout();
            // 
            // columnHeaderX
            // 
            columnHeaderX.Text = "X";
            columnHeaderX.Width = 120;
            // 
            // columnHeaderZ
            // 
            columnHeaderZ.Text = "Z";
            columnHeaderZ.Width = 120;
            // 
            // columnHeaderY
            // 
            columnHeaderY.Text = "Y";
            columnHeaderY.Width = 120;
            // 
            // listView
            // 
            listView.AllowColumnReorder = true;
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listView.Columns.AddRange(new ColumnHeader[] { columnHeaderX, columnHeaderY, columnHeaderZ });
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
            // Vector3IntListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numericUpDownAmount);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(listView);
            Name = "Vector3IntListControl";
            Size = new Size(826, 92);
            Resize += Vector3IntListControl_Resize;
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
