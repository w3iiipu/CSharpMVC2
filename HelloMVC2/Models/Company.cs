﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloMVC2.Models
{
    public class Company
    {
        public Employee CompanyDirector
        {
            get
            {
                SampleDBContext db = new SampleDBContext();
                return db.Employees.Single(x => x.Id == 1);
            }
        }
    }
}