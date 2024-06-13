using LibraryManagementApp.Helpers;
using LibraryManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.ViewModels
{
    public class LoanListViewModel: ObservableObject
    {
        private readonly LoanRepository repository;

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


    }
}

