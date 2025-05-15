using Microsoft.EntityFrameworkCore;
using WebApp.Entities.Models;
using WebApp.Entities.ViewModels.Job;
using WebApp.Repositories.Interface;
using WebApp.Services.InterFace;
using WebApp.Services.InterFace.Extra;

namespace WebApp.Services.Implementation;

public class JobServices : IJobServices
{
    private readonly IJobRepository _jobRepositroy;
    private readonly IAddFunctionality _addFunctionality;
    private readonly IJobApplicationRepository _jobApplicationRepository;

    private readonly IUserRepository _userRepository;
    public JobServices(IJobRepository jobRepositroy, IAddFunctionality addFunctionality, IJobApplicationRepository jobApplicationRepository, IUserRepository userRepository)
    {
        _jobRepositroy = jobRepositroy;
        _addFunctionality = addFunctionality;
        _jobApplicationRepository = jobApplicationRepository;
        _userRepository = userRepository;
    }
    public string AddJob(AddJobViewModel addJobViewModel)
    {
        int jobsCount = _jobRepositroy.GetQueryable().Where(j => !j.Isdeleted && j.CompanyName == addJobViewModel.CompanyName && j.Title == addJobViewModel.Title).Count();
        if (jobsCount > 0)
        {
            return "You already added this job!";
        }

        Job job = new()
        {
            Title = addJobViewModel.Title,
            Location = addJobViewModel.Location,
            CompanyName = addJobViewModel.CompanyName,
            Description = addJobViewModel.Description,
            Createdby = _addFunctionality.getLogedInUserId(),
            Modifiedby = _addFunctionality.getLogedInUserId()
        };
        _jobRepositroy.Add(job);
        return "All Perfect";
    }


    public JobTableViewModel JobTable(JobTableViewModel jobTableViewModel)
    {
        IQueryable<Job> jobQuery = _jobRepositroy.GetQueryable().Where(j => !j.Isdeleted && j.Createdtime.Date <= jobTableViewModel.ToDate.Date && j.Createdtime.Date >= jobTableViewModel.FromDate.Date);

        if (!string.IsNullOrEmpty(jobTableViewModel.SearchQuery))
        {
            jobQuery = jobQuery.Where(j => j.CompanyName.ToLower().Contains(jobTableViewModel.SearchQuery.Trim().ToLower())
                                || j.Title.ToLower().Contains(jobTableViewModel.SearchQuery.Trim().ToLower()));
        }



        int totalItems = jobQuery.Count();
        int page = jobTableViewModel.CurrentPage;
        int totalPages = (int)Math.Ceiling((double)totalItems / jobTableViewModel.PageSize);

        if (totalItems != 0)
        {
            while (page > totalPages)
            {
                page--;
            }
        }
        else
        {
            page = 1;
        }

        List<Job> jobs = jobQuery.Skip((page - 1) * jobTableViewModel.PageSize)
                       .Take(jobTableViewModel.PageSize)
                       .ToList();

        jobTableViewModel.Jobs = jobs;
        jobTableViewModel.CurrentPage = page;
        jobTableViewModel.TotalPages = totalPages;
        jobTableViewModel.TotalItems = jobs.Count();
        return jobTableViewModel;
    }

    public AddJobViewModel AddJobForm(int id)
    {
        AddJobViewModel addJobViewModel = new();
        Job? job = _jobRepositroy.GetById(id);
        if (job == null)
        {
            return addJobViewModel;
        }
        else
        {
            addJobViewModel.Title = job.Title;
            addJobViewModel.CompanyName = job.CompanyName;
            addJobViewModel.Description = job.Description;
            addJobViewModel.Location = job.Location;
            addJobViewModel.Id = job.Id;
            return addJobViewModel;
        }
    }

    public string EditJob(AddJobViewModel addJobViewModel)
    {
        Job? job = _jobRepositroy.GetById((int)addJobViewModel.Id);

        if (job == null)
        {
            return "This job not exist!";
        }

int jobsCount = _jobRepositroy.GetQueryable().Where(j => !j.Isdeleted && j.CompanyName == addJobViewModel.CompanyName && j.Title == addJobViewModel.Title).Count();
        if (jobsCount > 0)
        {
            return "You already added this job!";
        }

        job.CompanyName = addJobViewModel.CompanyName;
        job.Title = addJobViewModel.Title;
        job.Location = addJobViewModel.Location;
        job.Description = addJobViewModel.Description;
        job.Lastmodifiedtime = DateTime.Now;
        job.Modifiedby = _addFunctionality.getLogedInUserId();
        _jobRepositroy.Update(job);
        return "All Perfect";
    }

    public string DeleteJob(int id)
    {
        Job? job = _jobRepositroy.GetById(id);
        if (job == null)
        {
            return "Delete item not found in database!";
        }

        job.Isdeleted = true;
        job.Lastmodifiedtime = DateTime.Now;
        job.Modifiedby = _addFunctionality.getLogedInUserId();
        _jobRepositroy.Update(job);
        return "success";
    }

    public List<UserTableViewModel> UserTable(int id)
    {
        List<UserTableViewModel> userTableViewModel = _jobApplicationRepository.GetQueryable().Include(ja => ja.User)
                                                                                        .Include(ja => ja.Job)
                                                                                        .Where(ja => ja.Job.Id == id)
                                                                                        .Select(x => new UserTableViewModel
                                                                                        {
                                                                                            Username = x.User.Username,
                                                                                            Resume = x.Resume
                                                                                        }).ToList();

        return userTableViewModel;
    }

    public string UserRegistraion(UserRegistration userRegistration)
    {
        int userCount = _userRepository.GetQueryable().Where(u => !u.Isdeleted && u.Username == userRegistration.Username).Count();
        if (userCount > 0)
        {
            return "User exist with this username.";
        }

        User user = new();
        user.Username = userRegistration.Username;
        user.Password = _addFunctionality.MakeHash(userRegistration.Password);
        user.Createdby = _addFunctionality.getLogedInUserId();
          user.Modifiedby = _addFunctionality.getLogedInUserId();
        _userRepository.Add(user);
        return "All Perfect";
    }
}
