using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using ExpectedObjects;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyLastOrDefaultTests
    {
        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<Employee>();
            var actual = JoeyLastOrDefault(employees);
            Assert.IsNull(actual);
        }


        [Test]
        public void get_last_employee()
        {
            var employees = new[]
            {
                new Employee() {FirstName = "Joey", LastName = "Chen"},
                new Employee() {FirstName = "Cash", LastName = "Chen"},
                new Employee() {FirstName = "David", LastName = "Chen"},
            };
            var actual = JoeyLastOrDefault(employees);
            var expected = new Employee() { FirstName = "David", LastName = "Chen" };
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private Employee JoeyLastOrDefault(IEnumerable<Employee> employees)
        {
            var sourceEnumerator = employees.GetEnumerator();

            Employee last = null;
            while (sourceEnumerator.MoveNext())
            {
                var item = sourceEnumerator.Current;
                last = item;
            }

            return last;
        }
    }
}