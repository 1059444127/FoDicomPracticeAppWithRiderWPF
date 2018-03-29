using FoDicomPractice.Views;
using Prism.Modularity;
using Unity;
using Unity.Attributes;

namespace FoDicomPractice.Modules
{
    public class MainModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public void Initialize()
        {
            Container.RegisterInstance<object>(nameof(MainView), new MainView());
            Container.RegisterInstance<object>(nameof(DicomTagTextView), new DicomTagTextView());
            Container.RegisterInstance<object>(nameof(SubView), new SubView());
        }
    }
}