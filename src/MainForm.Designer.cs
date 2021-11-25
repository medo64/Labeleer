using System.Windows.Forms;

namespace Labeleer;

partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnu = new System.Windows.Forms.ToolStrip();
            this.mnuFileNew = new System.Windows.Forms.ToolStripButton();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripButton();
            this.mnuFileSave = new System.Windows.Forms.ToolStripButton();
            this.mnu0 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuPrintDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuApp = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuAppFeedback = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuApp0 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAppAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.splSide = new System.Windows.Forms.SplitContainer();
            this.listBlocks = new System.Windows.Forms.ListBox();
            this.propBlock = new System.Windows.Forms.PropertyGrid();
            this.bwUpgradeCheck = new System.ComponentModel.BackgroundWorker();
            this.mnu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splSide)).BeginInit();
            this.splSide.Panel1.SuspendLayout();
            this.splSide.Panel2.SuspendLayout();
            this.splSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnu0,
            this.mnuPrint,
            this.mnuApp});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(782, 27);
            this.mnu.TabIndex = 1;
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Image = global::Labeleer.Properties.Resources.mnuFileNew_16;
            this.mnuFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.Size = new System.Drawing.Size(63, 24);
            this.mnuFileNew.Text = "New";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Image = global::Labeleer.Properties.Resources.mnuFileOpen_16;
            this.mnuFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(69, 24);
            this.mnuFileOpen.Text = "Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Image = global::Labeleer.Properties.Resources.mnuFileSave_16;
            this.mnuFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.Size = new System.Drawing.Size(64, 24);
            this.mnuFileSave.Text = "Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnu0
            // 
            this.mnu0.Name = "mnu0";
            this.mnu0.Size = new System.Drawing.Size(6, 27);
            // 
            // mnuPrint
            // 
            this.mnuPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPrintDialog,
            this.mnuPrintPreview});
            this.mnuPrint.Image = global::Labeleer.Properties.Resources.mnuPrint_16;
            this.mnuPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(78, 24);
            this.mnuPrint.Text = "Print";
            this.mnuPrint.ButtonClick += new System.EventHandler(this.mnuPrint_ButtonClick);
            // 
            // mnuPrintDialog
            // 
            this.mnuPrintDialog.Image = global::Labeleer.Properties.Resources.mnuPrint_16;
            this.mnuPrintDialog.Name = "mnuPrintDialog";
            this.mnuPrintDialog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuPrintDialog.Size = new System.Drawing.Size(267, 26);
            this.mnuPrintDialog.Tag = "mnuPrint";
            this.mnuPrintDialog.Text = "Print";
            this.mnuPrintDialog.Click += new System.EventHandler(this.mnuPrintDialog_Click);
            // 
            // mnuPrintPreview
            // 
            this.mnuPrintPreview.Image = global::Labeleer.Properties.Resources.mnuPrintPreview_16;
            this.mnuPrintPreview.Name = "mnuPrintPreview";
            this.mnuPrintPreview.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.mnuPrintPreview.Size = new System.Drawing.Size(267, 26);
            this.mnuPrintPreview.Text = "Print Preview";
            this.mnuPrintPreview.Click += new System.EventHandler(this.mnuPrintPreview_Click);
            // 
            // mnuApp
            // 
            this.mnuApp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuApp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAppFeedback,
            this.mnuAppUpgrade,
            this.mnuApp0,
            this.mnuAppAbout});
            this.mnuApp.Image = global::Labeleer.Properties.Resources.mnuApp_16;
            this.mnuApp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuApp.Name = "mnuApp";
            this.mnuApp.Size = new System.Drawing.Size(34, 24);
            this.mnuApp.Text = "toolStripButton1";
            // 
            // mnuAppFeedback
            // 
            this.mnuAppFeedback.Name = "mnuAppFeedback";
            this.mnuAppFeedback.Size = new System.Drawing.Size(216, 26);
            this.mnuAppFeedback.Text = "Send Feedback";
            this.mnuAppFeedback.Click += new System.EventHandler(this.mnuAppFeedback_Click);
            // 
            // mnuAppUpgrade
            // 
            this.mnuAppUpgrade.Name = "mnuAppUpgrade";
            this.mnuAppUpgrade.Size = new System.Drawing.Size(216, 26);
            this.mnuAppUpgrade.Text = "Check for Upgrade";
            this.mnuAppUpgrade.Click += new System.EventHandler(this.mnuAppUpgrade_Click);
            // 
            // mnuApp0
            // 
            this.mnuApp0.Name = "mnuApp0";
            this.mnuApp0.Size = new System.Drawing.Size(213, 6);
            // 
            // mnuAppAbout
            // 
            this.mnuAppAbout.Name = "mnuAppAbout";
            this.mnuAppAbout.Size = new System.Drawing.Size(216, 26);
            this.mnuAppAbout.Text = "About";
            this.mnuAppAbout.Click += new System.EventHandler(this.mnuAppAbout_Click);
            // 
            // splMain
            // 
            this.splMain.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splMain.Location = new System.Drawing.Point(0, 27);
            this.splMain.Name = "splMain";
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.splSide);
            this.splMain.Size = new System.Drawing.Size(782, 406);
            this.splMain.SplitterDistance = 480;
            this.splMain.TabIndex = 2;
            this.splMain.TabStop = false;
            // 
            // splSide
            // 
            this.splSide.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splSide.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splSide.Location = new System.Drawing.Point(0, 0);
            this.splSide.Name = "splSide";
            this.splSide.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splSide.Panel1
            // 
            this.splSide.Panel1.Controls.Add(this.listBlocks);
            // 
            // splSide.Panel2
            // 
            this.splSide.Panel2.Controls.Add(this.propBlock);
            this.splSide.Size = new System.Drawing.Size(298, 406);
            this.splSide.SplitterDistance = 120;
            this.splSide.SplitterWidth = 2;
            this.splSide.TabIndex = 0;
            this.splSide.TabStop = false;
            // 
            // listBlocks
            // 
            this.listBlocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBlocks.FormattingEnabled = true;
            this.listBlocks.IntegralHeight = false;
            this.listBlocks.ItemHeight = 20;
            this.listBlocks.Location = new System.Drawing.Point(0, 0);
            this.listBlocks.Name = "listBlocks";
            this.listBlocks.Size = new System.Drawing.Size(298, 120);
            this.listBlocks.TabIndex = 0;
            // 
            // propBlock
            // 
            this.propBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propBlock.Location = new System.Drawing.Point(0, 0);
            this.propBlock.Name = "propBlock";
            this.propBlock.Size = new System.Drawing.Size(298, 284);
            this.propBlock.TabIndex = 0;
            this.propBlock.ToolbarVisible = false;
            // 
            // bwUpgradeCheck
            // 
            this.bwUpgradeCheck.WorkerSupportsCancellation = true;
            this.bwUpgradeCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwUpgradeCheck_DoWork);
            this.bwUpgradeCheck.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwUpgradeCheck_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 433);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.mnu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Labeleer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            this.splSide.Panel1.ResumeLayout(false);
            this.splSide.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splSide)).EndInit();
            this.splSide.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private ToolStrip mnu;
    private ToolStripButton mnuFileNew;
    private ToolStripButton mnuFileOpen;
    private ToolStripButton mnuFileSave;
    private ToolStripSeparator mnu0;
    private SplitContainer splMain;
    private ToolStripSplitButton mnuPrint;
    private ToolStripMenuItem mnuPrintDialog;
    private ToolStripMenuItem mnuPrintPreview;
    private ToolStripDropDownButton mnuApp;
    private ToolStripMenuItem mnuAppAbout;
    private SplitContainer splSide;
    private PropertyGrid propBlock;
    private ListBox listBlocks;
    private ToolStripMenuItem mnuAppFeedback;
    private ToolStripSeparator mnuApp0;
    private ToolStripMenuItem mnuAppUpgrade;
    private System.ComponentModel.BackgroundWorker bwUpgradeCheck;
}
