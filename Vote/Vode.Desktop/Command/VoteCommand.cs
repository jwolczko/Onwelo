using System.Threading.Tasks;
using Vode.Desktop.Model;
using Vode.Desktop.ViewModel;

namespace Vode.Desktop.Command
{
    public class VoteCommand : AsyncCommandBase
    {
        protected VoteViewModel ViewModel { get; init; }
        protected IVoteApiClient ApiClient { get; init; }
        public VoteCommand(VoteViewModel viewModel, IVoteApiClient apiClient)
        {
            ViewModel = viewModel;
            ApiClient = apiClient;
        }

        protected override Task ExecuteAsync(object parameter)
        {
            var vote = new Vote.Model.Vote
            {
                Voter = ViewModel.SelectedVoter,
                Candidate= ViewModel.SelectedCandidate
            };

            ApiClient.PostVoteAsync(vote)
                .ContinueWith(t => { 
                ViewModel.GetDataCommand.Execute(null);
            });


            return Task.CompletedTask;
        }
    }
}
