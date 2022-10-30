using EnergyCompany.src.Domain.Entities;
using EnergyCompany.src.Domain.Repository;

namespace EnergyCompany.src.Infrastructure.Repositories
{
    internal class EndpointRepository : IEndpointRepository
    {
        private static readonly List<Endpoint> endpoints = new List<Endpoint>();
        public void InsertEndpoint(Endpoint endpoint)
        {
            endpoints.Add(endpoint);
        }

        public Endpoint FindEndpointById(string serialNumber)
        {
            return endpoints.Find(i => i.SerialNumber == serialNumber);
        }

        public List<Endpoint> getEndpoints()
        {
            return endpoints;
        }

        public bool DeleteEndpoint(Endpoint endpoint)
        {
            return endpoints.Remove(endpoint);
        }

        public void UpdateEndpoint(Endpoint endpoint)
        {
            this.DeleteEndpoint(endpoint);
             this.InsertEndpoint(endpoint);
        }
    }
}
