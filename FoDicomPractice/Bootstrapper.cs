using System.Windows;
using FoDicomPractice.Modules;
using FoDicomPractice.Views;
using Prism.Modularity;
using Prism.Unity;
using Unity;

namespace FoDicomPractice
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
        
        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(MainModule));
        }
    }
}