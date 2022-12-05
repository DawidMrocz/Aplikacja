
namespace InboxMicroservice.Contracts.InboxItemContracts
{
    public record UpdateJobFromInbox(
        int JobId,
        string Status, 
        string WhenComplete,
        string Started,
        string Finished
    );
}
