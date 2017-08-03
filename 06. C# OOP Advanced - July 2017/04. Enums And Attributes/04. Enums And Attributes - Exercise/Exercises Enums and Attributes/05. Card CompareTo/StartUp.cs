using System;
using System.Collections.Generic;
using _03.Card_Power;

namespace _05.Card_CompareTo
{
    public class StartUp
    {
        public static void Main()
        {
            Card cardOne = new Card(Console.ReadLine(), Console.ReadLine());
            Card cardTwo = new Card(Console.ReadLine(), Console.ReadLine());

            if (cardOne.SumUp().CompareTo(cardTwo.SumUp()) > 0)
            {
                Console.WriteLine(cardOne.ToString() + cardOne.SumUp());
            }
            else
            {
                Console.WriteLine(cardTwo.ToString() + cardTwo.SumUp());
            }
        }
    }
}
