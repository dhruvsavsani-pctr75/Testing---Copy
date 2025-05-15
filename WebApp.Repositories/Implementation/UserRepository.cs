using WebApp.Entities.Data;
using WebApp.Entities.Models;
using WebApp.Repositories.Interface;

namespace WebApp.Repositories.Implementation;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly TestingFinalContext _context;

    public UserRepository(TestingFinalContext context) : base(context)
    {
        _context = context;
    }
}
