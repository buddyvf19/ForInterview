﻿using System;

namespace DataModels
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public virtual string Account { get; set; }
        public virtual string Password { get; set; }
        public string  LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public string BirthDate { get; set; }
        public string HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string  Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string HomePhone { get; set; }
        public int? ReportsTo { get; set; }
    }
}
