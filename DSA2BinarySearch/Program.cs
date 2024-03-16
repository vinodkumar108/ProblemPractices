using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA2BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class BinarySearch
    {

        public int Solve(List<int> A, int searchVal)
        {
            int L = 0;
            int R = A.Count - 1;
            int mid = 0;


            while(L<=R)
            {
                mid = (L + R) / 2;

                if(A[mid] == searchVal)
                {
                    return mid;
                }

                if(searchVal < A[mid])
                {
                    R = mid - 1;
                }
                else
                {
                    L = mid + 1;
                }
            }

            return mid;
        }

        //Suppose a sorted array A is rotated at some pivot unknown to you beforehand.

        //(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

        class RotatedSearch
        {
            public int Solve(List<int> A, int val)
            {
                int L = 0;
                int R = A.Count - 1;

                int mid = 0;

                while(L <= R)
                {
                    mid = (L + R) / 2;

                    if(A[mid] == val)
                    {
                        return mid;
                    }

                    if(val >= A[0]) //Item in 1st part
                    {
                        if(A[mid] <= A[0])
                        {
                            R = mid - 1;
                        }
                        else
                        {
                            if(val < A[mid])
                            {
                                R = mid - 1;
                            }
                            else
                            {
                                L = mid + 1;
                            }
                        }
                    }
                    else //need to search item in 2nd part
                    {
                        if(A[0] < A[mid])//curr in first part
                        {
                            L = mid + 1;
                        }
                        else
                        {
                            if(val < A[mid])
                            {
                                R = mid - 1;
                            }
                            else
                            {
                                L = mid + 1;
                            }
                        }
                    }
                }

                return mid;
            }

        }

    }
}
