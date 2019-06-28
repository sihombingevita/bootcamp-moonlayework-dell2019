using System;
using System.Collections.Generic;
using System.Text;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers
{
    public class EmployeeController : Barebone.Controllers.ControllerBase
    {
        public EmployeeController(IStorage storage) : base(storage)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
