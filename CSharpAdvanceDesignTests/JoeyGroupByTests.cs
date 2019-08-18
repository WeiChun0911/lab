using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyGroupByTests
    {
        [Test]
        public void groupBy_lastName()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Lee"},
                new Employee {FirstName = "Eric", LastName = "Chen"},
                new Employee {FirstName = "John", LastName = "Chen"},
                new Employee {FirstName = "David", LastName = "Lee"},
            };

            var actual = JoeyGroupBy(employees);
            Assert.AreEqual(2, actual.Count());
            var firstGroup = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Eric", LastName = "Chen"},
                new Employee {FirstName = "John", LastName = "Chen"},
            };

            firstGroup.ToExpectedObject().ShouldMatch(actual.First().ToList());
        }

        private IEnumerable<IGrouping<string, Employee>> JoeyGroupBy(IEnumerable<Employee> employees)
        {
            var result = new Dictionary<string, List<Employee>>();
            var enumerator = employees.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var employee = enumerator.Current;
                if (!result.ContainsKey(employee.LastName))
                {
                    result.Add(employee.LastName, new List<Employee>(){employee});
                }
                else
                {
                    result[employee.LastName].Add(employee);
                }
            }

            //接著要return，會遇到問題，要轉成IEnumerable<IGrouping<x,y>>

            return ConvertToIEnumerable(result);
        }

        private IEnumerable<IGrouping<string, Employee>> ConvertToIEnumerable(Dictionary<string, List<Employee>> result)
        {
            var enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var keyValuePair = enumerator.Current;
                yield return new MyGrouping(keyValuePair.Key,keyValuePair.Value);
                //把dictionary 一個一個拿出來、轉成 IGrouping 的樣子
            }
        }
    }

    internal class MyGrouping : IGrouping<string, Employee>
    {
        private readonly List<Employee> _value;

        public MyGrouping(string key, List<Employee> value)
        {
            //這個介面需要的資料 = 外面傳進來的
            this.Key = key;
            _value = value;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //要傳回去 傳進來的資料的 enumerator
            return GetEnumerator();
        }

        public string Key { get; }
    }
}