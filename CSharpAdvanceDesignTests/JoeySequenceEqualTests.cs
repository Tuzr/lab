using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeySequenceEqualTests
    {
        [Test]
        public void compare_two_numbers_equal()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 3, 2, 1 };
            var actual = JoeySequenceEqual(first, second);
            Assert.IsTrue(actual);
        }

        [Test]
        public void compare_two_numbers_equal_second()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 1, 2, 3 };
            var actual = JoeySequenceEqual(first, second);
            Assert.IsFalse(actual);
        }

        [Test]
        public void compare_two_numbers_equal_third()
        {
            var first = new List<int> { 3, 2 };
            var second = new List<int> { 3, 2, 1 };
            var actual = JoeySequenceEqual(first, second);
            Assert.IsFalse(actual);
        }

        [Test]
        public void compare_two_numbers_equal_fourth()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 3, 2 };
            var actual = JoeySequenceEqual(first, second);
            Assert.IsFalse(actual);
        }

        [Test]
        public void compare_two_numbers_equal_fiveth()
        {
            var first = new List<int> { };
            var second = new List<int> { };
            var actual = JoeySequenceEqual(first, second);
            Assert.IsTrue(actual);
        }

        private bool JoeySequenceEqual(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (true)
            {
                bool firstFlag = firstEnumerator.MoveNext();
                bool secondFlag = secondEnumerator.MoveNext();

                if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
                {
                    return false;
                }

                if (firstFlag != secondFlag)
                {
                    return false;
                }

                if (firstFlag == false || secondFlag == false)
                {
                    return true;
                }
            }
        }
    }
}