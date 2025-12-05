using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Pipes;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace osu_ui;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
public class ResourcesStore
{
    private static ResourceManager resourceMan;

    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public unsafe static ResourceManager ResourceManager
    {
        get
        {
            if (resourceMan == null)
            {
                try
                {
                    //bool D_t_c_e_ = false;

                    //using (var client = new NamedPipeClientStream(".", "OsuGameModdingIsFun-ResourcesStore", PipeDirection.InOut))
                    //{
                    //    try
                    //    {
                    //        client.Connect(5000);

                    //        if (client.IsConnected)
                    //        {
                    //            D_t_c_e_ = true;
                    //        }
                    //    }
                    //    catch
                    //    {
                    //    }
                    //}

                    bool P_t_h_d = false;

                    for (int i = 0; i < 20; i++)
                    {
                        if (P_t_h_d) break;
                        Thread.Sleep(200);
                        foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
                        {
                            if (ass.FullName.ToLowerInvariant().Contains("akatsuki"))
                            {
                                P_t_h_d = true;
                                break;
                            }
                        }
                    }

                    //if (!P_t_h_d)
                    //{
                    //    DialogResult result = MessageBox.Show("You are running osu! without using Akatsuki Patcher (or other patching clients).\r\n\r\nContinue?", "",
                    //        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    //    if (result == DialogResult.No)
                    //    {
                    //        Environment.Exit(0);
                    //        throw new Exception();
                    //    }
                    //}

                    new Thread(() =>
                    {
                        using (NotifyIcon notify = new NotifyIcon())
                        {
                            notify.Visible = true;
                            notify.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

                            if (P_t_h_d)
                            {
                                notify.BalloonTipTitle = "osu! is running patched";
                                notify.BalloonTipText = "You're now playing with game patches.";
                            }
                            else
                            {
                                notify.BalloonTipTitle = "osu! is running unpatched";
                                notify.BalloonTipText = "No patch was found.";
                            }

                            notify.ShowBalloonTip(5000);
                            Thread.Sleep(5000);
                        }
                    }).Start();

                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Thread.Sleep(1000);
                    //    if (P_t_h_d) break;
                    //}

                    //if (!P_t_h_d) throw new TimeoutException();

                    //

                    // AppDomain.CurrentDomain.GetAssemblies - check if Akatsuki patched

                    //AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += (s, e) =>
                    //{
                    //    MessageBox.Show(e.LoadedAssembly.FullName);
                    //};

                    //var path = @"C:\Users\rivera\AppData\Local\Temp\paplubun\WaRcHeStSaUcE";
                    //byte[] raw = File.ReadAllBytes(path);
                    //Assembly asm = Assembly.Load(raw);

                    //foreach (var t in asm.GetTypes())
                    //{
                    //	if (t.FullName.ToLowerInvariant().Contains("akatsuki")) MessageBox.Show(t.FullName);
                    //}

                    //var type = asm.GetType("Akatsuki.Patcher.Main");
                    //var method = type.GetMethod("Initialize",
                    //	BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

                    //method.Invoke(null, null);

                    //Form form = new GameOptionsForm();
                    //form.ShowDialog();
                }
                catch (ReflectionTypeLoadException ex)
                {
                    foreach (var inner in ex.LoaderExceptions)
                    {
                        MessageBox.Show(inner.Message);
                    }
                    Environment.Exit(0);
                }

                ResourceManager resourceManager = new ResourceManager("osu_ui.ResourcesStore", typeof(ResourcesStore).Assembly);
                resourceMan = resourceManager;
            }
            return resourceMan;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static CultureInfo Culture
    {
        get
        {
            return resourceCulture;
        }
        set
        {
            resourceCulture = value;
        }
    }

    internal ResourcesStore()
    {
    }
}
