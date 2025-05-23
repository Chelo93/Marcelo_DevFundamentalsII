using ProblemSolving;
using ProblemSolving.Recursion;


namespace Test.Problemsolving
{
    public class FactorialTests
    {
        [Fact]
        public void Factorial_ShouldReturn1_WhenInputIs0()
        {

            int input = 0;
            int result = Factorial.SolveFactorial(input);

            Assert.Equal(1, result);
        }
        [Fact]
        public void Factorial_ShouldThrowError_WhenInputIsNegative()
        {

            int input = -1;

            Assert.Throws<ArgumentException>(() => Factorial.SolveFactorial(input));
        }

        [Fact]
        public void Factorial_ShouldReturn6_WhenInputIs3()
        {

            int input = 3;
            int result = Factorial.SolveFactorial(input);

            Assert.Equal(6, result);
        }
}
}