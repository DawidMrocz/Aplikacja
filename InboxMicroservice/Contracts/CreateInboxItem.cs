﻿

namespace JobMicroservice.Contracts
{
    public record CreateInboxItem(int UserId,int JobId, string JobDescription, string Type, string System, string Link, string Engineer, int Ecm, int Gpdm, string ProjectNumber, string Client, string SapText, string Status);
}
