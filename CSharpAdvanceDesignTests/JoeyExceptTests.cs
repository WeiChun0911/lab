using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyExceptTests
    {
        [Test]
        public void except_numbers()
        {
            var first = new[] { 1, 3, 5, 7, 3};
            var second = new[] { 7, 1, 4, 1};

            var actual = JoeyExcept(first, second);
            var expected = new[] { 3, 5 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyExcept(IEnumerable<int> first, IEnumerable<int> second)
        {
            //可惡 不行 不知道壞在哪
            //var firstEnumerator = first.GetEnumerator();
            //while (firstEnumerator.MoveNext())
            //{
            //    var firstCurrent = firstEnumerator.Current;
            //    var shouldReturn = true;
            //    var secondEnumerator = second.GetEnumerator();
            //    while (secondEnumerator.MoveNext())
            //    {
            //        var secondCurrent = secondEnumerator.Current;
            //        if (firstCurrent == secondCurrent)
            //        {
            //            shouldReturn = false;
            //        }
            //    }

            //    if (shouldReturn)
            //    {
            //        yield return firstCurrent;
            //    }
            //}

            var hashSet = new HashSet<int>(second);
            var enumerator = first.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (hashSet.Add(current))
                {
                    yield return current;
                }
            }
        }
    }
}