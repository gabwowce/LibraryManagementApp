using LibraryManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManagementApp
{

    public partial class MainWindow : Window
    {
        private bool _isUserAction;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            _isUserAction = true;
            var expander = sender as Expander;
            if (expander != null && expander.IsExpanded)
            {
                var viewModel = DataContext as ViewModels.MainViewModel;
                if (viewModel != null)
                {
                    viewModel.IsBookListExpanded = true;
                }
            }
            _isUserAction = false;
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            if (_isUserAction)
            {
                var expander = sender as Expander;
                if (expander != null)
                {
                    expander.IsExpanded = true;
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

    }
}
