﻿using BrightIdeasSoftware;

namespace TweakMaker
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ToolStripMenuItem editToolStripMenuItem;
            ToolStripMenuItem deleteToolStripMenuItem;
            menuStripMain = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            changeToolStripMenuItem = new ToolStripMenuItem();
            itemToolStripMenuItem = new ToolStripMenuItem();
            recipeToolStripMenuItem = new ToolStripMenuItem();
            researchToolStripMenuItem = new ToolStripMenuItem();
            fluidToolStripMenuItem = new ToolStripMenuItem();
            terrainToolStripMenuItem = new ToolStripMenuItem();
            buildingToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            saveAsFileDialog = new SaveFileDialog();
            panelFoundryPath = new Panel();
            buttonBrowse = new Button();
            inputFoundryPath = new TextBox();
            labelFoundryPath = new Label();
            foundryFileDialog = new OpenFileDialog();
            treeViewTweak = new TreeListView();
            columnHeaderKeys = new OLVColumn();
            columnHeaderValues = new OLVColumn();
            panelOuter = new Panel();
            contextMenuTweak = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            menuStripMain.SuspendLayout();
            panelFoundryPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeViewTweak).BeginInit();
            panelOuter.SuspendLayout();
            contextMenuTweak.SuspendLayout();
            SuspendLayout();
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(107, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // menuStripMain
            // 
            menuStripMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, changeToolStripMenuItem });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(688, 24);
            menuStripMain.TabIndex = 0;
            menuStripMain.Text = "menuStripMain";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(195, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(195, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(195, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(195, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(192, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(195, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // changeToolStripMenuItem
            // 
            changeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { itemToolStripMenuItem, recipeToolStripMenuItem, researchToolStripMenuItem, fluidToolStripMenuItem, terrainToolStripMenuItem, buildingToolStripMenuItem });
            changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            changeToolStripMenuItem.Size = new Size(60, 20);
            changeToolStripMenuItem.Text = "Change";
            // 
            // itemToolStripMenuItem
            // 
            itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            itemToolStripMenuItem.Size = new Size(121, 22);
            itemToolStripMenuItem.Text = "Item";
            itemToolStripMenuItem.Click += itemToolStripMenuItem_Click;
            // 
            // recipeToolStripMenuItem
            // 
            recipeToolStripMenuItem.Name = "recipeToolStripMenuItem";
            recipeToolStripMenuItem.Size = new Size(121, 22);
            recipeToolStripMenuItem.Text = "Recipe";
            recipeToolStripMenuItem.Click += recipeToolStripMenuItem_Click;
            // 
            // researchToolStripMenuItem
            // 
            researchToolStripMenuItem.Name = "researchToolStripMenuItem";
            researchToolStripMenuItem.Size = new Size(121, 22);
            researchToolStripMenuItem.Text = "Research";
            // 
            // fluidToolStripMenuItem
            // 
            fluidToolStripMenuItem.Name = "fluidToolStripMenuItem";
            fluidToolStripMenuItem.Size = new Size(121, 22);
            fluidToolStripMenuItem.Text = "Fluid";
            // 
            // terrainToolStripMenuItem
            // 
            terrainToolStripMenuItem.Name = "terrainToolStripMenuItem";
            terrainToolStripMenuItem.Size = new Size(121, 22);
            terrainToolStripMenuItem.Text = "Terrain";
            // 
            // buildingToolStripMenuItem
            // 
            buildingToolStripMenuItem.Name = "buildingToolStripMenuItem";
            buildingToolStripMenuItem.Size = new Size(121, 22);
            buildingToolStripMenuItem.Text = "Building";
            // 
            // openFileDialog
            // 
            openFileDialog.DefaultExt = "json";
            openFileDialog.Filter = "JSON file|*.json|All files|*.*";
            // 
            // saveAsFileDialog
            // 
            saveAsFileDialog.DefaultExt = "json";
            saveAsFileDialog.Filter = "JSON file|*.json|All files|*.*";
            // 
            // panelFoundryPath
            // 
            panelFoundryPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelFoundryPath.Controls.Add(buttonBrowse);
            panelFoundryPath.Controls.Add(inputFoundryPath);
            panelFoundryPath.Controls.Add(labelFoundryPath);
            panelFoundryPath.Location = new Point(0, 0);
            panelFoundryPath.Name = "panelFoundryPath";
            panelFoundryPath.Size = new Size(688, 33);
            panelFoundryPath.TabIndex = 0;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonBrowse.Location = new Point(610, 6);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(75, 23);
            buttonBrowse.TabIndex = 2;
            buttonBrowse.Text = "Browse...";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // inputFoundryPath
            // 
            inputFoundryPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inputFoundryPath.Location = new Point(87, 6);
            inputFoundryPath.Name = "inputFoundryPath";
            inputFoundryPath.Size = new Size(517, 23);
            inputFoundryPath.TabIndex = 1;
            // 
            // labelFoundryPath
            // 
            labelFoundryPath.AutoSize = true;
            labelFoundryPath.Location = new Point(3, 9);
            labelFoundryPath.Name = "labelFoundryPath";
            labelFoundryPath.Size = new Size(78, 15);
            labelFoundryPath.TabIndex = 0;
            labelFoundryPath.Text = "Foundry Path";
            // 
            // foundryFileDialog
            // 
            foundryFileDialog.DefaultExt = "exe";
            foundryFileDialog.FileName = "Foundry.exe";
            foundryFileDialog.Filter = "Foundry Executable|Foundry.exe";
            // 
            // treeViewTweak
            // 
            treeViewTweak.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeViewTweak.Columns.AddRange(new ColumnHeader[] { columnHeaderKeys, columnHeaderValues });
            treeViewTweak.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            treeViewTweak.Location = new Point(3, 35);
            treeViewTweak.MultiSelect = false;
            treeViewTweak.Name = "treeViewTweak";
            treeViewTweak.SelectAllOnControlA = false;
            treeViewTweak.ShowGroups = false;
            treeViewTweak.Size = new Size(682, 422);
            treeViewTweak.TabIndex = 2;
            treeViewTweak.UseHotControls = false;
            treeViewTweak.View = View.Details;
            treeViewTweak.VirtualMode = true;
            treeViewTweak.CellRightClick += treeViewTweak_CellRightClick;
            // 
            // columnHeaderKeys
            // 
            columnHeaderKeys.AspectName = "Key";
            columnHeaderKeys.FillsFreeSpace = true;
            columnHeaderKeys.IsEditable = false;
            columnHeaderKeys.Text = "Key";
            columnHeaderKeys.Width = 240;
            // 
            // columnHeaderValues
            // 
            columnHeaderValues.AspectName = "Value";
            columnHeaderValues.CellEditUseWholeCell = true;
            columnHeaderValues.IsEditable = false;
            columnHeaderValues.Text = "Value";
            columnHeaderValues.Width = 240;
            // 
            // panelOuter
            // 
            panelOuter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelOuter.Controls.Add(panelFoundryPath);
            panelOuter.Controls.Add(treeViewTweak);
            panelOuter.Location = new Point(0, 24);
            panelOuter.Name = "panelOuter";
            panelOuter.Size = new Size(685, 457);
            panelOuter.TabIndex = 3;
            // 
            // contextMenuTweak
            // 
            contextMenuTweak.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuTweak.Name = "contextMenuTweak";
            contextMenuTweak.Size = new Size(108, 48);
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 484);
            Controls.Add(panelOuter);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            Name = "FormMain";
            Text = "Tweak Maker v0.1.0";
            FormClosing += FormMain_FormClosing;
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            panelFoundryPath.ResumeLayout(false);
            panelFoundryPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)treeViewTweak).EndInit();
            panelOuter.ResumeLayout(false);
            contextMenuTweak.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveAsFileDialog;
        private Panel panelFoundryPath;
        private TextBox inputFoundryPath;
        private Label labelFoundryPath;
        private Button buttonBrowse;
        private OpenFileDialog foundryFileDialog;
        private TreeListView treeViewTweak;
        private OLVColumn columnHeaderKeys;
        private OLVColumn columnHeaderValues;
        private ToolStripMenuItem changeToolStripMenuItem;
        private ToolStripMenuItem itemToolStripMenuItem;
        private ToolStripMenuItem recipeToolStripMenuItem;
        private ToolStripMenuItem researchToolStripMenuItem;
        private ToolStripMenuItem fluidToolStripMenuItem;
        private ToolStripMenuItem terrainToolStripMenuItem;
        private ToolStripMenuItem buildingToolStripMenuItem;
        private Panel panelOuter;
        private ToolStripMenuItem newToolStripMenuItem;
        private ContextMenuStrip contextMenuTweak;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}
