using ExpectedObjects;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyLastTest
    {

        [Test]
        public void get_last_number()
        {
            var numbers = new[] { 1, 2, 3, 4 };
            var actual = JoeyLast(numbers);
            4.ToExpectedObject().ShouldMatch(actual);
        }

        private int JoeyLast(int[] numbers)
        {
            throw new System.NotImplementedException();
        }
    }
}