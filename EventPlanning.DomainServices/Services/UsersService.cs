using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventPlanning.Domain.Interfaces;
using EventPlanning.Domain.Models;
using EventPlanning.DomainServices.Mappers;
using EventPlanning.Infrastructure.Interfaces;

namespace EventPlanning.DomainServices.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DomainUser>> GetUsers()
        {
            var users = await _unitOfWork.Users.GetAll();

            return users.Select(_ => _.ToDomain());
        }

        public async Task<DomainUser> GetUser(Guid userId)
        {
            var user = await _unitOfWork.Users.Get(userId);

            return user.ToDomain();
        }

        public async Task<DomainUser> GetUser(string email, string password)
        {
            var users = await GetUsers();

            foreach (var user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<DomainUser> GetUserOfEvent(DomainEvent @event)
        {
            var users = await GetUsers();

            return users.FirstOrDefault(_ => _.Id == @event.UserId);
        }

        public async Task CreateUser(DomainUser user)
        {
            await _unitOfWork.Users.Create(user.ToInfrastructure());
        }

        public async Task DeleteUser(DomainUser user)
        {
            await _unitOfWork.Users.Delete(user.ToInfrastructure());
        }

        public async Task UpdateUser(DomainUser user)
        {
            await _unitOfWork.Users.Update(user.ToInfrastructure());
        }
    }
}
