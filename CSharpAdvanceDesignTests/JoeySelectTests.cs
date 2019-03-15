using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    //[Ignore("not yet")]
    public class JoeySelectTests
    {
        [Test]
        public void replace_http_to_https()
        {
            var urls = GetUrls();

            var actual = JoeySelect(urls, url => url.Replace("http://", "https://"));
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
        public void replace_http_to_https_and_append_joey()
        {
            var urls = GetUrls();

            var actual = JoeySelect(urls, url => url.Replace("http://", "https://")+"/joey");
            var expected = new List<string>
            {
                "https://tw.yahoo.com/joey",
                "https://facebook.com/joey",
                "https://twitter.com/joey",
                "https://github.com/joey",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test] public void get_full_name()
        {

            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
            var expected = new[]
            {
                "Joey-Chen",
                "Tom-Li",
                "David-Chen",
            };

            var actual = JoeySelect(employees, e => $"{e.FirstName}-{e.LastName}");
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<TResult> JoeySelect<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            List<TResult> resultList = new List<TResult>();

            foreach (var item in source)
            {
                resultList.Add(selector(item));
            }

            return resultList;
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