using EventPlanning.Infrastructure.Interfaces;
using EventPlanning.Infrastructure.Models;
using EventPlanning.InfrastructureServices.Contexts;

namespace EventPlanning.InfrastructureServices.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;

        public UnitOfWork(MyContext context)
        {
            _context = context;

        }

        public IGenericRepository<InfrastructureUser> Users => new GenericRepository<InfrastructureUser>(_context);
        public IGenericRepository<InfrastructureEvent> Events => new GenericRepository<InfrastructureEvent>(_context);
        public IGenericRepository<InfrastructureField> Fields => new GenericRepository<InfrastructureField>(_context);
        public IEventsFieldsRepository EventsFields => new EventsFieldsRepository(_context);
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
