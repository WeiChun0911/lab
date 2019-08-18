using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyIntersectTests
    {

        [Test]
        public void intersect_numbers()
        {
            var first = new[] { 1, 3, 5, 1, 5 };
            var second = new[] { 5, 7, 3 };

            var actual = JoeyIntersect(first, second);

            var expected = new[] { 3, 5 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyIntersect(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstHashSet = new HashSet<int>(first);
            var secondHashSet = new HashSet<int>(second);
            var enumerator = firstHashSet.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (secondHashSet.Add(current))
                {
                }
                else
                {
                    yield return current;
                }
            }
        }
    }
}