using System;


namespace _10.Centuries_to_Nan
{
    class Program
    {
        static void Main(string[] args)
        {

            int centuries = int.Parse(Console.ReadLine());

            int years = centuries * 100;

            int days = (int)(years * 365.2422);

            int hours = 24 * days;

            int minutes = 60 * hours;

            ulong seconds = 60 * (ulong)minutes;

            decimal milliseconds = 1000 * seconds;

            decimal microseconds = 1000 * milliseconds;

            decimal nanoseconds = 1000 * microseconds;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}
