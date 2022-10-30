﻿using EnergyCompany.src.Domain.Entities;

namespace EnergyCompany.src.Domain.Repository
{
    public interface IEndpointRepository
    {
        void InsertEndpoint(Endpoint endpoint);
        void UpdateEndpoint(Endpoint endpoint);
        List<Endpoint> getEndpoints();
        bool DeleteEndpoint(Endpoint endpoint);
        Endpoint FindEndpointById(string SerialNumber);
    }
}
