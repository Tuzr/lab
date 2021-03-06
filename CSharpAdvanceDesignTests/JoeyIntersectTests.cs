﻿using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyIntersectTests
    {
        [Test]
        public void intersect_numbers()
        {
            var first = new[] { 1, 3, 5, 3 };
            var second = new[] { 5, 7, 3, 7 };

            var actual = JoeyIntersect(first, second);

            var expected = new[] { 3, 5 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyIntersect(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstEnumerator = first.GetEnumerator();

            var hashSet = new HashSet<int>(second);
            var hashSet2 = new  HashSet<int>();

            while (firstEnumerator.MoveNext())
            {
                var item = firstEnumerator.Current;
                if (!hashSet.Add(item) && hashSet2.Add(item))
                {                   
                    yield return item;                    
                }
            }
        }
    }
}