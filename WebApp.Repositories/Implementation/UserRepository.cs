using WebApp.Entities.Data;
using WebApp.Entities.Models;
using WebApp.Repositories.Interface;

namespace WebApp.Repositories.Implementation;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly TestFinalContext _context;

    public UserRepository(TestFinalContext context) : base(context)
    {
        _context = context;
    }
}
