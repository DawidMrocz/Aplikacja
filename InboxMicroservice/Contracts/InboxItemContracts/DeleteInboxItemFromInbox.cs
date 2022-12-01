namespace InboxMicroservice.Contracts.InboxItemContracts
{
    public record DeleteInboxItemFromInbox(
        int JobId,
        int UserId
    );
}