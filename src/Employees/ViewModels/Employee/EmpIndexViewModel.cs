using System.Collections.Generic;
using Employees.Data.Entities;

namespace Employees.ViewModels.Employee
{
    public class EmpIndexViewModel
    {
        public EmpIndexViewModel(IEnumerable<Data.Entities.Employee> data)
        {
            Employees = data;
        }

        public IEnumerable<Data.Entities.Employee> Employees { get; }
    }
}