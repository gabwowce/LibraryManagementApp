using LibraryManagementApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace LibraryManagementApp.ViewModels
{
    internal class LendBookViewModel : ObservableObject
    {
        private int _memberID;
        private int? _bookID;
        private DateTime _loanDate;

        public int MemberID
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


        public LendBookViewModel(int memberId)
        {
            MemberID = memberId;
            LoanDate = DateTime.Now;
            
        }

    
}
}
