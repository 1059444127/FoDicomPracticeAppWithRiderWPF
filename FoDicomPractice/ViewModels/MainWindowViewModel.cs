using System;
using System.Collections.ObjectModel;
using System.Threading;
using CommonServiceLocator;
using FoDicomPractice.UIHelpers;
using MahApps.Metro.Controls;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace FoDicomPractice.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public IRegionManager RegionManager { get; set; } = ServiceLocator.Current.GetInstance<IRegionManager>();
        
        public MainWindowViewModel()
        {
            ShowCommand = new DelegateCommand<object>(Show);
        }

        public string Title { get; set; } = "Fo-Dicom Practice";
        
        public DelegateCommand<object> ShowCommand { get; set; }

        private Lazy<ObservableCollection<HamburgerMenuGlyphItem>> _Menus 
            = new Lazy<ObservableCollection<HamburgerMenuGlyphItem>>(menuFactoryMethod, LazyThreadSafetyMode.ExecutionAndPublication);

        public ObservableCollection<HamburgerMenuGlyphItem> Menus
        {
            get => _Menus.Value;
            set
            {
                var menus = _Menus.Value;
                SetProperty(ref menus, value);
            }
        }

        private static ObservableCollection<HamburgerMenuGlyphItem> menuFactoryMethod()
        {
            var collection = new ObservableCollection<HamburgerMenuGlyphItem>();
            var menuMain = new HamburgerMenuGlyphItem();
            menuMain.Glyph = "\uEA8A";
            menuMain.Label = "メイン";
            menuMain.Tag = "MainView";
            collection.Add(menuMain);

            var menuSub = new HamburgerMenuGlyphItem();
            menuSub.Glyph = "\uE115";
            menuSub.Label = "サブ";
            menuSub.Tag = "SubView";
            collection.Add(menuSub);
            
            menuSub = new HamburgerMenuGlyphItem();
            menuSub.Glyph = "\uE16F";
            menuSub.Label = "Dicomタグ解析";
            menuSub.Tag = "DicomTagTextView";
            collection.Add(menuSub);
            
            return collection;
        }
        
        private void Show(object obj)
        {
            if(obj == null) return;
            if (obj is HamburgerMenuGlyphItem)
            {
                var menuItem = (HamburgerMenuGlyphItem) obj;
                RegionManager.RequestNavigate(RegionNames.MainRegion, menuItem.Tag.ToString());
            }
        }
    }
}