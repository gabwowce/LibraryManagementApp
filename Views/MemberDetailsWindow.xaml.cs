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
using System.Windows.Shapes;

namespace LibraryManagementApp.Views
{

    public partial class MemberDetailsWindow : Window
    {
        private int MemberID;
        public MemberDetailsWindow(int memberID)
        {
            InitializeComponent();
            this.MemberID = memberID;
            DataContext = new MemberLoanDetailskViewModel(this.MemberID);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
