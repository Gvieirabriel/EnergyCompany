using EnergyCompany.Domain.Entities;

namespace EnergyCompany.Application.Service
{
    internal interface IEndpointService
    {
        public void CreateEndpoint(string serialNumber, int modelId, int number, string firmwareVersion, int state);
        public bool DeleteEndpointById(string serialNumber);
        public void UpdateEndpointById(string serialNumber, int state);
        public List<Endpoint> GetAllEndpoints();
        public Endpoint FindEndpointById(string serialNumber);
    }
}
