using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeySkipWhileTests
    {
        [Test]
        public void skip_cards_until_separate_card()
        {
            var cards = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
                new Card {Kind = CardKind.Normal, Point = 4},
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
                new Card {Kind = CardKind.Separate},
            };

            var actual = JoeySkipWhile(cards, card => card.Kind != CardKind.Separate);

            var expected = new List<Card>
            {
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
                new Card {Kind = CardKind.Separate},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }


        [Test]
        public void skip_cards_when_point_less_than_5()
        {
            var cards = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 2},
                new Card {Kind = CardKind.Normal, Point = 3},
                new Card {Kind = CardKind.Normal, Point = 4},
                new Card {Kind = CardKind.Separate},
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
                new Card {Kind = CardKind.Separate},
            };

            var actual = JoeySkipWhile(cards, card => card.Point < 5);

            var expected = new List<Card>
            {
                new Card {Kind = CardKind.Normal, Point = 5},
                new Card {Kind = CardKind.Normal, Point = 6},
                new Card {Kind = CardKind.Separate},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Card> JoeySkipWhile(IEnumerable<Card> cards, Func<Card, bool> skipCondition)
        {
            var enumerator = cards.GetEnumerator();
            bool matched = false;
            while (enumerator.MoveNext())
            {
                var card = enumerator.Current;
                if (!skipCondition(card))
                {
                    matched = true;
                }

                if (matched)
                {
                    yield return card;
                }
            }
        }
    }
}