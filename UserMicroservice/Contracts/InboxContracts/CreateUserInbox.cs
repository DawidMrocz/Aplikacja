namespace UserMicroservice.Contracts.InboxContracts
{
    public record CreateUserInbox(int UserId, string Name, string Photo, string CCtr, string ActTyp);
}