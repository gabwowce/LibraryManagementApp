using LibraryManagementApp.Helpers;
using LibraryManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.ViewModels
{
    internal class LoanDetailsViewModel:ObservableObject
    {
        private readonly MemberRepository repository;
        private int MemberID;
        private Member _member;
        public Member Member
        {
            get => _member;
            set
            {
                _member = value;
                OnPropertyChanged();
            }
        }

        public LoanDetailsViewModel(int memberID)
        {
            this.MemberID = memberID;
            repository = new MemberRepository();
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await LoadMemberbyIDAsync();
        }

        public async Task LoadMemberbyIDAsync()
        {
            try
            {
                Member = await repository.GetMemberbyIDAsync(MemberID);
                

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"----------> Error loading member by ID details: {ex.Message}");
            }
        }
    }
}
