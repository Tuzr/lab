﻿using System;
using System.Collections.Generic;

namespace Lab.Entities
{
    public class JoeyEmployeeWithPhoneEqualityConverter : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.FirstName == y.FirstName
                   && x.LastName == y.LastName
                   && x.Phone == y.Phone;
        }

        public int GetHashCode(Employee obj)
        {
            return Tuple.Create(obj.FirstName, obj.LastName).GetHashCode();
        }
    }

    public class JoeyEmployeeEqualityConverter : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.FirstName == y.FirstName
                   && x.LastName == y.LastName;
        }

        public int GetHashCode(Employee obj)
        {
            return Tuple.Create(obj.FirstName, obj.LastName).GetHashCode();
        }
    }

    public class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Role Role { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }
}