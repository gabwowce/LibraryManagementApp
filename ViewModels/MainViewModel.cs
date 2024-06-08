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
        private readonly INavigationService _navigationService;

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

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            HomeViewCommand = new RelayCommand(_ => _navigationService.NavigateTo("HomeView"));
            BookListViewCommand = new RelayCommand(_ => _navigationService.NavigateTo("BookListView"));

            CurrentView = new HomeViewModel();
        }

    }
}
