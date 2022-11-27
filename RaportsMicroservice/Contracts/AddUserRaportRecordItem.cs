namespace RaportsMicroservice.Contracts
{
    public record AddUserRaportRecordItem(int UserId, string Name, double Hours, string SendDate, string System, int Ecm, int Gpdm, string ProjectNumber, int Components, int DrawingOfComponent, int DrawingOfAssemblies, DateTime DueDate, DateTime StartedDate, DateTime FinishedDate,string Client);
}