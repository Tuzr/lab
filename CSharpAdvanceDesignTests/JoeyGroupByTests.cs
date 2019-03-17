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

            var actual = JoeyGroupBy(
                employees,
                employee => employee.LastName);


            Assert.AreEqual(2, actual.Count());
            var firstGroup = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Eric", LastName = "Chen"},
                new Employee {FirstName = "John", LastName = "Chen"},
            };

            firstGroup.ToExpectedObject().ShouldMatch(actual.First().ToList());
        }

        private IEnumerable<IGrouping<string, Employee>> JoeyGroupBy(IEnumerable<Employee> employees, Func<Employee, string> groupKeySelector)
        {
            return new MyLookup(employees,groupKeySelector);
        }
    }

    internal class MyLookup : IEnumerable<IGrouping<string, Employee>>
    {
        private readonly IEnumerable<Employee> _employees;
        private readonly Func<Employee, string> _groupKeySelector;

        public MyLookup(IEnumerable<Employee> employees, Func<Employee, string> groupKeySelector)
        {
            _employees = employees;
            _groupKeySelector = groupKeySelector;
        }

        public IEnumerator<IGrouping<string, Employee>> GetEnumerator()
        {
            var lookup = new Dictionary<string, List<Employee>>();

            var employeeEnumerator = _employees.GetEnumerator();

            while (employeeEnumerator.MoveNext())
            {
                var employee = employeeEnumerator.Current;

                if (lookup.ContainsKey(_groupKeySelector(employee)))
                {
                    lookup[_groupKeySelector(employee)].Add(employee);
                }
                else
                {
                    lookup.Add(_groupKeySelector(employee), new List<Employee> { employee });
                }
            }

            return ConvertMultiGrouping(lookup).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<IGrouping<string, Employee>> ConvertMultiGrouping(Dictionary<string, List<Employee>> lookup)
        {
            var enumerator = lookup.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var keyValuePair = enumerator.Current;

                yield return new MyGrouping(keyValuePair.Key, keyValuePair.Value);
            }
        }
    }

    internal class MyGrouping : IGrouping<string, Employee>
    {
        private readonly IEnumerable<Employee> _collection;

        public string Key { get; }

        public MyGrouping(string key, List<Employee> collection)
        {

            Key = key;
            _collection = collection;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}