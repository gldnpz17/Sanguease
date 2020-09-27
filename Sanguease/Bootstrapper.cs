using IoCContainerLibrary;
using Sanguease.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sanguease
{
    //Sanguease
    //Firdaus Bisma S.(19/444051/TK/49247)(Kelas: Senin B)

    class Bootstrapper
    {
        private IContainer _container;

        public Bootstrapper()
        {
            Application.Current.DispatcherUnhandledException += (sender, e) => MessageBox.Show(e.Exception.Message, "Unhandled Exception Thrown");
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => MessageBox.Show(e.ExceptionObject.ToString(), "Unhandled Exception");

            ContainerConfig config = new ContainerConfig();

            _container = config.Configure();

            _container.GetInstance<ShellView>().Show();
        }
    }
}
