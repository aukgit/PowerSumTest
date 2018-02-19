using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgrammingAlgorithom.Base;
using IO = ProgrammingAlgorithom.Base.InputOutputExtension;

namespace ProgrammingAlgorithom.Solution {
    public class PowerSumDisplay {
        const int SumOf10SquareCollection = 385;
        const int SumOf14SquareCollection = 1015;
        const int SumOf10CubeCollection = 3025;
        private static Dictionary<string, List<int>> _cachedPossibleNumbers = new Dictionary<string, List<int>>(300);
        private static Dictionary<string, List<List<int>>> _cachedListIndexes = new Dictionary<string, List<List<int>>>(500);

        static List<int> CreateOrGetPossibleList(double targetedNumber, double power) {
            var key = "t:" + targetedNumber + "|p:" + power;

            if (_cachedPossibleNumbers.ContainsKey(key)) {
                return _cachedPossibleNumbers[key];
            }

            var possibleNumbersList = CreatePossibleNumbersList(targetedNumber, power);
            _cachedPossibleNumbers[key] = possibleNumbersList;
            return possibleNumbersList;
        }

        static List<List<int>> CreateOrGetPossibleIndexes(int range) {
            var key = "r:" + range + "|";
            if (_cachedListIndexes.ContainsKey(key)) {
                return _cachedListIndexes[key];
            }

            var indexesCollection = GenerateIndexesCombination(range);
            _cachedListIndexes[key] = indexesCollection;
            return indexesCollection;
        }

        public static int PowerSum(int targetedNumber, int power) {
            // Complete this function
            double dTargetedNumber = (double) targetedNumber;
            double dPower = (double) power;
            var possibleNumbersList = CreateOrGetPossibleList(dTargetedNumber, dPower);
            //var clonedList = new 

            var indexesCollection = CreateOrGetPossibleIndexes(possibleNumbersList.Count);

            var targetMatched = 0;

            Console.WriteLine("Found sum to be accurate : ");
            foreach (var indexes in indexesCollection) {
                var sum = GetSum(possibleNumbersList, indexes);
                if (sum == targetedNumber) {
                    IO.PrintList(possibleNumbersList, indexes);
                    targetMatched++;
                }
            }

            return targetMatched;
        }


        public static List<int> CreatePossibleNumbersList(double targetedNumber, double power) {
            int ending = (int)targetedNumber;

            //bool isSqaure = (int) power == 2;

            //if ((int) power == 1) {
            //    ending = 1000;
            //    return Enumerable.Range(1, ending).AsParallel().ToList();
            //}


            double sum = 0;

            var sumList = new List<int>(ending + 10);

            for (double i = 1; i <= ending; i++) {
                double poweredValue = 0;
                poweredValue = Math.Pow(i, power);
                sumList.Add((int) poweredValue);
                sum += poweredValue;
                //if (poweredValue >= targetedNumber) {
                //    return sumList;
                //}
            }

            return sumList;
        }

        public static List<List<int>> GenerateIndexesCombination(int range) {
            var list = new LinkedList<int>(Enumerable.Range(0, range));
            return CombinationGenerator.Combination(list);
        }
        
        public static int GetSum(List<int> collection, List<int> indexes) {
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
    }
}
