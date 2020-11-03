﻿using System;
using System.Collections.Generic;

namespace ConsoleApp3.DBModel
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
