using System.Linq;

namespace Number_Wars
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        private const int MaxCounter = 1_000_000;
        public static void Main()
        {
            var firstAllCards = new Queue<string>(Console.ReadLine().Split());
            var secondAllCard = new Queue<string>(Console.ReadLine().Split());

            var turnsCounter = 0;
            var gameOver = false;
            while (turnsCounter < MaxCounter && firstAllCards.Count > 0 && secondAllCard.Count > 0 && !gameOver)
            {
                turnsCounter++;
                var firstCard = firstAllCards.Dequeue();
                var secondCard = secondAllCard.Dequeue();

                if (GetNumber(firstCard) > GetNumber(secondCard))
                {
                    firstAllCards.Enqueue(firstCard);
                    firstAllCards.Enqueue(secondCard);
                }
                else if (GetNumber(firstCard) < GetNumber(secondCard))
                {
                    secondAllCard.Enqueue(secondCard);
                    secondAllCard.Enqueue(firstCard);
                }
                else
                {
                    var cardsHand = new List<string> {firstCard, secondCard};
                    while (!gameOver)
                    {
                        if (firstAllCards.Count >= 3 && secondAllCard.Count >= 3)
                        {
                            var firstSum = 0;
                            var secondSum = 0;

                            for (int counter = 0; counter < 3; counter++)
                            {
                                var firstHandCard = firstAllCards.Dequeue();
                                var secondHandCard = secondAllCard.Dequeue();

                                firstSum += GetChar(firstHandCard);
                                secondSum += GetChar(secondHandCard);

                                cardsHand.Add(firstHandCard);
                                cardsHand.Add(secondHandCard);
                            }

                            if (firstSum > secondSum)
                            {
                                AddCardsToWinner(cardsHand, firstAllCards);
                                break;
                            }
                            else if (firstSum < secondSum)
                            {
                                AddCardsToWinner(cardsHand, secondAllCard);
                                break;
                            }
                            else {}
                        }
                        else
                        {
                            gameOver = true;                            
                        }
                    }
                }
            }

            var result = string.Empty;

            if (firstAllCards.Count == secondAllCard.Count)
            {
                result = "Draw";
            }
            else if (firstAllCards.Count > secondAllCard.Count)
            {
                result = "First player wins";
            }
            else
            {
                result = "Second player wins";
            }

            Console.WriteLine($"{result} after {turnsCounter} turns");
        }

        private static void AddCardsToWinner(List<string> cardsHand, Queue<string> firstAllCards)
        {
            foreach (var card in cardsHand.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetChar(c)))
            {
                firstAllCards.Enqueue(card);
            }
        }

        private static int GetNumber(string card) => int.Parse(card.Substring(0, card.Length - 1));

        private static int GetChar(string card)
        {
            return card[card.Length - 1];
        }
    }
}
