using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventPlanning.Domain.Models;

namespace EventPlanning.Domain.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<DomainUser>> GetUsers();

        Task<DomainUser> GetUser(Guid userId);

        Task<DomainUser> GetUser(string email, string password);

        Task<DomainUser> GetUserOfEvent(DomainEvent @event);

        Task CreateUser(DomainUser user);

        Task DeleteUser(DomainUser user);

        Task UpdateUser(DomainUser user);
    }
}
