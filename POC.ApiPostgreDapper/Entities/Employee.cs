﻿namespace POC.ApiPostgreDapper.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }

        public Employee()
        {
            Name = string.Empty;
            Address = string.Empty;
            MobileNumber = string.Empty;
        }
    }
}
