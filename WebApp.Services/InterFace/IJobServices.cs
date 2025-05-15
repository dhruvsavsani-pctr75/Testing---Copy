using WebApp.Entities.ViewModels.Job;

namespace WebApp.Services.InterFace;

public interface IJobServices
{
    string AddJob(AddJobViewModel addJobViewModel);
    JobTableViewModel JobTable(JobTableViewModel jobTableViewModel);
    AddJobViewModel AddJobForm(int id);
    string EditJob(AddJobViewModel addJobViewModel);
    string DeleteJob(int id);
    List<UserTableViewModel> UserTable(int id);

    string UserRegistraion(UserRegistration userRegistration);
}
