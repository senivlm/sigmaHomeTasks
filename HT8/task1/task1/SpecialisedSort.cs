using System;
using System.Collections.Generic;
using System.Text;

namespace task1
{
    public delegate int ComparisonOption(object first, object second);

    static class SpecialisedSort
    {
        public static void Sort(object[] array, ComparisonOption comparisonOption) 
        {
            bool isChanged = false;
            object tempElement = null;

            for (int i = 0; i < array.Length - 1; i++)
            {
                isChanged = false;

                for (int j = 0; j < array.Length - 1 - i; j++) 
                {
                    if (comparisonOption(array[j], array[j + 1]) > 0)
                    {
                        tempElement = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempElement;

                        isChanged = true;
                    }
                }

                if (!isChanged)
                {
                    break;
                }
            }
        }

    }
}
