﻿using System.Text.Json.Serialization;

namespace Univan.Application.Contracts.Student
{
    public class StudentBasicResult
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Rating { get; set; }
        public string PhotoUrl { get; set; }
        public string LineAddress { get; set; } //Analyze address tables format
    }
}
