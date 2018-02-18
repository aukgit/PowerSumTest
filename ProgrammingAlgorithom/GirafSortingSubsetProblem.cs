using System;

// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

namespace ProgrammingAlgorithom {
    public static class GirafSortingSubsetProblem {
        public static int Test(int[] A) {
            int groupDscCount = 0;
            int groupCount = 0;

            var len = A.Length;

            if (len == 0) {
                return 0;
            } else if (len == 1) {
                return 1;
            }

            len = len - 1;

            for (int i = 0; i < len; i++) {
                int? p = i > 0 ? (int?) A[i-1] : null;
                var c = A[i];
                var n = A[i + 1];


                var isInAscOrder = (c + 1 == n && !p.HasValue) || (c + 1 == n && p.HasValue && p.Value == c-1);
                var isInDscOrder = c - 1 == n;
                Console.WriteLine("c: " + c);
                Console.WriteLine("n: " + n);

                Console.WriteLine("isInAscOrder: " + isInAscOrder);
                Console.WriteLine("isInDscOrder: " + isInDscOrder);

                if (isInAscOrder) {
                    groupCount++;
                    Console.WriteLine("isInAscOrder, groupCount: " + groupCount);
                    if (groupDscCount > 0) {
                        // if any dsc count left
                        groupCount++;
                        groupDscCount = 0;//set the counter to 0
                    }
                } else if (isInDscOrder) {

                    groupDscCount++;
                    Console.WriteLine("isInDscOrder, groupDscCount: " + groupDscCount);
                } else {
                    groupCount++;
                    Console.WriteLine("not asc,dsc, groupCount,groupDscCount: " + groupCount + ", " + groupDscCount);
                   
                    Console.WriteLine("not asc,dsc, groupCount,groupDscCount: " + groupCount + ", " + groupDscCount);
                }


            }

            if (groupDscCount > 0) {
                // if any dsc count left
                groupCount++;
                groupDscCount = 0;//set the counter to 0
            }

            return groupCount;
        }
    }
}