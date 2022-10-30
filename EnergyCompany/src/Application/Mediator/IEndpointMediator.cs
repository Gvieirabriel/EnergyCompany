namespace EnergyCompany.src.Application.Mediator
{
    internal interface IEndpointMediator
    {
        public void InsertEndpoint();
        public void UpdateEndpoint();
        public void DeleteEndpoint();
        public void FindEndpoint();
        public void ListEndpoints();
    }
}
