using NUnit.Framework;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyAggregateTests
    {
        [Test]
        public void drawling_money_that_balance_have_to_be_positive()
        {
            var balance = 100.91m;

            var drawlingList = new List<int>
            {
                30, 80, 20, 40, 25
            };

            var actual = JoeyAggregate(drawlingList, balance);

            var expected = 10.91m;

            Assert.AreEqual(expected, actual);
        }

        private decimal JoeyAggregate(IEnumerable<int> drawlingList, decimal balance)
        {
            var enumerator = drawlingList.GetEnumerator();

            var result = balance;

            while (enumerator.MoveNext())
            {
                var itemCurrent = enumerator.Current;

                if (result - itemCurrent > 0)
                {
                    result = result - itemCurrent;
                }
            }

            return result;
        }
    }
}