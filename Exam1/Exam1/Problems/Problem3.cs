// 3. Browser History Navigation
// Description:

// Build a console app that simulates a web browser’s back and forward buttons. Users can:
// Navigate to a new URL (e.g. go https://example.com)
// Press “back” to return to the previous page (This can be a method)
// Press “forward” to go forward again (only if they’ve gone back before) (this can be a method)
// View their current page at any time
// Your implementation should efficiently handle an arbitrary sequence of these commands and report the current URL after each operation.

//
// Data Structure Choice: Two stacks to manage the back and forward navigation.

namespace Exam1.Problems
{
    public class BrowserHistory
    {
        private readonly Stack<string> backStack;
        private readonly Stack<string> forwardStack;
        private string currentUrl;

        public BrowserHistory(string initialUrl)
        {
            backStack = new Stack<string>();
            forwardStack = new Stack<string>();
            backStack.Push(initialUrl);
            currentUrl = initialUrl;
        }

        public void GoTo(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                Console.WriteLine("Invalid URL.");
                return;
            }
            backStack.Push(url);
            currentUrl = url;
            forwardStack.Clear();
        }

        public void Back()
        {
            if (backStack.Count > 1)
            {
                forwardStack.Push(backStack.Pop());
            }
            else
            {
                Console.WriteLine("No more pages in the back stack.");
            }
        }

        public void Forward()
        {
            if (forwardStack.Count > 0)
            {
                backStack.Push(forwardStack.Pop());
            }
            else
            {
                Console.WriteLine("No more pages in the forward stack.");
            }
        }

        public string CurrentPage()
        {
            return backStack.Peek();
        }
    }
}