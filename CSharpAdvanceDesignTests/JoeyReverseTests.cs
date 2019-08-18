using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyReverseTests
    {
        [Test]
        public void reverse_employees()
        {
            var employees = new List<Employee>
            {
                new Employee(){FirstName = "Joey",LastName = "Chen"},
                new Employee(){FirstName = "Tom",LastName = "Li"},
                new Employee(){FirstName = "David",LastName = "Wang"},
            };

            var actual = JoeyReverse(employees);

            var expected = new List<Employee>
            {
                new Employee(){FirstName = "David",LastName = "Wang"},
                new Employee(){FirstName = "Tom",LastName = "Li"},
                new Employee(){FirstName = "Joey",LastName = "Chen"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Employee> JoeyReverse(IEnumerable<Employee> employees)
        {
            //var enumerator = employees.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    while (enumerator.MoveNext())
            //    {
            //    }

            //    yield return enumerator.Current;
            //    enumerator.Reset();
            //    //這裡要把最後一個元素刪掉才會成功、但刪不了
            //}
            return new Stack<Employee>(employees);
            //Stack 在 new 的時候就已經反轉了
        }
    }
}