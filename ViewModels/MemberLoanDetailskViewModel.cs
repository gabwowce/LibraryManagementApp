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
    public class MemberLoanDetailskViewModel: ObservableObject
    {
        private readonly LoanRepository repository;

        private int _memberID;
        public int MemberID { get; }

        private ObservableCollection<MemberLoansDetails> _membersDetails;
        public ObservableCollection<MemberLoansDetails> MembersDetails
        {
            get => _membersDetails;
            set
            {
                _membersDetails = value;
                OnPropertyChanged();
            }
        }


        public MemberLoanDetailskViewModel(int memberID)
        {
            this.MemberID = memberID;
            repository = new LoanRepository();
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await LoadMembersLoanDetailsAsync();
        }

        public async Task LoadMembersLoanDetailsAsync()
        {
            try
            {
                MembersDetails = await repository.GetMemberLoansDetaisAsync(MemberID);
                Debug.WriteLine("----------> Repository of Member details is working on it");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"----------> Error loading member loans details: {ex.Message}");
            }
        }

    }
}
