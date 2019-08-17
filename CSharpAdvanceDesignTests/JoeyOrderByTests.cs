﻿using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    public class CompareObject: IComparer<Employee>
    {
        public CompareObject(Func<Employee, string> compareItemSelector, IComparer<string> comparer)
        {
            CompareItemSelector = compareItemSelector;
            Comparer = comparer;
        }

        public Func<Employee, string> CompareItemSelector { get; private set; }
        public IComparer<string> Comparer { get; private set; }

        public int Compare(Employee x, Employee y)
        {
            var firstCompareResult = Comparer.Compare(
                CompareItemSelector(x),
                CompareItemSelector(y));
            return firstCompareResult;
        }
    }

    public class ComboCompare
    {
        public ComboCompare(IComparer<Employee> firstCompareObject, IComparer<Employee> secondCompareObject)
        {
            FirstCompareObject = firstCompareObject;
            SecondCompareObject = secondCompareObject;
        }

        public IComparer<Employee> FirstCompareObject { get; private set; }
        public IComparer<Employee> SecondCompareObject { get; private set; }
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

        //    var actual = JoeyOrderByLastName(employees);

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
        public void orderBy_lastName_and_firstName()
        {
            var employees = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Wang"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Joey", LastName = "Chen"},
            };

            var actual = JoeyOrderByLastNameAndFirstName(
                employees, 
                new ComboCompare(
                    new CompareObject(currentElement => currentElement.LastName, Comparer<string>.Default), 
                    new CompareObject(currentElement => currentElement.FirstName, Comparer<string>.Default)));

            var expected = new[]
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Joseph", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "Joey", LastName = "Wang"},
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<Employee> JoeyOrderByLastNameAndFirstName(
            IEnumerable<Employee> employees, 
            ComboCompare comboCompare
            )
        {
            //bubble sort
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    var currentElement = elements[i];

                    var finalResult = Compare(comboCompare, currentElement, minElement);

                    if (finalResult < 0)
                    {
                        minElement = currentElement;
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }

        private static int Compare(ComboCompare comboCompare, Employee currentElement, Employee minElement)
        {
            int finalResult;
            var firstCompareResult = comboCompare.FirstCompareObject.Compare(currentElement, minElement);
            if (firstCompareResult < 0)
            {
                finalResult = firstCompareResult;
            }
            else if (firstCompareResult == 0)
            {
                var secondCompareResult = comboCompare.SecondCompareObject.Compare(currentElement, minElement);
                if (secondCompareResult < 0)
                {
                    finalResult = secondCompareResult;
                }
            }

            return finalResult;
        }

        private IEnumerable<Employee> JoeyOrderByLastName(IEnumerable<Employee> employees)
        {
            //bubble sort
            var stringComparer = Comparer<string>.Default;
            var elements = employees.ToList();
            while (elements.Any())
            {
                var minElement = elements[0];
                var index = 0;
                for (int i = 1; i < elements.Count; i++)
                {
                    if (stringComparer.Compare(elements[i].LastName, minElement.LastName) < 0)
                    {
                        minElement = elements[i];
                        index = i;
                    }
                }

                elements.RemoveAt(index);
                yield return minElement;
            }
        }
    }
}