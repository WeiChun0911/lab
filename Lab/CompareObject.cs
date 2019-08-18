using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
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
}