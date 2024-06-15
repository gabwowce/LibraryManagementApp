using LibraryManagementApp.Helpers;
using LibraryManagementApp.Models;
using LibraryManagementApp.Views;
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
    public class LoanListViewModel: ObservableObject
    {
        private readonly LoanRepository repository;
        public ICommand OpenLoanDetailsWindowCommand { get; }

        private ObservableCollection<Loans> _loans;

        public ObservableCollection<Loans> Loans
        {
            get => _loans;
            set
            {
                _loans = value;
                OnPropertyChanged();
            }
        }

        


        public LoanListViewModel()
        {
            repository = new LoanRepository();
            OpenLoanDetailsWindowCommand = new RelayCommand(OpenLoanDetailsWindow);
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await LoadLoansAsync();
        }

        public async Task LoadLoansAsync()
        {
            try
            {
                var loans = await repository.GeLoansAsync();
                Loans = new ObservableCollection<Loans>(loans);


            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading books: {ex.Message}");
            }
        }

        private void OpenLoanDetailsWindow(object parameter)
        {
            if (parameter is int memberId)
            {
                var memberLoanDetailsWindow = new LoanDetailsWindow(memberId);
                memberLoanDetailsWindow.ShowDialog();
            }
        }


    }
}

