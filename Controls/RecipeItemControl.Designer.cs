namespace TweakMaker.Controls
{
    partial class RecipeItemControl
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
            ColumnHeader columnHeaderAmount;
            ColumnHeader columnHeaderName;
            columnHeaderPercentage = new ColumnHeader();
            listView = new ListViewEx.ListViewEx();
            buttonAdd = new Button();
            buttonRemove = new Button();
            numericUpDownAmount = new NumericUpDown();
            numericUpDownPercentage = new NumericUpDown();
            columnHeaderIdentifier = new ColumnHeader();
            columnHeaderAmount = new ColumnHeader();
            columnHeaderName = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPercentage).BeginInit();
            SuspendLayout();
            // 
            // columnHeaderIdentifier
            // 
            columnHeaderIdentifier.Text = "Identifier";
            columnHeaderIdentifier.Width = 180;
            // 
            // columnHeaderAmount
            // 
            columnHeaderAmount.Text = "Amount";
            columnHeaderAmount.Width = 80;
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 180;
            // 
            // columnHeaderPercentage
            // 
            columnHeaderPercentage.Text = "Percentage";
            columnHeaderPercentage.Width = 80;
            // 
            // listView
            // 
            listView.AllowColumnReorder = true;
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listView.Columns.AddRange(new ColumnHeader[] { columnHeaderIdentifier, columnHeaderName, columnHeaderAmount, columnHeaderPercentage });
            listView.DoubleClickActivation = true;
            listView.FullRowSelect = true;
            listView.LabelEdit = true;
            listView.Location = new Point(0, 0);
            listView.Name = "listView";
            listView.Size = new Size(745, 92);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.SubItemClicked += listView_SubItemClicked;
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
            numericUpDownAmount.Name = "numericUpDownAmount";
            numericUpDownAmount.Size = new Size(120, 23);
            numericUpDownAmount.TabIndex = 3;
            numericUpDownAmount.Visible = false;
            // 
            // numericUpDownPercentage
            // 
            numericUpDownPercentage.Location = new Point(8, 31);
            numericUpDownPercentage.Name = "numericUpDownPercentage";
            numericUpDownPercentage.Size = new Size(120, 23);
            numericUpDownPercentage.TabIndex = 4;
            numericUpDownPercentage.Visible = false;
            // 
            // RecipeItemControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(numericUpDownPercentage);
            Controls.Add(numericUpDownAmount);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(listView);
            Name = "RecipeItemControl";
            Size = new Size(826, 92);
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPercentage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListViewEx.ListViewEx listView;
        private Button buttonAdd;
        private Button buttonRemove;
        private ColumnHeader columnHeaderPercentage;
        private NumericUpDown numericUpDownAmount;
        private NumericUpDown numericUpDownPercentage;
    }
}
