﻿namespace CleanArch.API.Domain.DTOs
{
    public class EmployeeDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public int DaysWorked { get; set; }
        public string Cafe { get; set; } // Café name, can be empty if not assigned
    }

}
