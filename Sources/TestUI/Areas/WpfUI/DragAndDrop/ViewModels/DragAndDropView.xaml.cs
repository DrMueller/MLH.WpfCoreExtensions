using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;
using Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.InfosAndExceptions.ViewModels.InfosAndExceptions;

namespace Mmu.Mlh.WpfCoreExtensions.TestUI.Areas.WpfUI.DragAndDrop.ViewModels
{
    /// <summary>
    /// Interaction logic for DragAndDropView.xaml
    /// </summary>
    public partial class DragAndDropView : UserControl, IViewMap<DragAndDropViewModel>
    {
        public DragAndDropView()
        {
            InitializeComponent();
        }
    }
}
