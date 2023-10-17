using Autofac;
using ProgrammSystem.BLL.Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WpfApp1.BLL.Autofac;
using WpfApp1.Interfaces;
using WpfApp1.vm;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var builderBase = new ContainerBuilder();

            builderBase.RegisterModule(new ServicesModule());
            builderBase.RegisterModule(new ContextFactoriesModule());

            var containerBase = builderBase.Build();

            //var viewmodelBase = new MainWindowViewModel(containerBase.Resolve<IProgramRobot>());

            //var viewBase = new MainWindow { DataContext = viewmodelBase };

            var viewmodelBase = new AuthorizationVM(containerBase.Resolve<IUserService>(), containerBase.Resolve<IDb>());

            var viewBase = new Authorization { DataContext = viewmodelBase };

            viewBase.Show();
        }

        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Ошибка\n" + e.Exception.StackTrace + " " + "Исключение: "
                            + e.Exception.GetType().ToString() + " " + e.Exception.Message);

            e.Handled = true;
        }
    }
}
