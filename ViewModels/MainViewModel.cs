using LibraryManagementApp.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                UpdateExpanderState();
            }
        }

        private bool _isBookListExpanded;
        public bool IsBookListExpanded
        {
            get { return _isBookListExpanded; }
            set
            {
                _isBookListExpanded = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BookListHeader));

            }
        }
        public string SelectedView
        {
            get
            {
                if (CurrentView == HomeVM)
                    return "Home";
                if (CurrentView == AllBooksVM)
                    return "BookList";
                if (CurrentView == MemberListVM)
                    return "MemberList";
                if (CurrentView == LoanListVM)
                    return "LoanList";
                return string.Empty;
            }
        }
        public string BookListHeader => IsBookListExpanded ? "▼ Book List" : "▶ Book List";

        public ICommand HomeViewCommand { get; }
        public ICommand MemberListViewCommand { get; }
        public ICommand LoanListViewCommand { get; }

        public ICommand SetCategoryCommand { get; }

        /*      public ICommand AllBooksViewCommand { get; }
              public ICommand ChildrenBooksViewCommand { get; }
              public ICommand FantasyBooksViewCommand { get; }
              public ICommand BiographyBooksViewCommand { get; }
              public ICommand HistoryBooksViewCommand { get; }
              public ICommand MisteryBooksViewCommand { get; }
              public ICommand RomanceBooksViewCommand { get; }
      */


        public HomeViewModel HomeVM { get; set; }
        public MemberListViewModel MemberListVM { get; set; }
        public LoanListViewModel LoanListVM { get; set; }
        public AllBooksViewModel AllBooksVM { get; set; }


        public MainViewModel()
        {
            HomeVM = new HomeViewModel(this);
            MemberListVM = new MemberListViewModel();
            LoanListVM = new LoanListViewModel();
            AllBooksVM = new AllBooksViewModel(this);

            CurrentView = HomeVM;


            HomeViewCommand = new RelayCommand(o =>
            {
                
                CurrentView = HomeVM;
            });
            MemberListViewCommand = new RelayCommand(o =>
            {
                
                CurrentView = MemberListVM;
            });

            LoanListViewCommand = new RelayCommand(o =>
            {
                
                CurrentView = LoanListVM;

            });

            SetCategoryCommand = new RelayCommand(o =>
            {
                SetBooksCategory(o as string);

            });


        }

        private void SetBooksCategory(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                AllBooksVM.Category = category;
                CurrentView = AllBooksVM;
                IsBookListExpanded = true;
            }
        }

        private void UpdateExpanderState()
        {
            IsBookListExpanded = CurrentView == AllBooksVM;
        }


    }
}
