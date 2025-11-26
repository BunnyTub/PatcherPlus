using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Akatsuki.Loader
{
    public static class LoaderHub
    {
        [NullableContext(0)]
        public delegate void OnConnectionFailureHandler();

        public static event OnConnectionFailureHandler OnConnectionFailure;

        public static event OnConnectionFailureHandler OnRetry;

        [NullableContext(1)]
        private static async Task LoaderUpdates(LoaderUpdates updates)
        {
            MainWindow app = App.Context;
            if (await Updater.CheckUpdates(updates.Loader))
            {
                app.Exit();
            }
            app.Dispatcher.Invoke(delegate
            {
                app.DoneLoading(updates);
            });
        }

        private static void PatcherResponse(byte[] data)
        {
            //BackgroundTasks.Stop();
            if (Injector.Inject(Program.OsuExecutablePath, data))
            {
                // see you next time
            }
        }

        private static void LoaderHub_OnRetry()
        {
            //MainWindow context = App.Context;
            //context.Dispatcher.Invoke(context.PlayLoading);
        }

        private static void LoaderHub_OnConnectionFailure()
        {
            //MainWindow app = App.Context;
            //app.Dispatcher.Invoke(app.FailedLoading);
            //int i;
            //for (i = 10; i > 0; i--)
            //{
            //    app.Dispatcher.Invoke(delegate
            //    {
            //        app.UpdateRetrySeconds(i);
            //    });
            //    Thread.Sleep(1000);
            //}
        }

        //nullable
        public static async Task PatcherRequest(string releaseStream)
        {
            PatcherResponse(await new HttpClient().GetByteArrayAsync("https://air_conditioning.akatsuki.gg/patcher/patcher-version?branch=" + releaseStream));
        }

        static LoaderHub()
        {
            OnRetry += LoaderHub_OnRetry;
            OnConnectionFailure += LoaderHub_OnConnectionFailure;
        }

        public static async void Connect()
        {
            bool flag = false;
            while (true)
            {
                try
                {
                    if (flag && LoaderHub.OnRetry != null)
                    {
                        LoaderHub.OnRetry();
                    }
                    await LoaderUpdates(await new HttpClient().GetFromJsonAsync<LoaderUpdates>("https://air_conditioning.akatsuki.gg/loader/loader-updates"));
                    break;
                }
                catch (Exception)
                {
                    if (LoaderHub.OnConnectionFailure != null)
                    {
                        LoaderHub.OnConnectionFailure();
                    }
                    flag = true;
                }
            }
        }
    }
}
