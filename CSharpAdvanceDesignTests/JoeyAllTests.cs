using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyAllTests
    {
        [Test]
        public void girls_all_adult_False()
        {
            var girls = new List<Girl>
            {
                new Girl{Age = 20},
                new Girl{Age = 21},
                new Girl{Age = 17},
                new Girl{Age = 18},
                new Girl{Age = 30},
            };

            var actual = JoeyAll(girls);
            Assert.IsFalse(actual);
        }

        [Test]
        public void girls_all_adult_True()
        {
            var girls = new List<Girl>
            {
                new Girl{Age = 20},
                new Girl{Age = 21},
                new Girl{Age = 73},
                new Girl{Age = 18},
                new Girl{Age = 30},
            };

            var actual = JoeyAll(girls);
            Assert.IsTrue(actual);
        }

        private bool JoeyAll(IEnumerable<Girl> girls)
        {
            var enumerator = girls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var girl = enumerator.Current;
                if (girl.Age < 18)
                {
                    return false;
                }
            }

            return true;
        }
    }
}