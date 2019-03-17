using ExpectedObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyUnionTests
    {
        [Test]
        public void union_numbers()
        {
            var first = new[] { 1, 3, 5, 3, 1 };
            var second = new[] { 5, 3, 7, 7 };

            var actual = JoeyUnion(first, second);
            var expected = new[] { 1, 3, 5, 7 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyUnion(IEnumerable<int> first, IEnumerable<int> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            var hashSet = new HashSet<int>();

            while (firstEnumerator.MoveNext())
            {
                var item = firstEnumerator.Current;
                if (hashSet.Add(item))
                {
                    yield return item;
                }
            }

            while (secondEnumerator.MoveNext())
            {
                var item = secondEnumerator.Current;
                if (hashSet.Add(item))
                {
                    yield return item;
                }
            }
        }
    }
}