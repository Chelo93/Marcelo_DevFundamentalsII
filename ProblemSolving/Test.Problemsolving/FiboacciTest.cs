using ProblemSolving.Recursion;

namespace Test.Problemsolving
{
    public class FiboacciTest
    {
        [Fact]
        public void Fibonacci_ShouldReturn0_WhenInputIs0()
        {
            int input = 0;
            int result = Fibonacci.GetFibonacci(input);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Fibonacci_ShouldReturn1_WhenInputIs1()
        {
            int input = 1;
            int result = Fibonacci.GetFibonacci(input);

            Assert.Equal(1, result);
        }

        [Fact]
        public void Fibonacci_ShouldReturn1_WhenInputIs2()
        {
            int input = 2;
            int result = Fibonacci.GetFibonacci(input);

            Assert.Equal(1, result);
        }

        [Fact]
        public void Fibonacci_ShouldRetunr8_whenInputis6()
        {
            int input = 6;
            int result = Fibonacci.GetFibonacci(input);

            Assert.Equal(8, result);
        }
    }
}