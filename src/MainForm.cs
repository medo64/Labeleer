using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading;
using System.Windows.Forms;
using Medo.Windows.Forms;
using static Labeleer.Helpers;

namespace Labeleer;

internal partial class MainForm : Form {

    private Document? Document;

    public MainForm() {
        InitializeComponent();

        mnu.Font = SystemFonts.MessageBoxFont;
        mnu.Renderer = Helpers.ToolStripBorderlessSystemRendererInstance;
        Helpers.ScaleToolstrip(mnu);
    }

    private void Form_Load(object sender, EventArgs e) {
        bwUpgradeCheck.RunWorkerAsync();
    }

    private void Form_FormClosing(object sender, FormClosingEventArgs e) {
        bwUpgradeCheck.CancelAsync();
    }


    private void bwUpgradeCheck_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
        e.Cancel = true;

        var sw = Stopwatch.StartNew();
        while (sw.ElapsedMilliseconds < 3000) { //wait for three seconds
            Thread.Sleep(100);
            if (bwUpgradeCheck.CancellationPending) { return; }
        }

        var file = UpgradeBox.GetUpgradeFile(new Uri("https://medo64.com/upgrade/"));
        if (file != null) {
            if (bwUpgradeCheck.CancellationPending) { return; }
            e.Cancel = false;
        }
    }

    private void bwUpgradeCheck_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
        if (!e.Cancelled && (e.Error == null)) {
            Helpers.ScaleToolstripItem(mnuApp, "mnuAppUpgrade");
            mnuAppUpgrade.Text = "Upgrade is available";
        }
    }


    #region Menu

    private void mnuFileNew_Click(object sender, EventArgs e) {

    }

    private void mnuFileOpen_Click(object sender, EventArgs e) {
        using var form = new OpenFileDialog();
        form.Filter = "Labeleer files (*.labeleer)|*.labeleer|All files (*.*)|*.*";
        if (form.ShowDialog(this) == DialogResult.OK) {
            form.InitialDirectory = Environment.CurrentDirectory;
            Document = new Document(form.FileName);
        }
    }

    private void mnuFileSave_Click(object sender, EventArgs e) {

    }


    private void mnuPrint_ButtonClick(object sender, EventArgs e) {
        mnuPrintDialog_Click(sender, EventArgs.Empty);
    }

    private void mnuPrintDialog_Click(object sender, EventArgs e) {
        var doc = GetPrintDocument();
        using var printDialog = new PrintDialog();
        printDialog.Document = doc;
        printDialog.ShowDialog(this);
    }

    private void mnuPrintPreview_Click(object sender, EventArgs e) {
        var doc = GetPrintDocument();
        using var printPreview = new PrintPreviewDialog();
        printPreview.Document = doc;
        printPreview.ShowDialog(this);
    }


    private void mnuAppFeedback_Click(object sender, EventArgs e) {
        ErrorReportBox.ShowDialog(this, new Uri("https://medo64.com/feedback/"));
    }

    private void mnuAppUpgrade_Click(object sender, EventArgs e) {
        UpgradeBox.ShowDialog(this, new Uri("https://medo64.com/upgrade/"));
    }

    private void mnuAppAbout_Click(object sender, EventArgs e) {
        AboutBox.ShowDialog(this);
    }

    #endregion Menu

    private PrintDocument? GetPrintDocument() {
        if (Document == null) { return null; }

        var printDocument = new PrintDocument();

        printDocument.DefaultPageSettings.PrinterResolution = Helpers.GetHighest(printDocument.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterResolutions);
        var paperSize = new PaperSize(Document.Paper.Name,
                                      ToHundretsOfInches(Document.Paper.PaperWidth),
                                      ToHundretsOfInches(Document.Paper.PaperHeight));
        printDocument.DefaultPageSettings.PaperSize = paperSize;

        printDocument.PrintPage += delegate (object sender, PrintPageEventArgs e) {
            if (e.Graphics is not null) { Document.Draw(e.Graphics); }
        };

        return printDocument;
    }

}
