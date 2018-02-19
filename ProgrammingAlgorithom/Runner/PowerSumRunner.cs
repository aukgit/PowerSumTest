using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingAlgorithom.Base;
using ProgrammingAlgorithom.Solution;

namespace ProgrammingAlgorithom.Runner {
    public static class PowerSumRunner {
      

        public static void Run() {
            while (true) {
                var target = InputOutputExtension.TakeInputAsInt("Please target number: ");
                var power = InputOutputExtension.TakeInputAsInt("Enter Power: ");
                if (power != null) {
                    if (target != null) {
                        int possibilities = PowerSumDisplay.PowerSum(target.Value, power.Value);
                        Console.WriteLine("Possibilities : " + possibilities);
                    }

                    Console.Write("\nCommand : ");
                }

                var isExit = string.Equals(Console.ReadLine(), "exit", StringComparison.InvariantCultureIgnoreCase);
                if (isExit) break;
            }
        }
    }
}
