using System.Collections;
using System.Collections.Generic;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.Infrastructure.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<InfrastructureUser> GetAllUsers();

        InfrastructureUser GetUser(int userId);

        void CreateUser(InfrastructureUser user);

        void DeleteUser(int userId);
    }
}
