namespace InboxMicroservice.Contracts
{
    public record CreateUserRaportRecordItem(int UserId, string Name, double Hours, DateTime SendDate, string System, int Ecm, int Gpdm, string ProjectNumber, int Components, int DrawingOfComponent, int DrawingOfAssemblies, DateTime DueDate, DateTime StartedDate, DateTime FinishedDate, string Client);
}