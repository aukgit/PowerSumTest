using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerSumTest {
    public static class MinFind {

        #region Problem
        /**
     * Write a function:

        class Solution { public int solution(int[] A); }

        that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

        For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

        Given A = [1, 2, 3], the function should return 4.

        Given A = [−1, −3], the function should return 1.

        Assume that:

        N is an integer within the range [1..100,000];
        each element of array A is an integer within the range [−1,000,000..1,000,000].
        Complexity:

        expected worst-case time complexity is O(N);
        expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
     * */

        #endregion

        public bool IsSmallerA(int a, int b) {
            return a < b;
        }

        public int GetSmaller(int a, int b) {
            return (a <= b) ? a : b;
        }
        public int GetBigger(int a, int b) {
            return (a <= b) ? b : a;
        }

        public int ReturnSmallerNumberWhichIsNotPresentInAB(int a, int b) {
            var smaller = GetSmaller(a, b);
            var bigger = GetBigger(a, b);
            var smallerMinusOne = smaller - 1;

            int returningNumber = 1;

            if (smallerMinusOne != bigger) {
                returningNumber = smallerMinusOne;
            } else {
                returningNumber = bigger - 1;
            }

            if (returningNumber == 0) {
                returningNumber = 1;
            }

            return returningNumber;
        }

        public int ReturnPossibleMinNumberAmongAlreadyFoundAndAB(int alreadyFoundMin, int a, int b) {
            if (alreadyFoundMin == a || alreadyFoundMin == b) {
                return ReturnSmallerNumberWhichIsNotPresentInAB(a, b);
            }

            return alreadyFoundMin;
        }

       

        public int ReturnSmallerNumberWhichIsNotPresentInAB(int[] A, int index1, int index2) {
            return ReturnSmallerNumberWhichIsNotPresentInAB(A[index1], A[index2]);
        }


        public int Solution(int[] A) {
            int len = A.Length;
            int min = 1;
            int mindFound = 0;

            if (len == 0) {
                return min;
            }

            if (len == 2) {
                return ReturnSmallerNumberWhichIsNotPresentInAB(A, 0, 1);
            }

            int mid = len / 2;
            int lastIndex = len - 1;
            // Console.WriteLine("Mid : " + indexes[mid] + "; val :" + collection[indexes[mid]]);
            for (int i = 0; i < mid; i++) {
                // Console.WriteLine("indexes[i] : " + indexes[i] + ", val : " + collection[indexes[i]] + "; indexes[lastIndex - i] : " + indexes[lastIndex - i] + ", val : " + collection[indexes[lastIndex - i]]);
                if (mindFound == 0) {
                    mindFound = ReturnSmallerNumberWhichIsNotPresentInAB(A, i, lastIndex - i);
                } else {
                    mindFound = ReturnPossibleMinNumberAmongAlreadyFoundAndAB(mindFound, A[i], A[lastIndex - i]);
                }
            }
            return 0;
        }

    }
}
