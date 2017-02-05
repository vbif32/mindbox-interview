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

            string nextAction = null;
            while (nextAction != "q")
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.Write("Do you want to enter auto test (a), manual test (m) or quit (q)?  ");
                nextAction = Console.ReadLine();
                Console.WriteLine("--------------------------------------------------------------");
                Console.Write("\n");

                if (nextAction == "a")
                    program.AutomaticControl();
                if (nextAction == "m")
                    program.ManualControl();

                Console.Write("\n\n");
            }
        }
        
        private void ManualControl()
        {
            var cards = new List<Card>();

            while (true)
            {
                if (cards.Count > 0)
                {
                    Console.Write($"You have entered {cards.Count} cards. Do you want to enter another card (y/n) ?  ");
                    var next = Console.ReadLine();
                    Console.Write("\n");

                    if (next == "n")
                        break;
                    if (next != "y")
                        continue;
                }

                Console.Write("Input  departure  city: ");
                var from = Console.ReadLine();
                Console.Write("Input destination city: ");
                var to = Console.ReadLine();
                Console.Write("\n");

                cards.Add(new Card(from, to));
            }
            var sortedCards = SortCards(cards);
            AutoTest(sortedCards);
            PrintCardsForManualTest(cards, sortedCards);
        }

        private void AutomaticControl()
        {
            var cards = CreateCards();
            var mixedCards = MixCards(cards);
            var sortedCards = SortCards(mixedCards);

            AutoTest(sortedCards);
            PrintCardsForManualTest(mixedCards, sortedCards);
        }

        public List<Card> SortCards(List<Card> cards)
        {
            var mixedCards = new List<Card>(cards);
            var nextCity = FindStartCity(mixedCards);
            var sortedCards = new List<Card>(cards.Count);

            while (mixedCards.Count > 0)
            {
                var nextCard = mixedCards.First(c => c.From == nextCity);
                sortedCards.Add(nextCard);
                mixedCards.Remove(nextCard);
                nextCity = nextCard.To;
            }
            return sortedCards;
        }

        public string FindStartCity(List<Card> cards)
        {
            var departureCities = cards.Select(c => c.From);
            var destinationCities = cards.Select(c => c.To);

            var firstCity = departureCities.Except(destinationCities).First();

            return firstCity;
        }

        private void PrintCardsForManualTest(IEnumerable<Card> mixedCards, IEnumerable<Card> sortedCards)
        {
            Console.WriteLine("Unsorted cards:");
            foreach (var card in mixedCards)
                Console.WriteLine(card.ToString());

            Console.Write("\n");

            Console.WriteLine("Sorted cards:");
            foreach (var card in sortedCards)
                Console.WriteLine(card.ToString());
        }

        private void AutoTest(List<Card> sortedCards)
        {
            for (var i = 0; i < sortedCards.Count-1; i++)
                if (sortedCards[i].To != sortedCards[i + 1].From)
                    Console.WriteLine($"{i} card isn't correct");
        }

        public static List<Card> CreateCards()
        {
            return new List<Card>
            {
                new Card(City.BuenosAires.ToString(), City.Canberra.ToString()),
                new Card(City.Canberra.ToString(), City.Cologne.ToString()),
                new Card(City.Cologne.ToString(), City.London.ToString()),
                new Card(City.London.ToString(), City.Melbourne.ToString()),
                new Card(City.Melbourne.ToString(), City.Minsk.ToString()),
                new Card(City.Minsk.ToString(), City.Moscow.ToString()),
                new Card(City.Moscow.ToString(), City.Paris.ToString()),
                new Card(City.Paris.ToString(), City.Vatican.ToString()),
                new Card(City.Vatican.ToString(), City.Vein.ToString())
            };
        }

        public static List<Card> MixCards(List<Card> cards)
        {
            var mixedCards = new List<Card>(cards);
            var random = new Random();

            for (var i = 0; i < mixedCards.Count; i++)
            {
                var randomPosition = random.Next(0, mixedCards.Count);
                var tmpCard = mixedCards[randomPosition];
                mixedCards[randomPosition] = mixedCards[i];
                mixedCards[i] = tmpCard;
            }
            return mixedCards;
        }
    }
}