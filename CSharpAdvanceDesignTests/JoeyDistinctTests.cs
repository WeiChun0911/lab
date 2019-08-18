using System;
using ExpectedObjects;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyDistinctTests
    {
        [Test]
        public void distinct_numbers()
        {
            var numbers = new[] { 91, 3, 91, -1 };
            var actual = Distinct(numbers);

            var expected = new[] { 91, 3, -1 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }


        [Test]
        public void distinct_employees()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = JoeyDistinct(employees, new EmployeeCompareCondition());

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Employee> JoeyDistinct(IEnumerable<Employee> employees, EmployeeCompareCondition employeeCompareCondition)
        {
            //var enumerator = employees.GetEnumerator();
            //var result = new HashSet<Employee>(employeeCompareCondition);
            //while (enumerator.MoveNext())
            //{
            //    var current = enumerator.Current;

            //    if (result.Add(current))
            //    {
            //        yield return current;
            //    }
            //}
            return new HashSet<Employee>(employees,employeeCompareCondition);
        }

        private IEnumerable<int> Distinct(IEnumerable<int> numbers)
        {
            //var alreadyExistNumber = new List<int>();
            //var enumerator = numbers.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    var current = enumerator.Current;
            //    if (alreadyExistNumber.Exists(x=>x==current))
            //    {

            //    }
            //    else
            //    {
            //        alreadyExistNumber.Add(current);
            //    }
            //}

            //return alreadyExistNumber;
            return new HashSet<int>(numbers);
        }
    }

    internal class EmployeeCompareCondition : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }

        public int GetHashCode(Employee obj)
        {
            //return new Tuple(obj.FirstName,obj.LastName)
            return new {obj.FirstName,obj.LastName}.GetHashCode();
        }
    }
}