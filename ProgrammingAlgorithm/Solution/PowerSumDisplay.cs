using System;
using System.Collections.Generic;
using System.Linq;
using IO = ProgrammingAlgorithom.Base.InputOutputExtension;

namespace ProgrammingAlgorithom.Solution {
    public class PowerSumDisplay {

        private static readonly Dictionary<string, LinkedList<int>> _cachedPossibleNumbers = new Dictionary<string, LinkedList<int>>(300);

        static LinkedList<int> CreateOrGetPossibleList(double targetedNumber, double power) {
            var key = "t:" + targetedNumber + "|p:" + power;

            if (_cachedPossibleNumbers.ContainsKey(key)) {
                return _cachedPossibleNumbers[key];
            }

            var possibleNumbersList = CreatePossibleNumbersList(targetedNumber, power);
            _cachedPossibleNumbers[key] = possibleNumbersList;
            return possibleNumbersList;
        }


        public static void PowerSumHelper(LinkedList<int> list, List<int> chosen, int sumUpto, ref int totalFound, int target) {
            if (list.Count == 0) {
                if (sumUpto == target) {
                    // IO.PrintList(chosen);
                    totalFound = totalFound + 1;
                }
            } else {
                var first = list.First.Value;
                chosen.Add(first);
                list.RemoveFirst();
                sumUpto += first;

                // explore
                if (sumUpto <= target) {
                    PowerSumHelper(list, chosen, sumUpto, ref totalFound, target);
                }
                // unchose
                chosen.RemoveAt(chosen.Count - 1);
                sumUpto -= first;
                if (sumUpto <= target) {
                    PowerSumHelper(list, chosen, sumUpto, ref totalFound, target);
                }
                list.AddFirst(first);

            }
        }

        public static int PowerSum(int targetedNumber, int power) {
            // Complete this function
            double dTargetedNumber = (double) targetedNumber;
            double dPower = (double) power;
            var possibleNumbersList = CreateOrGetPossibleList(dTargetedNumber, dPower);
            var chosen = new List<int>(possibleNumbersList.Count);
            int totalFound = 0;
            int sumUpto = 0;
            //var clonedList = new 
            PowerSumHelper(possibleNumbersList, chosen, sumUpto, ref totalFound, targetedNumber);

            return totalFound;
        }


        public static LinkedList<int> CreatePossibleNumbersList(double targetedNumber, double power) {
            int ending = (int) targetedNumber;
            var sumList = new LinkedList<int>();

            for (double i = 1; i <= ending; i++) {
                double poweredValue = 0;
                poweredValue = Math.Pow(i, power);
                sumList.AddLast((int) poweredValue);
                // sum += poweredValue;
                //if (poweredValue >= targetedNumber) {
                //    return sumList;
                //}
            }

            return sumList;
        }

        public static int GetSum(List<int> collection) {
            int len = collection.Count;
            int sum = 0;


            if (len == 0) {
                return 0;
            }

            if (len == 2) {
                sum = collection[0] + collection[1];
                return sum;
            }

            int mid = len / 2;
            int lastIndex = len - 1;
            // Console.WriteLine("Mid : " + indexes[mid] + "; val :" + collection[indexes[mid]]);
            for (int i = 0; i < mid; i++) {
                // Console.WriteLine("indexes[i] : " + indexes[i] + ", val : " + collection[indexes[i]] + "; indexes[lastIndex - i] : " + indexes[lastIndex - i] + ", val : " + collection[indexes[lastIndex - i]]);
                sum += collection[i] + collection[lastIndex - i];
            }

            if (len % 2 == 1) {
                sum = sum + collection[mid];
            }

            return sum;
        }
    }
}
