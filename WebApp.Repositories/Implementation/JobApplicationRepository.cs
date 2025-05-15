using WebApp.Entities.Data;
using WebApp.Entities.Models;
using WebApp.Repositories.Interface;

namespace WebApp.Repositories.Implementation;

public class JobApplicationRepository : GenericRepository<Jobapplication>, IJobApplicationRepository
{
    private readonly TestFinalContext _context;

    public JobApplicationRepository(TestFinalContext context) : base(context)
    {
        _context = context;
    }
}
