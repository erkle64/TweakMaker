namespace TweakMaker
{
    partial class DialogSelectIcon
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
            listBoxSelectIcon = new ListBox();
            buttonCancel = new Button();
            buttonSelect = new Button();
            pictureBoxIconPreview = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIconPreview).BeginInit();
            SuspendLayout();
            // 
            // listBoxSelectIcon
            // 
            listBoxSelectIcon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxSelectIcon.ItemHeight = 15;
            listBoxSelectIcon.Location = new Point(277, 15);
            listBoxSelectIcon.Name = "listBoxSelectIcon";
            listBoxSelectIcon.Size = new Size(317, 544);
            listBoxSelectIcon.Sorted = true;
            listBoxSelectIcon.TabIndex = 0;
            listBoxSelectIcon.SelectedIndexChanged += listBoxSelectIcon_SelectedIndexChanged;
            listBoxSelectIcon.DoubleClick += listBoxSelectTemplate_DoubleClick;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(519, 565);
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
            buttonSelect.Location = new Point(438, 565);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(75, 23);
            buttonSelect.TabIndex = 3;
            buttonSelect.Text = "Select";
            buttonSelect.UseVisualStyleBackColor = true;
            // 
            // pictureBoxIconPreview
            // 
            pictureBoxIconPreview.Location = new Point(12, 12);
            pictureBoxIconPreview.Name = "pictureBoxIconPreview";
            pictureBoxIconPreview.Size = new Size(256, 256);
            pictureBoxIconPreview.TabIndex = 4;
            pictureBoxIconPreview.TabStop = false;
            // 
            // DialogSelectIcon
            // 
            AcceptButton = buttonSelect;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(606, 596);
            Controls.Add(pictureBoxIconPreview);
            Controls.Add(buttonSelect);
            Controls.Add(buttonCancel);
            Controls.Add(listBoxSelectIcon);
            Name = "DialogSelectIcon";
            Text = "DialogSelectIcon";
            Shown += DialogSelectIcon_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBoxIconPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxSelectIcon;
        private Button buttonCancel;
        private Button buttonSelect;
        private PictureBox pictureBoxIconPreview;
    }
}