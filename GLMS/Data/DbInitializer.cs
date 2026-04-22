namespace GLMS.Data
{
    using GLMS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Clients.Any()) return;

            var clients = new List<Client>
        {
            new Client { Name = "Client A", ContactDetails = "123", Region = "Durban" },
            new Client { Name = "Client B", ContactDetails = "456", Region = "Cape Town" },
            new Client { Name = "Client C", ContactDetails = "789", Region = "Johannesburg" },
            new Client { Name = "Client D", ContactDetails = "321", Region = "Pretoria" },
            new Client { Name = "Client E", ContactDetails = "654", Region = "PE" }
        };

            context.Clients.AddRange(clients);
            context.SaveChanges();

            var contracts = new List<Contract>();

            foreach (var client in context.Clients)
            {
                for (int i = 0; i < 2; i++)
                {
                    contracts.Add(new Contract
                    {
                        ClientId = client.ClientId,
                        StartDate = DateTime.Now.AddDays(-10),
                        EndDate = DateTime.Now.AddDays(30),
                        Status = "Active",
                        ServiceLevel = "Standard"
                    });
                }
            }

            context.Contracts.AddRange(contracts);
            context.SaveChanges();
        }
    }
}
