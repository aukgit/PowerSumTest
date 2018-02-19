using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingAlgorithom.Base;

namespace ProgrammingAlgorithom.Solution {
    public static class CombinationGenerator {

        private static int calls = 0;
        public static void CombinationHelper(string givenString, List<string> chosenList) {
            // int remaingLength = givenString.Length - chosenList.Count;
            calls++;
            if (givenString.Length == 0) {
                InputOutputExtension.PrintList(chosenList);
                GC.Collect();
            } else {

                // chose - explore
                string first = givenString[0].ToString();
                givenString = givenString.Remove(0, 1);
                chosenList.Add(first);
                CombinationHelper(givenString, chosenList);

                // explore
                chosenList.RemoveAt(chosenList.Count - 1);
                CombinationHelper(givenString, chosenList);

                // unchose
                // givenString = givenString.Insert(0, first);
            }
        }

        public static void Combination(string givenString) {
            calls = 0;
            var chosen = new List<string>(givenString.Length * 2);
            // StringBuilder sb = new StringBuilder(givenString);
            // Console.WriteLine(sb[0]);
            CombinationHelper(givenString, chosen);
            Console.WriteLine("\nTotal Calls : " + calls);
        }

        public static void CombinationHelper<T>(LinkedList<T> list, List<T> chosen, ref List<List<T>> compiledList) {
            calls++;
            if (list.Count == 0) {
                if (chosen.Count > 0) {
                    compiledList.Add(new List<T>(chosen));
                }
                // chosen = new List<T>(list.Count);
            } else {
                // chose
                var first = list.First.Value;
                list.RemoveFirst();
                chosen.Add(first);

                // explore
                CombinationHelper(list, chosen, ref compiledList);

                // un-chose
                chosen.RemoveAt(chosen.Count - 1);
                CombinationHelper(list, chosen, ref compiledList);
                list.AddFirst(first);

            }
        }

        public static List<List<T>> Combination<T>(LinkedList<T> list) {
            calls = 0;
            var chosen = new List<T>(list.Count);
            var possibilities = Math.Pow((double) 2, (double) list.Count);
            var compiledList = new List<List<T>>((int) possibilities);

            CombinationHelper(list, chosen, ref compiledList);

            Console.WriteLine("\nTotal Calls : " + calls);
            return compiledList;
        }
    }
}
