using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentApp.Infrastructure
{
    public static class DateTimeExtensions
    {
        public static string DateToYyyyMmDdString(this DateTime? date)
        {
            var stringBuilder = new StringBuilder();
            if (date!=null)
            {
                var dateNotNull = date.Value;
                stringBuilder.Append(dateNotNull.Year.ToString());
                stringBuilder.Append('-');
                var monthNumber = dateNotNull.Month;
                if (monthNumber < 10)
                {
                    stringBuilder.Append(0);
                }
                stringBuilder.Append(monthNumber);
                stringBuilder.Append('-');
                var dayNumber = dateNotNull.Day;
                if (dayNumber < 10)
                {
                    stringBuilder.Append(0);
                }
                stringBuilder.Append(dateNotNull.Day.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
