using System;
using System.Collections.Generic;
using System.Text;

namespace OneHundredDaysCode.Searching
{
    class LienarSearch
    {

        public static int search(int[] arr, int x)
        {
            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
