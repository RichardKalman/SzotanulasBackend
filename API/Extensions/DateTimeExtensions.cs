﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime d)
        {
            var today = DateTime.Today;
            var age = today.Year - d.Year;
            if (d.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}