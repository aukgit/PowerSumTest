using System;
using System.Collections.Generic;
using System.Linq;
using IO = ProgrammingAlgorithom.Base.InputOutputExtension;

namespace ProgrammingAlgorithom.Solution {
    public class PowerSumDisplay {

        public static void PowerSumHelper(int currentSum, int targetSum, int currentNumber, int n, ref int solutions) {
            if (currentSum == targetSum) {
                solutions++;
                return;
            }

            for (int i = currentNumber; Math.Pow(i,n) + currentSum <= targetSum; i++) {
                PowerSumHelper((int)Math.Pow(i, n) + currentSum, targetSum, i+1 , n, ref solutions);
            }
        }

        public static int PowerSum(int targetedNumber, int power) {
            int totalFound = 0;
            int sumUpto = 0;
            PowerSumHelper(sumUpto, targetedNumber,1,power,ref totalFound);

            return totalFound;
        }

    }
}
