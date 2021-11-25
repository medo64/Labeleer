using System;
using System.Threading;
using System.Windows.Forms;
using Medo.Diagnostics;
using Medo.Windows.Forms;

namespace Labeleer;

internal static class App {

    private static readonly Mutex SetupMutex = new(false, @"Global\Medo64_Labeleer");

    [STAThread]
    private static void Main() {
        ApplicationConfiguration.Initialize();

        UnhandledCatch.UnhandledException += UnhandledCatch_UnhandledException;
        UnhandledCatch.Attach();

        Application.Run(new MainForm());

        SetupMutex.Close();

    }

    private static void UnhandledCatch_UnhandledException(object? sender, UnhandledCatchEventArgs e) {
        ErrorReportBox.ShowDialog(null, new Uri("https://medo64.com/feedback/"), e.Exception);
#if DEBUG
        throw e.Exception;
#endif
    }

}
