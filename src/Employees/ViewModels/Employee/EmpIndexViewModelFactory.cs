using System;
using Employees.Data.Abstractions;
using ExtCore.Data.Abstractions;

namespace Employees.ViewModels.Employee
{
    internal class EmpIndexViewModelFactory
    {
        public EmpIndexViewModelFactory()
        {
        }

        internal EmpIndexViewModel Create(IStorage storage, int page, int size)
        {
            var employeeRepo = storage.GetRepository<IEmployeeRepository>();

            return new EmpIndexViewModel(employeeRepo.All(page, size));
        }
    }
}