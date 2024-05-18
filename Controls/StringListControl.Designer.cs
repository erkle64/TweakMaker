namespace TweakMaker.Controls
{
    partial class StringListControl
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
            ColumnHeader columnHeaderValue;
            listView = new ListViewEx.ListViewEx();
            buttonAdd = new Button();
            buttonRemove = new Button();
            textBox = new TextBox();
            columnHeaderValue = new ColumnHeader();
            SuspendLayout();
            // 
            // columnHeaderValue
            // 
            columnHeaderValue.Text = "Identifier";
            columnHeaderValue.Width = 741;
            // 
            // listView
            // 
            listView.AllowColumnReorder = true;
            listView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listView.Columns.AddRange(new ColumnHeader[] { columnHeaderValue });
            listView.DoubleClickActivation = true;
            listView.FullRowSelect = true;
            listView.HeaderStyle = ColumnHeaderStyle.None;
            listView.LabelEdit = true;
            listView.Location = new Point(0, 0);
            listView.Name = "listView";
            listView.Size = new Size(745, 92);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.SubItemClicked += listView_SubItemClicked;
            listView.Resize += listView_Resize;
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
            // textBox
            // 
            textBox.Location = new Point(0, 0);
            textBox.Name = "textBox";
            textBox.Size = new Size(100, 23);
            textBox.TabIndex = 3;
            textBox.Visible = false;
            // 
            // StringListControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(listView);
            Name = "StringListControl";
            Size = new Size(826, 92);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListViewEx.ListViewEx listView;
        private Button buttonAdd;
        private Button buttonRemove;
        private TextBox textBox;
    }
}
