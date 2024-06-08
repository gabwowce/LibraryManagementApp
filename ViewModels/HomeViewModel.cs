using LibraryManagementApp.Helpers;
using LibraryManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementApp.ViewModels
{
    public class HomeViewModel: ObservableObject
    {
        public ObservableCollection<Book> Books { get; set; }

        public ICommand HomeViewCommand { get; }
        public ICommand BookListViewCommand { get; }
        public ICommand MemberListViewCommand { get; }
        public ICommand LoanListViewCommand { get; }

        public HomeViewModel(MainViewModel mainViewModel)
        {
            Books = new ObservableCollection<Book>
        {
            new Book { Title = "Come and Get It", Author = "by Kiley Reid", ImageSource = "Images/Book1.jpg" },
            new Book { Title = "The Women", Author = "by Kristin Hannah", ImageSource = "Images/Book2.jpg" },
            new Book { Title = "The Fury", Author = "by Alex Michaelides", ImageSource = "Images/Book3.jpg" },
            new Book { Title = "Piglet", Author = "by Lottie Hazell", ImageSource = "Images/Book4.jpg" },
            new Book { Title = "Help Wanted", Author = "by Adelle Waldman", ImageSource = "Images/Book5.jpg" },
        };

            HomeViewCommand = mainViewModel.HomeViewCommand;
            BookListViewCommand = mainViewModel.BookListViewCommand;
            MemberListViewCommand = mainViewModel.MemberListViewCommand;
            LoanListViewCommand = mainViewModel.LoanListViewCommand;
        }
    }
}
