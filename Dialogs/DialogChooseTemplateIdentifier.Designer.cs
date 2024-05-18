namespace TweakMaker.Dialogs
{
    partial class DialogChooseTemplateIdentifier
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
            Label labelDescription;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogChooseTemplateIdentifier));
            textBoxTemplateIdentifier = new TextBox();
            buttonCreate = new Button();
            buttonCancel = new Button();
            labelConflict = new Label();
            labelDescription = new Label();
            SuspendLayout();
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(12, 9);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(229, 15);
            labelDescription.TabIndex = 0;
            labelDescription.Text = "Choose an identifier for the new template.";
            // 
            // textBoxTemplateIdentifier
            // 
            textBoxTemplateIdentifier.Location = new Point(12, 27);
            textBoxTemplateIdentifier.Name = "textBoxTemplateIdentifier";
            textBoxTemplateIdentifier.Size = new Size(312, 23);
            textBoxTemplateIdentifier.TabIndex = 1;
            textBoxTemplateIdentifier.TextChanged += textBoxTemplateIdentifier_TextChanged;
            // 
            // buttonCreate
            // 
            buttonCreate.DialogResult = DialogResult.OK;
            buttonCreate.Enabled = false;
            buttonCreate.Location = new Point(168, 56);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(75, 23);
            buttonCreate.TabIndex = 2;
            buttonCreate.Text = "Create";
            buttonCreate.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(249, 56);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelConflict
            // 
            labelConflict.AutoSize = true;
            labelConflict.Location = new Point(12, 53);
            labelConflict.Name = "labelConflict";
            labelConflict.Size = new Size(74, 15);
            labelConflict.TabIndex = 4;
            labelConflict.Text = "No conflicts.";
            // 
            // DialogChooseTemplateIdentifier
            // 
            AcceptButton = buttonCreate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(336, 91);
            Controls.Add(labelConflict);
            Controls.Add(buttonCancel);
            Controls.Add(buttonCreate);
            Controls.Add(textBoxTemplateIdentifier);
            Controls.Add(labelDescription);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DialogChooseTemplateIdentifier";
            Text = "Template Identifier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTemplateIdentifier;
        private Button buttonCreate;
        private Button buttonCancel;
        private Label labelConflict;
    }
}