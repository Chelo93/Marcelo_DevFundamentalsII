//  2. Print Server Load Balancer

// Description:

// A shared print server distributes incoming print tasks to multiple printers to keep them busy. You need to simulate the assignment logic:
// 1. EnqueueJob(string jobId): A new print job arrives and is placed in the waiting line.
// 2. AssignNext(): Pull the next job from the front of the line and send it to the least-busy printer.
// 3. CompleteJob(string printerId, string jobId): The printer finishes its current job and becomes available again.
// 4. Status(): Report the list of waiting jobs in order and each printer’s current job (or idle).
// Ensure that jobs are handled strictly in arrival order, and assignment always takes the oldest waiting job.

// Data Structure Choice: Queue for the waiting jobs and a dictionary for the printers to keep track of their current jobs.

namespace Exam1.Problems
{
    public class PrintServer
    {
        private readonly Queue<string> jobQueue;
        private readonly Dictionary<string, string> printers;

        public PrintServer(IEnumerable<string> printerIds)
        {
            jobQueue = new Queue<string>();
            printers = new Dictionary<string, string>();
            foreach (var printerId in printerIds)
            {
                printers[printerId] = null!; // Initialize with null to indicate no job assigned
            }


        }

        public void EnqueueJob(string jobId)
        {
            jobQueue.Enqueue(jobId);
        }

        private string GetAvailablePrinter()
        {
            foreach (var printer in printers.Keys)
            {
                if (printers[printer] == null)
                {
                    return printer;
                }
            }
            return null!;

        }

        public void AssignNext()
        {
            if (jobQueue.Count == 0)
            {
                Console.WriteLine("No jobs in the queue.");
                return;
            }

            string jobId = jobQueue.Dequeue();
            string printerId = GetAvailablePrinter();

            if (printerId != null)
            {
                printers[printerId] = jobId;
                Console.WriteLine($"Assigned job {jobId} to printer {printerId}.");
            }
            else
            {
                Console.WriteLine("No available printers.");
                jobQueue.Enqueue(jobId); // Re-enqueue the job if no printer is available
            }
        }

        public void CompleteJob(string printerId)
        {
            if (printers.ContainsKey(printerId))
            {
                string jobId = printers[printerId];
                if (jobId != null)
                {
                    Console.WriteLine($"Printer {printerId} completed job {jobId}.");
                    printers[printerId] = null!;
                }
                else
                {
                    Console.WriteLine($"Printer {printerId} is already idle.");
                }
            }
            else
            {
                Console.WriteLine($"Printer {printerId} not found.");
            }
        }

        public void Status()
        {
            Console.WriteLine("Waiting jobs:");
            foreach (var job in jobQueue)
            {
                Console.WriteLine(job);
            }

            Console.WriteLine("Printer status:");
            foreach (var printer in printers)
            {
                Console.WriteLine($"Printer {printer.Key}: {(printer.Value == null ? "Idle" : $"Printing job {printer.Value}")}");
            }
        }
    }
}