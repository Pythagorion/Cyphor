using System.Reflection;
using CefSharp;
using CefSharp.WinForms;

namespace Cyphor;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        
        var settings = new CefSettings();
        settings.CefCommandLineArgs.Add("disable-web-security", "true");
        Cef.Initialize(settings);

        Text = "Cyphor";
        Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

        var browser = new ChromiumWebBrowser(Path.Combine(Environment.CurrentDirectory, "html", "index.html"));
        browser.Dock = DockStyle.Fill;
        
        
        Controls.Add(browser);

#if DEBUG
        browser.FrameLoadEnd += (sender, args) =>
        {
            if (args.Frame.IsMain)
            {
                browser.ShowDevTools();
            }
        };
#endif
    }
}