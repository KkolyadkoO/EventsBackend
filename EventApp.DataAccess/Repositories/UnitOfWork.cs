using AutoMapper;
using EventApp.Core.Abstractions;
using EventApp.DataAccess.Repositories;

namespace EventApp.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly EventAppDbContext _context;
    private readonly IMapper _mapper;

    public ICategoryOfEventsRepository Categories { get; private set; }
    public IEventsRepository Events { get; private set; }
    public IMembersOfEventRepository Members { get; private set; }
    public IUserRepository Users { get; }

    public UnitOfWork(EventAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        Categories = new CategoryOfEventsRepository(_context, _mapper);
        Events = new EventsRepository(_context, _mapper);
        Members = new MembersOfEventRepository(_context, _mapper);
        Users = new UserRepository(_context,_mapper);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    

    public async Task<int> Complete()
    {
        return _context.SaveChanges();
    }
}