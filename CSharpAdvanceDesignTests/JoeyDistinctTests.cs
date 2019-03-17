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
            var actual = JoeyDistinct(numbers);

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

            var actual = JoeyDistinctWithEqualityComparer(employees, new JoeyEmployeeEqualityConverter());

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<TSource> JoeyDistinctWithEqualityComparer<TSource>(IEnumerable<TSource> employees, IEqualityComparer<TSource> comparer)
        {
            var enumerator = employees.GetEnumerator();

            var  hashSet = new HashSet<TSource>(comparer);

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (hashSet.Add(item))
                {
                    yield return item;
                }
            }
        }


        private IEnumerable<int> JoeyDistinct(IEnumerable<int> numbers)
        {
            return JoeyDistinctWithEqualityComparer(numbers, EqualityComparer<int>.Default);

            //var numbersEnumerator = numbers.GetEnumerator();

            //var hashSet = new HashSet<int>();

            //while (numbersEnumerator.MoveNext())
            //{
            //    var item = numbersEnumerator.Current;

            //    if (hashSet.Add(item))
            //    {
            //        yield return item;
            //    }
            //}
        }
    }
}