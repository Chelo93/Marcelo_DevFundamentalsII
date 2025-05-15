using Generics;

namespace Test.Generics
{
    public class TestCalculator
    {
        [Fact]
        public void Calculator_ShouldAddValues()
        {
            var TCalculator = new Calculator<int>();
            var result = TCalculator.Add(1,2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Calculator_ShouldSubstractAValues()
        {
            var TCalculator = new Calculator<int>();
            var result = TCalculator.Substract(2,1);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Calculator_ShouldMultiplyValues()
        {
            var TCalculator = new Calculator<int>();
            var result = TCalculator.Multiply(3,2);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Calculator_ShouldDivideValues()
        {
            var TCalculator = new Calculator<int>();
            var result = TCalculator.Divide(10,2);
            Assert.Equal(5, result);
        }
    }
}
