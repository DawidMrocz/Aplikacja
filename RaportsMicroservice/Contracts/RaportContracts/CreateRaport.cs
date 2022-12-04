namespace InboxMicroservice.Contracts.RaportContracts
{
    public record CreateRaport(int UserId, string Name, int JobId, int InboxItemId,double hours, string System, int Ecm, int Gpdm, string ProjectNumber, string Client, string Status, int Components,int DrawingsComponents, int DrawingsAssembly, string DueDate, string Started,string Finished);
}
