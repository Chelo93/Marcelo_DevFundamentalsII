using Exam1.Problems;
using Exam1.SingleResponsability;

namespace Exam1
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Problem 1: Expression Evaluator");
            
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

            Console.WriteLine("//--------------------------------------------------------------");
            Console.WriteLine("Problem 2: Print Server");
            
            var printServer = new PrintServer(new[] { "Printer1", "Printer2", "Printer3" });
            printServer.EnqueueJob("Job1");
            printServer.EnqueueJob("Job2");
            printServer.EnqueueJob("Job3");
            printServer.EnqueueJob("Job4");
            printServer.AssignNext(); // Assigns Job1 to a printer
            printServer.AssignNext();
            printServer.CompleteJob("Printer1");
            printServer.Status(); // Displays the status of waiting jobs and printers

            Console.WriteLine("//--------------------------------------------------------------");
            Console.WriteLine("Problem 3: Browser History");

            var browserHistory = new BrowserHistory("www.initialpage.com");
            browserHistory.GoTo("www.page1.com");
            browserHistory.GoTo("www.page2.com");
            Console.WriteLine(browserHistory.CurrentPage()); // Output: www.page2.com
            browserHistory.Back();
            Console.WriteLine(browserHistory.CurrentPage()); // Output: www.page1.com
            browserHistory.Forward();
            browserHistory.Forward();
            Console.WriteLine(browserHistory.CurrentPage()); // Output: www.page2.com
            browserHistory.GoTo("www.page3.com");
            Console.WriteLine(browserHistory.CurrentPage()); // Output: www.page3.com
            browserHistory.Back();
            Console.WriteLine(browserHistory.CurrentPage()); // Output: www.page2.com
            browserHistory.Back();
            browserHistory.Back();
            browserHistory.Back();
            Console.WriteLine(browserHistory.CurrentPage()); // Output: www.initialpage.com


            Console.WriteLine("//--------------------------------------------------------------");
            Console.WriteLine("Problem 4: Order Service");

            var orderProcessor = new OrderService();
            orderProcessor.ProcessOrders();
        }
        

        
        
    }
}