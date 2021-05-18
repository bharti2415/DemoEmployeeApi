using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApi.Models
{
    public class EmpModel
    {

        public int ID { get; set; }

        public string EmpName { get; set; }

        public string Address { get; set; }
        public Decimal? Phone { get; set; }
        public string Email { get; set; }
    }
}