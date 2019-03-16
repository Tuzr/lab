using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeySkipTests
    {
        [Test]
        public void skip_2_employees()
        {
            var employees = GetEmployees();

            var actual = JoeySkip(employees, 0);

            var expected = new List<Employee>
            {
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Mike", LastName = "Chang"},
                new Employee {FirstName = "Joseph", LastName = "Yao"},
            };

            expected.ToExpectedObject().ShouldMatch(actual.ToList());
        }

        [Test]
        public void numbers_skip_3()
        {
            var numbers = new[] {10, 20, 30, 40};
            var actual = JoeySkip(numbers, 3);
            var expected = new[] {40};
            expected.ToExpectedObject().ShouldMatch(actual.ToList());
        }

      

        private IEnumerable<TSource> JoeySkip<TSource> (IEnumerable<TSource> source, int count)
        {
            var employeeEnumerator = source.GetEnumerator();

            int index = 0;

            while (employeeEnumerator.MoveNext())
            {
                if (index >= count)
                {
                    yield return employeeEnumerator.Current;
                }

                index++;
            }
        }

        private static IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"},
                new Employee {FirstName = "Mike", LastName = "Chang"},
                new Employee {FirstName = "Joseph", LastName = "Yao"},
            };
        }
    }
}