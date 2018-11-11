using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Hardcodet.Wpf.TaskbarNotification;
using Mousepad.Views;

namespace Mousepad
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ActiveGamepadsView _activeGamepadsView;
        protected override void OnStartup(StartupEventArgs e)
        {
            using (Mutex mutex = new Mutex(false, @"Global\MousepadApplicationMutex"))
            {
                if (mutex.WaitOne(0, false))
                {
                    base.OnStartup(e);
                    //I am aware that code below this comment is ugly
                    TaskbarIcon tb = (TaskbarIcon)FindResource("TrayIcon");
                    tb.TrayMouseDoubleClick += (sender, args) =>
                    {
                        _activeGamepadsView.Show();
                        _activeGamepadsView.Activate();
                    };
                    tb.MenuActivation = PopupActivationMode.RightClick;
                    tb.TrayRightMouseUp += (sender, args) =>
                    {

                    };
                    ContextMenu menu = new ContextMenu();
                    MenuItem item = new MenuItem
                    {
                        Header = "Settings"
                    };
                    item.Click += (sender, args) =>
                    {
                        new SettingsView().Show();
                    };
                    menu.Items.Add(item);
                    item = new MenuItem
                    {
                        Header = "Close"
                    };
                    item.Click += (sender, args) =>
                    {
                        Environment.Exit(0);
                    };

                    menu.Items.Add(item);
                    tb.ContextMenu = menu;
                }
            }
        }
        
    }
}
