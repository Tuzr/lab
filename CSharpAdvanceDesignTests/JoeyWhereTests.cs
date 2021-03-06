﻿using System;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyWhereTests
    {
        [Test]
        public void group_sum_count_is_3_sum_cost()
        {
            var products = new List<Product>
            {
                new Product {Id = 1, Cost = 11, Price = 110, Supplier = "Odd-e"},
                new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"},
                new Product {Id = 5, Cost = 51, Price = 510, Supplier = "Momo"},
                new Product {Id = 6, Cost = 61, Price = 610, Supplier = "Momo"},
                new Product {Id = 7, Cost = 71, Price = 710, Supplier = "Yahoo"},
                new Product {Id = 8, Cost = 18, Price = 780, Supplier = "Yahoo"}
            };

            var expected = new[]
            {
                63,
                153,
                89,
            };

            var actual = JoeyGroupSum(products,3, arg => arg.Cost);

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyGroupSum<TSource>(IEnumerable<TSource> sources,int pageSize, Func<TSource, int> selector)
        {
            var pageIndex = 0;

            while (sources.Count() >= pageSize*pageIndex)
            {
                yield return sources.Skip(pageSize * pageIndex).Take(pageSize).Sum(selector);
                pageIndex++;
            }
        }


        [Test]
        public void find_products_that_price_between_200_and_500()
        {
            var products = new List<Product>
            {
                new Product {Id = 1, Cost = 11, Price = 110, Supplier = "Odd-e"},
                new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"},
                new Product {Id = 5, Cost = 51, Price = 510, Supplier = "Momo"},
                new Product {Id = 6, Cost = 61, Price = 610, Supplier = "Momo"},
                new Product {Id = 7, Cost = 71, Price = 710, Supplier = "Yahoo"},
                new Product {Id = 8, Cost = 18, Price = 780, Supplier = "Yahoo"}
            };

            var actual = products.JoeyWhere(p => p.Price > 200 && p.Price < 500 && p.Cost > 30);

            var expected = new List<Product>
            {
                //new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"}
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void find_long_names()
        {
            var names = new List<string> { "Joey", "Cash", "William", "Sam", "Brian", "Jessica" };
            var actual = names.JoeyWhere(n => n.Length > 5);
            var expected = new[]
            {
                "William", "Jessica"
            };
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void find_odd_names()
        {
            var names = new List<string> { "Joey", "Cash", "William", "Sam", "Brian", "Jessica" };
            var actual = names.JoeyWhere((name, index) => index % 2 == 0);
            var expected = new[]
            {
                "Joey", "William", "Brian"
            };
            expected.ToExpectedObject().ShouldMatch(actual);
        }

    }
}