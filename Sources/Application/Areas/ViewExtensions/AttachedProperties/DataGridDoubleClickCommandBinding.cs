using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.AttachedProperties
{
    public static class DataGridDoubleClickCommandBinding
    {
        public static readonly DependencyProperty DataGridDoubleClickProperty = DependencyProperty.RegisterAttached("DataGridDoubleClickCommand", typeof(ICommand), typeof(DataGridDoubleClickCommandBinding), new PropertyMetadata(AttachOrRemoveDataGridDoubleClickEvent));

        public static void AttachOrRemoveDataGridDoubleClickEvent(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is DataGrid dataGrid)
            {
                if (args.OldValue == null && args.NewValue != null)
                {
                    dataGrid.MouseDoubleClick += ExecuteDataGridDoubleClick;
                }
                else if (args.OldValue != null && args.NewValue == null)
                {
                    dataGrid.MouseDoubleClick -= ExecuteDataGridDoubleClick;
                }
            }
        }

        public static ICommand GetDataGridDoubleClickCommand(DependencyObject dependencyObject)
        {
            return (ICommand)dependencyObject.GetValue(DataGridDoubleClickProperty);
        }

        public static void SetDataGridDoubleClickCommand(DependencyObject dependencyObject, ICommand value)
        {
            dependencyObject.SetValue(DataGridDoubleClickProperty, value);
        }

        private static void ExecuteDataGridDoubleClick(object sender, MouseButtonEventArgs args)
        {
            var dependencyObject = sender as DependencyObject;
            var cmd = (ICommand)dependencyObject?.GetValue(DataGridDoubleClickProperty);
            if (cmd == null)
            {
                return;
            }

            if (cmd.CanExecute(dependencyObject))
            {
                cmd.Execute(dependencyObject);
            }
        }
    }
}