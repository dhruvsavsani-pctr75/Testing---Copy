using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Entities.ViewModels.Job;
using WebApp.Services.InterFace;

namespace WebApp.Controllers;

public class JobController : Controller
{
    public IJobServices _jobServices;
    public JobController(IJobServices jobServices)
    {
        _jobServices = jobServices;
    }

    [Route("/job")]
    [Authorize]
    public IActionResult Job()
    {
        return View();
    }

    [Route("/addjob")]
    [Authorize(Roles = "Admin")]
    public IActionResult AddJob()
    {
        return View();
    }

    [Route("/addjobform")]
    [Authorize(Roles = "Admin")]
    public IActionResult AddJobForm(int id)
    {
        return PartialView("_AddJobForm", _jobServices.AddJobForm(id));
    }

    [Route("/addjob")]
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult AddJob(AddJobViewModel addJobViewModel)
    {
        if (ModelState.IsValid)
        {
            string message = _jobServices.AddJob(addJobViewModel);
            if (message == "All Perfect")
            {
                return Json(new { redirectUrl = "/job" });
            }
            return Json(new { message = message });
        }
        return PartialView("_AddJobForm", addJobViewModel);
    }

    [Route("/getjobtable")]
    [HttpPost]
    [Authorize]
    public IActionResult JobTable([FromForm] JobTableViewModel jobTableViewModel)
    {
        return PartialView("_JobTable", _jobServices.JobTable(jobTableViewModel));
    }

    [Route("/editjob/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Editjob(int id)
    {
        return View();
    }

    [Route("/editjob")]
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Editjob([FromForm] AddJobViewModel addJobViewModel)
    {
        if (ModelState.IsValid)
        {
            string message = _jobServices.EditJob(addJobViewModel);
            if (message == "All Perfect")
            {
                return Json(new { redireUrl = "/job" });
            }
            return Json(new { message = message });
        }
        return PartialView("_AddJobForm", addJobViewModel);
    }

    [Route("/deletejob")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteJob(int id)
    {
        return Json(new { status = _jobServices.DeleteJob(id) });
    }

    [Route("/apllieduser/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult UserTable(int id)
    {
        return View(_jobServices.UserTable(id));
    }

    [Route("/userregistration")]
    [Authorize(Roles = "Admin")]
    public IActionResult UserRegistraion()
    {
        return View();
    }

    [Route("/userregistration")]
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult UserRegistraion(UserRegistration userRegistration)
    {
        if (ModelState.IsValid)
        {
            string message = _jobServices.UserRegistraion(userRegistration);
            if (message == "All Perfect")
            {
                return Redirect("/job");

            }
            ModelState.AddModelError("customerErrorMessage", message);
            return View(userRegistration);
        }
        return View(userRegistration);
    }
}
