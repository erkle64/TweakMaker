namespace TweakMaker
{
    partial class DialogSelectTemplate
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
            listBoxSelectTemplate = new ListBox();
            buttonCancel = new Button();
            buttonSelect = new Button();
            SuspendLayout();
            // 
            // listBoxSelectTemplate
            // 
            listBoxSelectTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxSelectTemplate.ItemHeight = 15;
            listBoxSelectTemplate.Location = new Point(12, 15);
            listBoxSelectTemplate.Name = "listBoxSelectTemplate";
            listBoxSelectTemplate.Size = new Size(449, 544);
            listBoxSelectTemplate.Sorted = true;
            listBoxSelectTemplate.TabIndex = 0;
            listBoxSelectTemplate.DoubleClick += listBoxSelectTemplate_DoubleClick;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(386, 565);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSelect
            // 
            buttonSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSelect.DialogResult = DialogResult.OK;
            buttonSelect.Location = new Point(305, 565);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(75, 23);
            buttonSelect.TabIndex = 3;
            buttonSelect.Text = "Select";
            buttonSelect.UseVisualStyleBackColor = true;
            // 
            // DialogSelectTemplate
            // 
            AcceptButton = buttonSelect;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(473, 596);
            Controls.Add(buttonSelect);
            Controls.Add(buttonCancel);
            Controls.Add(listBoxSelectTemplate);
            Name = "DialogSelectTemplate";
            Text = "DialogSelectTemplate";
            Shown += DialogSelectTemplate_Shown;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxSelectTemplate;
        private Button buttonCancel;
        private Button buttonSelect;
    }
}