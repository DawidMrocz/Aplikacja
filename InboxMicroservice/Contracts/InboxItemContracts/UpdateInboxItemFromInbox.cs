
namespace InboxMicroservice.Contracts.InboxItemContracts
{
    public record UpdateInboxItemFromInbox(
        int JobId,
        string Status, 
        string WhenComplete,
        string Started,
        string Finished
    );
}
