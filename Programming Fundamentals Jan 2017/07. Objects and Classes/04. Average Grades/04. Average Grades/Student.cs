namespace _04.Average_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Student
    {
        public string name { get; set; }
        public double[] grades { get; set; }
        public double avgGrade { get { return AverageGrade(grades); } }
        

        public double AverageGrade(double[] grades)
        {
            return grades.Average();
        }

    }
}
