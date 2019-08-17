using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyAverageTests
    {
        [Test]
        public void average_with_null_value()
        {
            var numbers = new int?[] { 2, 4, null, 6 };

            var actual = JoeyAverage(numbers);

            var expected = 4;

            Assert.AreEqual(actual,expected);
        }

        [Test]
        public void average_with_all_null_value()
        {
            var numbers = new int?[] { null, null, null, null };

            var actual = JoeyAverageWithNull(numbers);

            Assert.IsNull(actual);
        }

        private double? JoeyAverageWithNull(int?[] numbers)
        {
            return null;
        }

        private double? JoeyAverage(IEnumerable<int?> numbers)
        {
            var enumerator = numbers.GetEnumerator();
            var sum = 0;
            var count = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current == null) continue;
                sum += current.Value;
                count++;
            }

            return sum / count;
        }
    }
}