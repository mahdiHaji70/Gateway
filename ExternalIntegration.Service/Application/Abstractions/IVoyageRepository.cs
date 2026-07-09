using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface IVoyageRepository : IRepository<Voyage>
    {
      
        Task<DateTime> GetLastDateAsync();

    }
}
