using LibraryManagementApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using LibraryManagementApp.Models;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Diagnostics;

namespace LibraryManagementApp.ViewModels
{
    internal class LendBookViewModel : ObservableObject
    {
        private int? _memberID;
        private int? _bookID;
        private DateTime _loanDate;
        public ICommand LendBookCommand { get; }
        private LoanRepository repository;

        public int? MemberID
        {
            get => _memberID;
            set
            {
                _memberID = value;
                OnPropertyChanged();
            }
        }

        public int? BookID
        {
            get => _bookID;
            set
            {
                _bookID = value;
                OnPropertyChanged();
            }
        }

        public DateTime LoanDate
        {
            get => _loanDate;
            set
            {
                _loanDate = value;
                OnPropertyChanged();
            }
        }


        public LendBookViewModel(int? memberId, int? bookID)
        {
            MemberID = memberId;
            BookID = bookID;
            LoanDate = DateTime.Now;
            LendBookCommand = new RelayCommand(LendBook);
            repository = new LoanRepository();
        }

        private void LendBook(object parameter)
        {
            try
            {
                if (MemberID.HasValue && BookID.HasValue)
                {
                    Loans newLoan = new Loans()
                    {
                        MemberID = MemberID.Value,
                        BookID = BookID.Value,
                        DateofLoan = LoanDate,
                        Status = "Active"
                    };

                    repository.UploadLoan(newLoan);

                    MessageBox.Show("Loan successfully created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"------------> Error updating new loan: {ex.Message}");
            }


            try
            {
                Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive)?.Close();
            }
            catch 
            {
                Debug.WriteLine($"------------> Error closing loan window");
            }
            
        }


    }
}
