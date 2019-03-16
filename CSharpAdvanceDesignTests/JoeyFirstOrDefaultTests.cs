using System.Collections.Generic;
using Lab;
using Lab.Entities;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyFirstOrDefaultTests
    {
        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<Employee>();

            var actual = employees.JoeyFirstOrDefault();
            
            Assert.IsNull(actual);
        }

        [Test]
        public void get_value_type()
        {
            var test = new List<int>();

            var actual = test.JoeyFirstOrDefault();

            Assert.AreEqual(0, actual);
        }
    }
}