using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227
using Caliburn.Micro;
using VictorinaUniversal.ViewModels;
using VictorinaUniversal.Views;

namespace VictorinaUniversal
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App
    {
        private WinRTContainer _container;

        public App()
        {
            this.InitializeComponent();
        }

        protected async override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();
            RegisterViewModels();
        }

        private void RegisterViewModels()
        {
            _container.PerRequest<MainViewModel>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            DisplayRootView<MainView>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }


        protected override void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception);
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            _container.RegisterNavigationService(rootFrame);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}