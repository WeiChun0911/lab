using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public class ComboCompare: IComparer<Employee>
    {
        public ComboCompare(IComparer<Employee> firstCompareObject, IComparer<Employee> secondCompareObject)
        {
            FirstCompareObject = firstCompareObject;
            SecondCompareObject = secondCompareObject;
        }

        public IComparer<Employee> FirstCompareObject { get; private set; }
        public IComparer<Employee> SecondCompareObject { get; private set; }

        public int Compare(Employee x, Employee y)
        {
            var firstCompareResult = FirstCompareObject.Compare(x, y);
            if (firstCompareResult != 0)
            {
                return firstCompareResult;
            }

            return SecondCompareObject.Compare(x, y);
        }
    }
}