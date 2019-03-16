using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyZipTests
    {
        [Test]
        public void pair_girls_and_keys()
        {
            var girls = new List<Girl>
            {
                new Girl() {Name = "Mary"},
                new Girl() {Name = "Jessica"},
            };

            var keys = new List<Key>
            {
                new Key() {Type = CardType.BMW, Owner = "Joey"},
                new Key() {Type = CardType.TOYOTA, Owner = "David"},
                new Key() {Type = CardType.Benz, Owner = "Tom"},
            };

            var pairs = JoeyZip(girls, keys,(g,k)=>$"{g.Name}-{k.Owner}");

            var expected = new[]
            {
                "Mary-Joey",
                "Jessica-David",
            };

            expected.ToExpectedObject().ShouldMatch(pairs);
        }

        [Test]
        public void pair_girls_and_car()
        {
            var girls = new List<Girl>
            {
                new Girl() {Name = "Mary"},
                new Girl() {Name = "Jessica"},
            };

            var keys = new List<Key>
            {
                new Key() {Type = CardType.BMW, Owner = "Joey"},
                new Key() {Type = CardType.TOYOTA, Owner = "David"},
                new Key() {Type = CardType.Benz, Owner = "Tom"},
            };

            var pairs = JoeyZip(girls, keys,(g,k)=> $"{g.Name}-{k.Type}");

            var expected = new[]
            {
                "Mary-BMW",
                "Jessica-TOYOTA",
            };

            expected.ToExpectedObject().ShouldMatch(pairs);
        }

        private IEnumerable<TResult> JoeyZip<TResource1, TResource2, TResult>(IEnumerable<TResource1> source1, IEnumerable<TResource2> source2, Func<TResource1, TResource2, TResult> resultFunc)
        {
            var girlEnumerator = source1.GetEnumerator();
            var keyEnumerator = source2.GetEnumerator();

            while (girlEnumerator.MoveNext() && keyEnumerator.MoveNext())
            {
                yield return resultFunc(girlEnumerator.Current,keyEnumerator.Current);
            }
        }
    }
}