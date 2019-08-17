using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyAnyTests
    {
        [Test]
        public void three_employees()
        {
            var employees = new Employee[]
            {
                new Employee(),
                new Employee(),
                new Employee()
            };

            var actual = JoeyAny(employees);
            Assert.IsTrue(actual);
        }

        [Test]
        public void empty_employees()
        {
            var emptyEmployees = new Employee[]
            {
            };

            var actual = JoeyAny(emptyEmployees);
            Assert.IsFalse(actual);
        }

        [Test]
        public void any_number_greater_than_91()
        {
            var numbers = new[] { 87, 88, 91, 93, 0 };
            var actual = JoeyAnyWithCondition(numbers);
            Assert.IsTrue(actual);
        }

        private bool JoeyAnyWithCondition(IEnumerable<int> source)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current > 91)
                {
                    return true;
                }
            }

            return false;
        }

        private bool JoeyAny(IEnumerable<Employee> employees)
        {
            var enumerator = employees.GetEnumerator();
            return enumerator.MoveNext();
        }
    }
}