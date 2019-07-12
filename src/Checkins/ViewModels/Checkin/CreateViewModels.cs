using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Checkins.ViewModels.Checkin
{
    public class CreateViewModels
    {
        //[Display(Name = "First Name")]
        [Required()]
        public DateTimeOffset Time { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Location { get; set; }
        public string Remark { get; set; }
        public double RadiusEmployee { get; set; }
        internal Data.Entities.Checkin ToEntity()
        {
            return new Data.Entities.Checkin
            {
                Time = this.Time,
                Date = this.Date,
                Location = this.Location,
                Remark = this.Remark,
                RadiusEmployee = this.RadiusEmployee
            };
        }
    }
}
