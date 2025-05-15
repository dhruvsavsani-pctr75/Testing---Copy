using WebApp.Entities.Data;
using WebApp.Entities.Models;
using WebApp.Repositories.Interface;

namespace WebApp.Repositories.Implementation;

public class JobRepository : GenericRepository<Job>, IJobRepository
{
    private readonly TestFinalContext _context;

    public JobRepository(TestFinalContext context) : base(context)
    {
        _context = context;
    }
}
