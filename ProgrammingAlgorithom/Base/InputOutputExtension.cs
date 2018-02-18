using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProgrammingAlgorithom.Base {
    public static class InputOutputExtension {
        public static TInputType TakeInput<TInputType>(string prompt) {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (input is TInputType) {
                return (TInputType) Convert.ChangeType(input, typeof(TInputType), CultureInfo.InvariantCulture);
            }

            return default(TInputType);
        }

        public static void PrintList<T>(List<T> list) {
            Console.WriteLine("[");
            list.ForEach(item => Console.Write(item + ",")); //Put a,b etc.
            Console.Write("]");
        }

        public static void PrintIndentFromUpper(int indent) {
            for (int i = indent; i >= 0; i--) {
                Console.Write("  ");
            }
        }

        public static void PrintIndentFromDown(int indent) {
            for (int i = 0; i < indent; i++) {
                Console.Write("  ");
            }
        }

        public static int? TakeInputAsInt(string prompt) {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) return int.Parse(input);
            return null;
        }

        public static string TakeInputAsString(string prompt) {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public static double? TakeInputAsDouble(string prompt) {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) return double.Parse(input);
            return null;
        }

        public static List<double> TakeInputAsDoubleList(string prompt) {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) {
                var array = input.Split(',');
                var list = new List<double>(array.Length);
                foreach (var item in array) {
                    double result = 0;
                    if (double.TryParse(item, out result)) {
                        list.Add(result);
                    }
                }

                return list;
            }

            return null;
        }

        public static List<string> TakeInputAsListString(string prompt) {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) {
                return input.Split(',').ToList();
            }

            return null;
        }

        public static List<int> TakeInputAsIntList(string prompt) {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) {
                var array = input.Split(',');
                var list = new List<int>(array.Length);
                foreach (var item in array) {
                    var result = 0;
                    if (int.TryParse(item, out result)) {
                        list.Add(result);
                    }
                }

                return list;
            }

            return null;
        }
    }
}
