using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkins.Data.Entities
{
    public class Checkin : Entity
    {
        public DateTimeOffset Time { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Location { get; set; }
        public string Remark { get; set; }
        public double RadiusEmployee { get; set; }
    }
}
