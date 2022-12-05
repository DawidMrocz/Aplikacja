namespace InboxMicroservice.Contracts.InboxItemContracts
{
    public record DeleteUserJobFromInbox(
        int JobId,
        int UserId
    );
}