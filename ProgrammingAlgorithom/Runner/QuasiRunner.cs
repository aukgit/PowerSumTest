using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingAlgorithom.Base;
using ProgrammingAlgorithom.Solution;

namespace ProgrammingAlgorithom.Runner {
    public static class QuasiRunner {
        public static void Run() {
            while (true) {
                var input = InputOutputExtension.TakeInputAsIntArray("Please enter a string array [1,2,34] : ");
                var ans = 0;
                if (input != null) ans = QuasiConstant.GetConstant(input);
                InputOutputExtension.PrintArray(input);
                Console.WriteLine("\nQuasi-Constant : " + ans + "\n");

                Console.Write("\nCommand : ");
                var isExit = string.Equals(Console.ReadLine(), "exit", StringComparison.InvariantCultureIgnoreCase);
                if (isExit) break;
            }
        }
    }
}
