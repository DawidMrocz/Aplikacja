namespace UserMicroservice.Contracts.InboxContracts
{
    public record UpdateUserInbox(int UserId, string Name, string Photo, string CCtr, string ActTyp);
}