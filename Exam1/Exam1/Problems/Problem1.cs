// 1. Expression Evaluator with Undo

// Description:
// Build a simple calculator that supports:
// 1. EnterNumber(double x) and EnterOperator(char op) (where op is +, -, *, or /) to build up an infix expression.
// 2. Evaluate(): Compute and return the current result.
// 3. Undo(): Remove the last entered number or operator.
// Users can chain operations (e.g. 5, +, 3, *, 2), then call Undo() multiple times to step back. After each change, `Evaluate()` should reflect the current expression.

// Data Structure Choice: Linked list due to we need to operate in the orther the user enterd the operations, but we need to remove the last operartor and number when calling the undo Function.
// NOTE: Undo will remove the last number and Operator to always have a valid operation to evaluate.

namespace Exam1.Problems
{
    public class ExpressionEvaluator
    {
        private readonly LinkedList<double> numbers;
        private readonly LinkedList<char> operators;

        public ExpressionEvaluator()
        {
            numbers = new LinkedList<double>();
            operators = new LinkedList<char>();
        }

        public void EnterNumber(double x)
        {
            numbers.AddLast(x);
        }

        public void EnterOperator(char op)
        {
            operators.AddLast(op);
        }

        public double Evaluate()
        {
            if (numbers.Count - 1 != operators.Count)
            {
                throw new InvalidOperationException("Invalid state: numbers and operators count mismatch.");
            }
            int noTooperate = numbers.Count;
            double result = 0;
            while (noTooperate > 0)
            {
                if (noTooperate == numbers.Count)
                {
                    double a = numbers.First!.Value;
                    numbers.AddLast(a);
                    numbers.RemoveFirst();
                    noTooperate--;

                    double b = numbers.First!.Value;
                    numbers.AddLast(b);
                    numbers.RemoveFirst();
                    noTooperate--;

                    char op = operators.First!.Value;
                    operators.AddLast(op);
                    operators.RemoveFirst();

                    result = op switch
                    {
                        '+' => a + b,
                        '-' => a - b,
                        '*' => a * b,
                        '/' => a / b,
                        _ => throw new InvalidOperationException("Invalid operator.")
                    };
                }
                else
                {
                    double x = numbers.First!.Value;
                    numbers.AddLast(x);
                    numbers.RemoveFirst();
                    noTooperate--;

                    char op = operators.First!.Value;
                    operators.AddLast(op);
                    operators.RemoveFirst();
                    result = op switch
                    {
                        '+' => result + x,
                        '-' => result - x,
                        '*' => result * x,
                        '/' => result / x,
                        _ => throw new InvalidOperationException("Invalid operator.")
                    };
                }
            }
            return result;
        }

        public void Undo()
        {
            if (numbers.Count == 0 || operators.Count == 0)
            {
                throw new InvalidOperationException("Nothing to undo.");
            }

            if (numbers.Count - 1 != operators.Count)
            {
                throw new InvalidOperationException("Invalid state: numbers and operators count mismatch.");
            }

            numbers.RemoveLast();
            operators.RemoveLast();

        }
    }
}