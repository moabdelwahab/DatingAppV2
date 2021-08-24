using System;

namespace LinkDev.DatingApp.Core.Extensions
{
    public static class DatetimeExtentions
    {
        public static int CalculateAge(this DateTime Dob)
        {
            var today = DateTime.Today;
            var age   = today.Year - Dob.Year;
             if(Dob.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}