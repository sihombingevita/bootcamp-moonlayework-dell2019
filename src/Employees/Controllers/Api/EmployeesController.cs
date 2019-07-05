using Barebone.Controllers;
using Employees.Data.Abstractions;
using Employees.Data.Entities;
using Employees.ViewModels.Employee;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Employees.Controllers.Api
{
    [Route("api/employees")]
    public class EmployeesController : ControllerBaseApi
    {
        public EmployeesController(IStorage storage) : base(storage)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int size = 25)
        {
            IEnumerable<Employee> data = new EmpIndexViewModelFactory().Create(this.Storage)?.Employees;
            int count = data.Count();

            return Ok(new
            {
                success = true,
                data = data.OrderBy(o => o.FirstName).Skip(page * size).Take(size),
                count,
                totalPage = ((int)count / size) + 1
            });
        }

        [HttpPost]
        public IActionResult Post(CreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                Employee employee = model.ToEntity(this.GetCurrentUserName());
                this.Storage.GetRepository<IEmployeeRepository>().Create(employee);
                this.Storage.Save();

                return Ok(new { success = true });
            }

            return BadRequest(new { success = false });
        }
    }
}
