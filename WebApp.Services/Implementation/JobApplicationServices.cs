using Microsoft.EntityFrameworkCore;
using WebApp.Entities.Models;
using WebApp.Entities.ViewModels.JobApplication;
using WebApp.Repositories.Interface;
using WebApp.Services.InterFace;
using WebApp.Services.InterFace.Extra;

namespace WebApp.Services.Implementation;

public class JobApplicationServices : IJobApplicationServices
{
    private readonly IJobApplicationRepository _jobApplicationRepository;
    private readonly IAddFunctionality _addFunctionality;

    private readonly IJobRepository _jobRepository;
    public JobApplicationServices(IJobApplicationRepository jobApplicationRepository, IAddFunctionality addFunctionality, IJobRepository jobRepository)
    {
        _jobApplicationRepository = jobApplicationRepository;
        _addFunctionality = addFunctionality;
        _jobRepository = jobRepository;
    }
    public string ApplyJob(ApplyJobViewModel applyJobViewModel)
    {
        Jobapplication? jobapplication = _jobApplicationRepository.GetQueryable().Where(ja => ja.JobId == applyJobViewModel.Id && ja.UserId == _addFunctionality.getLogedInUserId()).FirstOrDefault();
        Job? job = _jobRepository.GetById(applyJobViewModel.Id);

        if (jobapplication != null)
        {
            return "You already applied for this job!";
        }

        if (applyJobViewModel.Resume == null)
        {
            return "Please upload a resume!";
        }

        if (applyJobViewModel.Id == 0 || job == null)
        {
            return "Not a valid job!";
        }



        Jobapplication jobapplicationAddToDb = new()
        {
            Status = "Applied",
            JobId = applyJobViewModel.Id,
            Resume = _addFunctionality.UploadResume(applyJobViewModel.Resume),
            UserId = _addFunctionality.getLogedInUserId()
        };

        job.NoOfApplicant = job.NoOfApplicant + 1;

        _jobApplicationRepository.Add(jobapplicationAddToDb);
        _jobRepository.Update(job);

        return "All Perfect";
    }

    public JobApplicationTableViewModel JobApplicationTable(JobApplicationTableViewModel jobApplicationTableViewModel)
    {
        IQueryable<Jobapplication> jobApplicationQuery = _jobApplicationRepository.GetQueryable()
                                                            .Include(ja => ja.User)
                                                            .Include(ja => ja.Job)
                                                            .Where(ja => !ja.Isdeleted && ja.Createdtime.Date <= jobApplicationTableViewModel.ToDate.Date && ja.Createdtime.Date >= jobApplicationTableViewModel.FromDate.Date);
        if (jobApplicationTableViewModel.Status != "All")
        {
            jobApplicationQuery = jobApplicationQuery.Where(ja => ja.Status == jobApplicationTableViewModel.Status);
        }

        if (!string.IsNullOrEmpty(jobApplicationTableViewModel.SearchQuery))
        {
            jobApplicationQuery = jobApplicationQuery.Where(ja => ja.User.Username.ToLower().Contains(jobApplicationTableViewModel.SearchQuery.Trim().ToLower())
                                                                || ja.Job.Title.ToLower().Contains(jobApplicationTableViewModel.SearchQuery.Trim().ToLower())
                                                                || ja.Job.CompanyName.ToLower().Contains(jobApplicationTableViewModel.SearchQuery.Trim().ToLower()));
        }

        int totalItems = jobApplicationQuery.Count();
        int page = jobApplicationTableViewModel.CurrentPage;
        int totalPages = (int)Math.Ceiling((double)totalItems / jobApplicationTableViewModel.PageSize);

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

        List<Jobapplication> jobApplications = jobApplicationQuery.Skip((page - 1) * jobApplicationTableViewModel.PageSize)
                        .Take(jobApplicationTableViewModel.PageSize)
                       .ToList();

        jobApplicationTableViewModel.JobApplications = jobApplications;
        jobApplicationTableViewModel.CurrentPage = page;
        jobApplicationTableViewModel.TotalPages = totalPages;
        jobApplicationTableViewModel.TotalItems = jobApplications.Count();
        return jobApplicationTableViewModel;
    }

    public string ChangeJobApplicationStatus(JobApplicationStatusViewModel jobApplicationStatusViewModel)
    {
        Jobapplication? jobapplication = _jobApplicationRepository.GetById(jobApplicationStatusViewModel.Id);
        if (jobapplication == null)
        {
            return "Invalide job application!";
        }

        if (jobApplicationStatusViewModel.Status == "Select")
        {
            return "Please select valid status!";
        }

        jobapplication.Status = jobApplicationStatusViewModel.Status;
        _jobApplicationRepository.Update(jobapplication);
        return "All Perfect";
    }

    public string DeleteJobApplication(int id)
    {
        Jobapplication? jobapplication = _jobApplicationRepository.GetById(id);
        if (jobapplication == null)
        {
            return "Job application not found!";
        }

        jobapplication.Isdeleted = true;
        _jobApplicationRepository.Update(jobapplication);
        return "success";
    }

}
