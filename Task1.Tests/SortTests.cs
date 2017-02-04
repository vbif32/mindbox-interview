using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Tests
{
    [TestClass]
    public class SortTests
    {
        private List<Card> _cards;
        public List<Card> Cards => _cards ?? (_cards = CreateCards());

        [TestMethod]
        public void SortTest_Complete()
        {
            var mixedCards = MixCards(Cards);
            Console.WriteLine("Before sort:");
            Console.WriteLine(Cards);
            var sortedCards = new Task1().SortCards(mixedCards);
            Console.WriteLine("After sort:");
            for (var i = 0; i < Cards.Count; i++)
            {
                if (Cards[i] != sortedCards[i])
                    throw new Exception($"{i} card isn't correct");
            }
        }

        private List<Card> CreateCards()
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
                new Card(City.Vatican.ToString(), City.Vein.ToString()),
            };
        }
        private List<Card> MixCards(List<Card> cards)
        {
            var mixedCards = new List<Card>(cards);
            var random = new Random();

            for (var i = 0; i < cards.Count; i++)
            {
                var randomPosition = random.Next(0, mixedCards.Count);
                var tmpCard = mixedCards[randomPosition];
                mixedCards[randomPosition] = cards[i];
                mixedCards[i] = tmpCard;
            }
            return cards;
        }
    }
}
