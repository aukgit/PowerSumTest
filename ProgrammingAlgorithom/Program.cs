using System;
using ProgrammingAlgorithom.Solution;
using IE = ProgrammingAlgorithom.Base.InputExtension;
namespace ProgrammingAlgorithom {
    public class Program {

        public static void Main(String[] args) {
            var problem = new BinaryNumberDisplay();

            while (true) {
                var input = IE.TakeInputAsInt("Please enter a number to print binary : ");
                if (input != null) problem.Solution(input.Value);
                var isExit = string.Equals(Console.ReadLine(), "exit", StringComparison.InvariantCultureIgnoreCase);
                if (isExit) break;
            }

        }
    }
}

