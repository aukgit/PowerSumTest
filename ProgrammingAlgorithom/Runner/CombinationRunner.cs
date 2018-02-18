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
                if (input != null) StringCombinationGenerator.Combination(input);
                Console.Write("\nCommand : ");
                var isExit = string.Equals(Console.ReadLine(), "exit", StringComparison.InvariantCultureIgnoreCase);
                if (isExit) break;
            }
        }
    }
}
