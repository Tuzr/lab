using NUnit.Framework;
using System;
using System.Collections.Generic;
using Lab.Entities;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeySequenceEqualTests
    {
        //[Test]
        //public void compare_two_numbers_equal()
        //{
        //    var first = new List<int> { 3, 2, 1 };
        //    var second = new List<int> { 3, 2, 1 };
        //    var actual = JoeySequenceEqual(first, second);
        //    Assert.IsTrue(actual);
        //}

        //[Test]
        //public void compare_two_numbers_equal_second()
        //{
        //    var first = new List<int> { 3, 2, 1 };
        //    var second = new List<int> { 1, 2, 3 };
        //    var actual = JoeySequenceEqual(first, second);
        //    Assert.IsFalse(actual);
        //}

        //[Test]
        //public void compare_two_numbers_equal_third()
        //{
        //    var first = new List<int> { 3, 2 };
        //    var second = new List<int> { 3, 2, 1 };
        //    var actual = JoeySequenceEqual(first, second);
        //    Assert.IsFalse(actual);
        //}

        //[Test]
        //public void compare_two_numbers_equal_fourth()
        //{
        //    var first = new List<int> { 3, 2, 1 };
        //    var second = new List<int> { 3, 2 };
        //    var actual = JoeySequenceEqual(first, second);
        //    Assert.IsFalse(actual);
        //}

        //[Test]
        //public void compare_two_numbers_equal_fiveth()
        //{
        //    var first = new List<int> { };
        //    var second = new List<int> { };
        //    var actual = JoeySequenceEqual(first, second, Comparer<int>.Default);
        //    Assert.IsTrue(actual);
        //}

        [Test]
        public void compare_two_employee_equal()
        {

            var first = new List<Employee>
            {
                new Employee() {FirstName = "Joey", LastName = "Chen", Phone = "123"},
                new Employee() {FirstName = "Tom", LastName = "Li", Phone = "456"},
                new Employee() {FirstName = "David", LastName = "Wang", Phone = "789"},
            };


            var second = new List<Employee>
            {
                new Employee() {FirstName = "Joey", LastName = "Chen", Phone = "123"},
                new Employee() {FirstName = "Tom", LastName = "Li", Phone = "123"},
                new Employee() {FirstName = "David", LastName = "Wang", Phone = "123"},
            };

            IEqualityComparer<Employee> equalityComparer = new JoeyEmployeeEqualityConverter();

            var actual = JoeySequenceEqual(first, second, equalityComparer);
            Assert.IsTrue(actual);
        }

        public bool JoeySequenceEqual<TSource>(IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> joeyEmployeeEqualityConverter)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (true)
            {
                bool firstFlag = firstEnumerator.MoveNext();
                bool secondFlag = secondEnumerator.MoveNext();

                if (firstFlag != secondFlag)
                {
                    return false;
                }

                if (firstFlag == false)
                {
                    return true;
                }

                var firstItem = firstEnumerator.Current;
                var secondItem = secondEnumerator.Current;

                if (!joeyEmployeeEqualityConverter.Equals(firstItem, secondItem))
                {
                    return false;
                }
            }
        }
    }
}