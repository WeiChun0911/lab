using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Lab;

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
            var actual = numbers.JoeyAnyWithCondition(current => current > 91);
            Assert.IsTrue(actual);
        }

        private bool JoeyAny(IEnumerable<Employee> employees)
        {
            var enumerator = employees.GetEnumerator();
            return enumerator.MoveNext();
        }
    }
}