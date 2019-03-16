using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyTakeWhileTests
    {
        [Test]
        public void take_cards_until_separate_card()
        {
            var cards = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
                new Card {Kind = CardKind.Normal, Point = 4},
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
            };

            var actual = JoeyTakeWhile(cards, item => item.Kind != CardKind.Separate);

            var expected = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
                new Card {Kind = CardKind.Normal, Point = 4},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        private IEnumerable<TSource> JoeyTakeWhile<TSource>(IEnumerable<TSource> cards, Func<TSource, bool> condition)
        {
            var cardsEnumerator = cards.GetEnumerator();

            while (cardsEnumerator.MoveNext())
            {
                var item = cardsEnumerator.Current;
                if (condition(item))
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }
            }
        }
    }
}