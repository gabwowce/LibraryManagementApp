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
    public class MemberListViewModel:ObservableObject
    {
        private readonly MemberRepository repository;

        public ICommand OpenLendBookWindowCommand { get; }
        public ICommand OpenMemberLoanDetailsCommand { get; }


        private ObservableCollection<MemberLoansDetails> _memberLoansDetails;
       
        public ObservableCollection<MemberLoansDetails> MemberLoansDetails
        {
            get => _memberLoansDetails;
            set
            {
                _memberLoansDetails = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Member> _members;

        public ObservableCollection<Member> Members
        {
            get => _members;
            set
            {
                _members = value;
                OnPropertyChanged();
            }
        }

        private Member _selectedMember;
        public Member SelectedMember
        {
            get => _selectedMember;
            set
            {
                _selectedMember = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedMember));
            }
        }


        public MemberListViewModel()
        {
            repository = new MemberRepository();
            OpenLendBookWindowCommand = new RelayCommand(OpenLendBookWindow);
            OpenMemberLoanDetailsCommand = new RelayCommand(OpenMemberLoanDetailsWindow);
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await LoadMembersAsync();
        }

        public async Task LoadMembersAsync()
        {
            try
            {
                var members = await repository.GetMembersAsync();
                Members = new ObservableCollection<Member>(members);

                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading members: {ex.Message}");
            }
        }

        private void OpenMemberLoanDetailsWindow(object parameter)
        {
            if (parameter is int memberId)
            {
                var memberLoanDetailsWindow = new MemberDetailsWindow(memberId);
                memberLoanDetailsWindow.ShowDialog();
            }
        }



        private void OpenLendBookWindow(object parameter)
        {
            if (parameter is int memberId)
            {
                var lendBookWindow = new LendBookWindow(memberId, null);
                lendBookWindow.ShowDialog();
            }
        }


    }

}
