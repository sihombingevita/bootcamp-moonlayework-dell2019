using Employees.Data.Abstractions;
using Employees.Data.Entities;
using Employees.ViewModels.Employee;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    //[Authorize]
    public class EmployeeController : Barebone.Controllers.ControllerBase
    {
        public EmployeeController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index()
        {
            return View(new EmpIndexViewModelFactory().Create(this.Storage));
        }

        public ActionResult Create()
        {
            var model = new CreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Employee employee = model.ToEntity(this.GetCurrentUserName());
                this.Storage.GetRepository<IEmployeeRepository>().Create(employee);
                this.Storage.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}