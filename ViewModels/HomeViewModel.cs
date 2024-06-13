using LibraryManagementApp.Helpers;
using LibraryManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagementApp.ViewModels
{
    public class HomeViewModel: ObservableObject
    {
        private readonly BookRepository repository;

        public ICommand HomeViewCommand { get; }
        public ICommand MemberListViewCommand { get; }
        public ICommand LoanListViewCommand { get; }
        public ICommand AllBooksViewCommand { get; }

        private MainViewModel _mainViewModel;

        private ObservableCollection<Book> _books;

        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));

            repository = new BookRepository();

            AllBooksViewCommand = new RelayCommand(o => _mainViewModel.CurrentView = _mainViewModel.AllBooksVM);
            MemberListViewCommand = new RelayCommand(o => _mainViewModel.CurrentView = _mainViewModel.MemberListVM);
            LoanListViewCommand = new RelayCommand(o => _mainViewModel.CurrentView = _mainViewModel.LoanListVM);

            _ = InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await LoadBooksByCategoryAsync();
        }

        public async Task LoadBooksByCategoryAsync()
        {
            try
            {
                var books = await repository.GetBooksByCategoryAsync("7");
                Books = new ObservableCollection<Book>(books);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading books: {ex.Message}");
            }
        }


    }
}
