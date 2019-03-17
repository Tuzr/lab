using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;
using NUnit.Framework;

namespace CSharpAdvanceDesignTests
{

    [TestFixture]
    public class JoeySkipLastTest
    {
        [Test]
        public void skip_last_2()
        {
            var numbers = new[] { 10, 20, 30, 40, 50, 60 };
            var actual = JoeySkipLast(numbers, 2);

            var expected = new[] { 10, 20, 30, 40 };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeySkipLast(IEnumerable<int> numbers, int count)
        {
            var sourceEnumerator = numbers.GetEnumerator();
            var queue = new Queue<int>();
            while (sourceEnumerator.MoveNext())
            {
                var current = sourceEnumerator.Current;

                if (queue.Count == count)
                {
                    yield return queue.Dequeue();
                }
                queue.Enqueue(current);
            }

            //Queue<int> queue = new Queue<int>(numbers);

            //var queueCount = queue.Count;

            //for (int i = 0; i < queueCount - count; i++)
            //{
            //    yield return queue.Dequeue();
            //}
        }
    }
}
