using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class Task1
    {
        public static void Main(string[] args)
        {
            var program = new Task1();
            program.Run();
        }


        private void Run()
        {
            var cards = new List<Card>();

            while (true)
            {
                if (cards.Count > 0)
                {
                    Console.WriteLine($"You have entered {cards.Count} cards. Do you want to enter another card? (y/n)");
                    var next = Console.ReadLine();

                    if (next == "n")
                        break;
                    if (next != "y")
                        continue;
                }

                Console.Write("Input departure city: ");
                var from = Console.ReadLine();

                Console.Write("Input destination city: ");
                var to = Console.ReadLine();

                cards.Add(new Card(from, to));
            }

            Console.WriteLine("Unsorted cards:");
            foreach (var card in cards)
                Console.WriteLine(card.ToString());

            cards = SortCards(cards);
            Console.WriteLine("Sorted cards:");
            Console.WriteLine(cards);
        }

        public List<Card> SortCards(List<Card> cards)
        {
            var mixedCards = new List<Card>(cards);
            var firstCard = GetFirstCard(mixedCards);
            var sortedCards = new List<Card> {firstCard};

            while (mixedCards.Count > 1)
            {
                var lastAddedCard = sortedCards.Last();
                mixedCards.Remove(lastAddedCard);
                var newCard = mixedCards.First(c => c.From == lastAddedCard.To);
                sortedCards.Add(newCard);
            }
            return sortedCards;
        }

        public Card GetFirstCard(List<Card> cards)
        {
            var departureCities = cards.Select(c => c.From);
            var destinationCities = cards.Select(c => c.To);

            var firstCity = departureCities.Except(destinationCities).First();

            return cards.First(c => c.From == firstCity);
        }
    }
}