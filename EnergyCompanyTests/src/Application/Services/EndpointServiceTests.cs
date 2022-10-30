using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnergyCompany.src.Domain.Entities;
using EnergyCompany.src.Domain.Exceptions;

namespace EnergyCompany.src.Application.Service.Tests
{
    [TestClass()]
    public class EndpointServiceTests
    {
        EndpointService endpointService = new EndpointService();

        [TestMethod()]
        public void Create_Invalid_Endpoint()
        {
            endpointService.CreateEndpoint("01", 16, 1, "1.0", 0);
            Assert.ThrowsException<AlreadyExistsException>(() => endpointService.CreateEndpoint("01", 16, 1, "1.0", 0));
        }

        [TestMethod()]
        public void Find_Valid_Endpoint()
        {
            endpointService.CreateEndpoint("02", 16, 1, "1.0", 0);
            Endpoint endpoint = endpointService.FindEndpointById("02");
            Assert.IsNotNull(endpoint);
        }

        [TestMethod()]
        public void Find_Invalid_Endpoint()
        {
            Assert.ThrowsException<ModelNotFoundException>(() => endpointService.FindEndpointById("03"));
        }

        [TestMethod()]
        public void Delete_Valid_Endpoint()
        {
            bool deleted = endpointService.DeleteEndpointById("01");
            Assert.IsTrue(deleted);
        }
    }
}