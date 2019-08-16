using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeySelectTests
    {
        [Test]
        public void replace_http_to_https()
        {
            var urls = GetUrls();

            var actual = urls.JoeySelect(url => url.Replace("http://", "https://"));
            var expected = new List<string>
            {
                "https://tw.yahoo.com",
                "https://facebook.com",
                "https://twitter.com",
                "https://github.com",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }


        [Test]
        public void append_port_9191_to_urls()
        {
            var urls = GetUrls();

            var actual = urls.JoeySelect(url => $"{url}:9191");
            var expected = new List<string>
            {
                "http://tw.yahoo.com:9191",
                "https://facebook.com:9191",
                "https://twitter.com:9191",
                "http://github.com:9191",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }



        [Test]
        public void select_with_seq_no()
        {
            var urls = GetUrls();

            var actual = urls.JoeySelectWithIndex((index, url) => $"{index+1}. {url}");
            var expected = new List<string>
            {
                "1. http://tw.yahoo.com",
                "2. https://facebook.com",
                "3. https://twitter.com",
                "4. http://github.com",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }


        [Test]
        public void get_full_name_of_employees()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };

            var actual = employees.JoeySelect(e => $"{e.FirstName} {e.LastName}");
            var expected = new[]
            {
                "Joey Chen",
                "Tom Li",
                "David Chen",
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }


        private static IEnumerable<string> GetUrls()
        {
            yield return "http://tw.yahoo.com";
            yield return "https://facebook.com";
            yield return "https://twitter.com";
            yield return "http://github.com";
        }

        private static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
        }
    }
}