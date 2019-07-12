﻿using System;
using Employees.Data.Entities;

namespace Employees.Controllers.Api
{
    public class UpdateViewModel
    {
        public UpdateViewModel() { }

        private readonly Employee _entity;

        public string FirstName { get; set; }

        internal Employee ToEntity(Employee entity, string username)
        {
            entity.FirstName = this.FirstName;
            entity.Modified = DateTime.Now;
            entity.ModifiedBy = username;

            return entity;
        }
    }
}