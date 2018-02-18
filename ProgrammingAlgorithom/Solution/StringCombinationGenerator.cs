using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingAlgorithom.Base;

namespace ProgrammingAlgorithom.Solution {
    public static class StringCombinationGenerator {

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

       
    }
}
