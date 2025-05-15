using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Entities.ViewModels.JobApplication;
using WebApp.Services.InterFace;

namespace WebApp.Controllers;

public class JobApplicationController : Controller
{
    private readonly IJobApplicationServices _jobApplicationServices;
    public JobApplicationController(IJobApplicationServices jobApplicationServices)
    {
        _jobApplicationServices = jobApplicationServices;
    }

    [Route("/applyjob/{id}")]
    [Authorize(Roles = "User")]
    public IActionResult ApplyJob()
    {
        return View();
    }

    [Route("/applyjobform")]
    [Authorize(Roles = "User")]
    public IActionResult ApplyJobFormView()
    {
        ApplyJobViewModel applyJobViewModel = new();
        return PartialView("_ApplyJobForm", applyJobViewModel);
    }

    [Route("/applyjob")]
    [HttpPost]
    [Authorize(Roles = "User")]
    public IActionResult ApplyJob([FromForm] ApplyJobViewModel applyJobViewModel)
    {
        if (ModelState.IsValid)
        {
            string message = _jobApplicationServices.ApplyJob(applyJobViewModel);
            if (message == "All Perfect")
            {
                return Json(new { redirectUrl = "/job" });
            }
            return Json(new { message = message });
        }
        return PartialView("_ApplyJobForm", applyJobViewModel);
    }

    [Route("/jobapplication")]
    [Authorize(Roles = "Admin")]
    public IActionResult JobApplication()
    {
        return View();
    }

    [Route("/jobapplicationtable")]
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult JobApplicationTable([FromForm] JobApplicationTableViewModel jobApplicationTableViewModel)
    {
        return PartialView("_JobApplicationTable", _jobApplicationServices.JobApplicationTable(jobApplicationTableViewModel));
    }

    [Route("/changejobstatus")]
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult ChangeJobApplicationStatus([FromForm] JobApplicationStatusViewModel jobApplicationStatusViewModel)
    {
        string message = _jobApplicationServices.ChangeJobApplicationStatus(jobApplicationStatusViewModel);
        return Json(new { status = message });
    }

    [Route("/deletejobapplication")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteJobApplication(int id)
    {
        return Json(new { message = _jobApplicationServices.DeleteJobApplication(id) });
    }
}
