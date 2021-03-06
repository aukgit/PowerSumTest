﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerSumTest {
    static class PowerSumTest {



        const int SumOf10SquareCollection = 385;
        const int SumOf14SquareCollection = 1015;
        const int SumOf10CubeCollection = 3025;
        private static LinkedList<int> _circurlarLinkedList;



        static int PowerSum(int targetedNumber, int power) {
            // Complete this function
            double dTargetedNumber = (double) targetedNumber;
            double dPower = (double) power;
            var list = CreateList(dTargetedNumber, dPower);
            //var clonedList = new 

            var indexesCollection = GeneratePermutationIndexesCollection(list);

            var targetMatched = 0;

            foreach (var indexes in indexesCollection) {
                var sum = GetSum(list, indexes);
                if (sum == targetedNumber) {
                    targetMatched++;
                }
            }

            return targetMatched;
        }

        static List<int> CreateList(double targetedNumber, double power) {
            int ending = 10;

            bool isSqaure = (int) power == 2;

            if ((int) power == 1) {
                ending = 1000;
                return Enumerable.Range(1, ending).AsParallel().ToList();
            }

            bool isPossibilityPresentInSumOf10SquaresCollection = isSqaure && targetedNumber <= SumOf10SquareCollection;
            bool isPossibilityPresentInSumOf14SquaresCollection = !isPossibilityPresentInSumOf10SquaresCollection && targetedNumber <= SumOf14SquareCollection;

            if (isPossibilityPresentInSumOf14SquaresCollection) {
                ending = 15;
            }

            double sum = 0;

            var sumList = new List<int>(ending + 10);

            for (double i = 1; i <= ending; i++) {
                double poweredValue = 0;
                poweredValue = Math.Pow(i, power);
                sumList.Add((int) poweredValue);
                sum += poweredValue;
                if (poweredValue >= targetedNumber) {
                    return sumList;
                }
            }

            return sumList;
        }

        static List<List<int>> GeneratePermutationIndexesCollection(List<int> collection) {
            var len = collection.Count;

            var range = Enumerable.Range(0, len).ToList();
            var possiblities = new List<List<int>>();

            possiblities.Add(range);

            _circurlarLinkedList = null;
            _circurlarLinkedList = new LinkedList<int>(Enumerable.Range(0, len));


            for (int i = 1; i <= len - 1; i++) {
                GetSubIndexList(ref possiblities, 0, len, i);
            }

            return possiblities;

        }

        static void GetSubIndexList(ref  List<List<int>> possiblities, int start, int end, int except) {
            int skiped = 0, indexCounter = 0;
            LinkedListNode<int> currentNode = null;

            for (int i = start; i < end; i++) {
                var listx = new List<int>(1);
                listx.Add(i);
                possiblities.Add(listx);
                var list = new List<int>(end + 5);
                list.AddRange(Enumerable.Range(0, i));
                for (int j = 0; j < end; j++) {
                    if (j == list.Count) {
                        break;
                    }
                }

                skiped = 0;
                if (list.Count > 0) {
                    possiblities.Add(list);
                }
            }

       
        }


        static int GetSum(List<int> collection, List<int> indexes) {
            int len = indexes.Count;
            int sum = 0;


            if (len == 0) {
                return 0;
            }

            if (len == 2) {
                sum = collection[indexes[0]] + collection[indexes[1]];
                return sum;
            }

            int mid = len / 2;
            int lastIndex = len - 1;
            // Console.WriteLine("Mid : " + indexes[mid] + "; val :" + collection[indexes[mid]]);
            for (int i = 0; i < mid; i++) {
                // Console.WriteLine("indexes[i] : " + indexes[i] + ", val : " + collection[indexes[i]] + "; indexes[lastIndex - i] : " + indexes[lastIndex - i] + ", val : " + collection[indexes[lastIndex - i]]);
                sum += collection[indexes[i]] + collection[indexes[lastIndex - i]];
            }

            if (len % 2 == 1) {
                sum = sum + collection[indexes[mid]];
            }

            return sum;
        }

        static void Main(String[] args) {
            int x = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            int result = PowerSum(x, n);
            int[] test = { 0, 1, 2, 3, 4, 5 };
            int[] testIndexes = { 0, 3, 1, 4, 5 };
            //double sum = GetSum(test, testIndexes);
            //Console.WriteLine(sum);
            Console.WriteLine(result);


            Console.ReadLine();
        }
    }
}
