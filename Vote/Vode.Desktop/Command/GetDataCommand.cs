using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vode.Desktop.Model;
using Vode.Desktop.ViewModel;

namespace Vode.Desktop.Command
{
    public class GetDataCommand : AsyncCommandBase
    {
        protected VoteViewModel ViewModel { get; set; }
        protected IVoteApiClient ApiClient { get; set; }
        public GetDataCommand(VoteViewModel viewModel, IVoteApiClient voteApiClient)
        {
            ViewModel = viewModel;
            ApiClient = voteApiClient;
        }


        protected async override Task ExecuteAsync(object parameter)
        {
            var voters = await ApiClient.GetVotersAsync();
            var candidates = await ApiClient.GetCandidatesAsync();

            ViewModel.Voters = new System.Collections.ObjectModel.ObservableCollection<Vote.Model.Voter>(voters);
            ViewModel.Candidates = new System.Collections.ObjectModel.ObservableCollection<Vote.Model.Candidate>(candidates);
        }
    }
}
