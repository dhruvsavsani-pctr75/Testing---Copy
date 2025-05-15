using WebApp.Entities.ViewModels.JobApplication;

namespace WebApp.Services.InterFace;

public interface IJobApplicationServices
{
    string ApplyJob(ApplyJobViewModel applyJobViewModel);
    JobApplicationTableViewModel JobApplicationTable(JobApplicationTableViewModel jobApplicationTableViewModel);
    string ChangeJobApplicationStatus(JobApplicationStatusViewModel jobApplicationStatusViewModel);
    string DeleteJobApplication(int id);
}
