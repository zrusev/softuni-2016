﻿using Military_Elite.Interfaces;

namespace Military_Elite.Models
{
    public class Repair : IRepair
    {
        public Repair(string part, int hours)
        {
            this.PartName = part;
            this.HoursWorked = hours;
        }

        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}