namespace InboxMicroservice.Contracts.RaportContracts
{
    public record UpdateRaport(int UserId, int JobId, string JobDescription, string Type, string System, string Link, string Engineer, int Ecm, int Gpdm, string ProjectNumber, string Client, string Status, string DueDate, string Received);
}
