using Exam1.Problems;
namespace Exam1
{
    public class Program
    {
        public static void Main()
        {
            var evaluator = new ExpressionEvaluator();
            evaluator.EnterNumber(5);
            evaluator.EnterOperator('+');
            evaluator.EnterNumber(3);
            Console.WriteLine(evaluator.Evaluate()); // Output: 8
            
            evaluator.EnterOperator('*');
            evaluator.EnterNumber(2);  
            Console.WriteLine(evaluator.Evaluate()); // Output: 16

            evaluator.Undo();
            Console.WriteLine(evaluator.Evaluate()); // Output: 8
        }
    }
}