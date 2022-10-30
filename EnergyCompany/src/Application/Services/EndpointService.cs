using EnergyCompany.src.Domain.Entities;
using EnergyCompany.src.Domain.Exceptions;
using EnergyCompany.src.Infrastructure.Repositories;

namespace EnergyCompany.src.Application.Service
{
    public class EndpointService : IEndpointService
    {
        private EndpointRepository endpointRepository = new EndpointRepository();

        public void CreateEndpoint(string serialNumber, int modelId, int number, string firmwareVersion, int state)
        {
            Endpoint endpoint = endpointRepository.FindEndpointById(serialNumber);
            if(endpoint != null) throw new AlreadyExistsException("Endpoint already exists");
            Endpoint newEndpoint = new Endpoint(serialNumber, modelId, number, firmwareVersion, state);
            endpointRepository.InsertEndpoint(newEndpoint);
        }

        public bool DeleteEndpointById(string serialNumber)
        {
            Endpoint endpoint = this.FindEndpointById(serialNumber);
            return endpointRepository.DeleteEndpoint(endpoint);
        }

        public Endpoint FindEndpointById(string serialNumber)
        { 
            Endpoint endpoint = endpointRepository.FindEndpointById(serialNumber);
            if (endpoint == null) throw new ModelNotFoundException("Endpoint not found");
            return endpoint;
        }

        public List<Endpoint> GetAllEndpoints()
        {
            return endpointRepository.getEndpoints();
        }

        public void UpdateEndpointById(string serialNumber, int state)
        {
            Endpoint endpoint = this.FindEndpointById(serialNumber);
            endpoint.SwitchState = state;
            endpointRepository.UpdateEndpoint(endpoint);
        }
    }
}
