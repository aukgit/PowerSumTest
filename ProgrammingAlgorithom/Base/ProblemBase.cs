namespace ProgrammingAlgorithom.Base {
    public class ProblemBase {
        public virtual int SolutionAsInt<T>(T param1) {
            return -1;
        }
        public virtual double SolutionAsDouble<T>(T param1) {
            return -1;
        }

        public virtual string SolutionAsString<T>(T param1) {
            return null;
        }
    }
}
