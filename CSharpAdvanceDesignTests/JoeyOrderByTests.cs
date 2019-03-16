using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    public class CombineKeyComparer
    {
        public CombineKeyComparer(Func<Employee, string> keySelector, Comparer<string> keyComparer)
        {
            KeySelector = keySelector;
            KeyComparer = keyComparer;
        }

        public Func<Employee, string> KeySelector { get; private set; }
        public Comparer<string> KeyComparer { get; private set; }
    }

    [TestFixture]
    public class JoeyOrderByTests
    {
        //[Test]
        //public void orderBy_lastName()
        //{
        //    var employees = new[]
        //    {
        //        new Employee {FirstName = "Joey", LastName = "Wang"},
        //        new Employee {FirstName = "Tom", LastName = "Li"},
        //        new Employee {FirstName = "Joseph", LastName = "Chen"},
        //        new Employee {FirstName = "Joey", LastName = "Chen"},
        //    };

        //    var actual = JoeyOrderByLastNameAndFirstName(employees);

        //    var expected = new[]
        //    {
        //        new Employee {FirstName = "Joseph", LastName = "Chen"},
        //        new Employee {FirstName = "Joey", LastName = "Chen"},
        //        new Employee {FirstName = "Tom", LastName = "Li"},
        //        new Employee {FirstName = "Joey", LastName = "Wang"},
        //    };

        //    expected.ToExpectedObject().ShouldMatch(actual);
        //}

        [Test]
        public void orderBy_lastName_then_firstName()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = JoeyOrderByLastNameAndFirstName(employees, new CombineKeyComparer(element => element.LastName, Comparer<string>.Default), element1 => element1.FirstName, Comparer<string>.Default);

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Employee> JoeyOrderByLastNameAndFirstName(IEnumerable<Employee> employees, CombineKeyComparer combineKeyComparer, Func<Employee, string> secondKeySelector, Comparer<string> secondKeyComparer)
        {
            //bubble sort
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    var element = elements[i];
                    var compareResult = combineKeyComparer.KeyComparer.Compare(combineKeyComparer.KeySelector(element), combineKeyComparer.KeySelector(minElement));
                    var firstCompareResult = compareResult;
                    if (firstCompareResult < 0)
                    {
                        minElement = element;
                        index = i;
                    }
                    else if(firstCompareResult == 0)
                    {
                        if (secondKeyComparer.Compare(secondKeySelector(element), secondKeySelector(element)) < 0)
                        {
                            minElement = element;
                            index = i;
                        }
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }
    }
}