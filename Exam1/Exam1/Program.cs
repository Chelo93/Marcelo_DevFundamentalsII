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

//--------------------------------------------------------------
            var printServer = new PrintServer(new[] { "Printer1", "Printer2", "Printer3" });
            printServer.EnqueueJob("Job1");
            printServer.EnqueueJob("Job2");
            printServer.EnqueueJob("Job3");
            printServer.EnqueueJob("Job4");
            printServer.AssignNext(); // Assigns Job1 to a printer
            printServer.AssignNext();
            printServer.CompleteJob("Printer1");
            printServer.Status(); // Displays the status of waiting jobs and printers
        }
        

        
        
    }
}