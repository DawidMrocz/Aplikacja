﻿namespace JobMicroservice.Contracts.InboxItemContracts
{
    public record UpdateInboxItem(int JobId, string JobDescription, string Type, string System, string Link, string Engineer, int Ecm, int Gpdm, string ProjectNumber, string Client, string ProjectName, string Status, string DueDate, string Received);
}
