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
    public class AllBooksViewModel : ObservableObject
    {
        private MainViewModel _mainViewModel;
        private readonly BookRepository repository;
        private string _category;

        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged();
                    _ = LoadBooksByCategoryAsync();
                }
            }
        }

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

        public ICommand SetCategoryCommand { get; }

        public AllBooksViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
            repository = new BookRepository();
            Category = "All";
            
            _ = InitializeAsync();

            


        }

        private async Task InitializeAsync()
        {
            await LoadBooksByCategoryAsync();
        }

        public async Task LoadBooksByCategoryAsync()
        {
            var books = await repository.GetBooksByCategoryAsync(Category);
            Books = new ObservableCollection<Book>(books);
        }

     
    }
}
