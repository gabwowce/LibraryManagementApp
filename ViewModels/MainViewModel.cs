using LibraryManagementApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand HomeViewCommand { get; }
        public ICommand BookListViewCommand { get; }
        public ICommand MemberListViewCommand { get; }
        public ICommand LoanListViewCommand { get; }
        public HomeViewModel HomeVM { get; set; }
        public BookListViewModel BookListVM { get; set; }
        public MemberListViewModel MemberListVM { get; set; }
        public LoanListViewModel LoanListVM { get; set; }


        public MainViewModel()
        {
            HomeVM = new HomeViewModel(this);
            BookListVM = new BookListViewModel();
            CurrentView = HomeVM;


            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            BookListViewCommand = new RelayCommand(o =>
            {
                CurrentView = BookListVM;
            });
            MemberListViewCommand = new RelayCommand(o =>
            {
                CurrentView = MemberListVM;
            });

            LoanListViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoanListVM;
            });
        }

    }
}
