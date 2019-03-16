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
            var second = new List<int> { 3, 2, 1};

            var actual = JoeySequenceEqual(first, second);

            Assert.IsTrue(actual);
        }

        private bool JoeySequenceEqual(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                if (!firstEnumerator.Current.Equals(secondEnumerator.Current))
                {
                    return false;
                }
            }

            if (firstEnumerator.MoveNext() || secondEnumerator.MoveNext())
            {
                return false;
            }

            return true;
        }
    }
}