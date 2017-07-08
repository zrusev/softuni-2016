namespace _02.Advertisement_Message
{
    using System;
    
    class Advertisement_Message
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] phrases = {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."};
            string[] events = {"Now I feel good.", "I have succeeded with this product.", "Makes miracles.I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};
            string[] autors = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            var random = new Random();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{phrases[random.Next(0, phrases.Length - 1)]} {events[random.Next(0 , events.Length - 1)]} {autors[random.Next(0, autors.Length - 1)]} {cities[random.Next(0, cities.Length - 1)]}");
            }
        }
    }
}
