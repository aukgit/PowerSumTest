using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingAlgorithom.Base;
using ProgrammingAlgorithom.Solution;

namespace ProgrammingAlgorithom.Runner {
    public static class CombinationRunner {
        public static void Run() {
            while (true) {
                var input = InputOutputExtension.TakeInputAsString("Please enter a string to get combination : ");
                if (input != null) CombinationGenerator.Combination(input);
                Console.Write("\nCommand : ");
                var isExit = string.Equals(Console.ReadLine(), "exit", StringComparison.InvariantCultureIgnoreCase);
                if (isExit) break;
            }
        }

        public static void Run2() {
            while (true) {
                var input = InputOutputExtension.TakeInputAsInt("Please enter a number to generate combination : ");
                if (input != null) {
                    var list = new LinkedList<int>(Enumerable.Range(0, input.Value));
                    var compiledList = CombinationGenerator.Combination(list);

                    Console.Write("\nPrinting Combinations : ");
                    foreach (var combinationList in compiledList) {
                        InputOutputExtension.PrintList(combinationList);
                    }

                    Console.Write("\nCommand : ");
                }

                var isExit = string.Equals(Console.ReadLine(), "exit", StringComparison.InvariantCultureIgnoreCase);
                if (isExit) break;
            }
        }
    }
}
