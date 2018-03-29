using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Prism.Commands;
using Prism.Mvvm;

namespace FoDicomPractice.ViewModels
{
    public class DicomTagTextViewModel : BindableBase
    {
        public DicomTagTextViewModel()
        {
            DragOverCommand = new DelegateCommand<DragEventArgs>(DragOver);
            DropCommand = new DelegateCommand<DragEventArgs>(Drop);
        }

        public DelegateCommand<DragEventArgs> DragOverCommand { get; set; }

        public DelegateCommand<DragEventArgs> DropCommand { get; set; }
        
        private string _myFileName = String.Empty;
        /// <summary>ドロップされたファイル名を保持します</summary>
        public string FileName
        {
            get { return _myFileName; }
            set { SetProperty(ref _myFileName, value); }
        }
        
        private void DragOver(DragEventArgs e)
        {
            if (e != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                {
                    e.Effects = DragDropEffects.Move;
                }
                else
                {
                    e.Effects = DragDropEffects.None;
                }
                e.Handled = true;
                FileName = "accept";
            }
            FileName = "empty";
        }
 
        private void Drop(DragEventArgs e) {
            
            if (e != null && null != e.Data && e.Data.GetDataPresent(DataFormats.FileDrop)) {
                var data = e.Data.GetData(DataFormats.FileDrop) as string[];
                if(data.Any()) FileName = data[0];
            }
        }
    }
}