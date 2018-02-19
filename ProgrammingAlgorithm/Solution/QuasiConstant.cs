using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAlgorithom.Solution {
    public static class QuasiConstant {

        public static int GetConstant(int [] A) {
            if (A.Length < 1) return 0;

            if (A.Length > 1 && A.Length < 2) return 1;

            Array.Sort(A);

            List<int> quasiList = new List<int>();
            int counter = 0;
            int max = 0;

            for (int i = 0; i < A.Length; i++) {
                counter = i + 1;
                if (counter < A.Length) {
                    while (counter < A.Length && A[counter] - A[i] == 1) {
                        counter++;
                    }
                }
                quasiList.Add(counter - i);
            }

            return quasiList.Max();
        }

    }
}
