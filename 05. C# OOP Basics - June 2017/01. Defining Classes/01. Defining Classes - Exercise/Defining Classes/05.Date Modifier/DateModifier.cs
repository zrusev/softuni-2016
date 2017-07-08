using System;
using System.Collections.Generic;

namespace _05.Date_Modifier
{
    public class DateModifier
    {

        private string firstDate;
        private string secondDate;
        public string FirstDate { get => firstDate; set => firstDate = value; }
        public string SecondDate { get => secondDate; set => secondDate = value; }

        public double CalculateDifference()
        {

            var fDate = Convert.ToDateTime(FirstDate);
            var sDate = Convert.ToDateTime(SecondDate);

            return Math.Abs((sDate - fDate).TotalDays);
        }


    }
}
