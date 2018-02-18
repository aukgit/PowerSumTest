using System;
using ProgrammingAlgorithom.Base;

namespace ProgrammingAlgorithom.Solution {
    public class BinaryNumberDisplay {

        private void SolutionHelper(int binary, string prefix) {
            InputOutputExtension.PrintIndentFromDown(binary);

            Console.Write("SolutionHelper(" + binary + "," + prefix + ")\n");

            if (binary < 1)
                Console.WriteLine(prefix + " = [" + binary + "]");
            else {
                SolutionHelper(binary - 1, prefix + "0");
                SolutionHelper(binary - 1, prefix + "1");
            }
        }

        public void Solution(int binary) {
            SolutionHelper(binary, "");
        }
    }
}
