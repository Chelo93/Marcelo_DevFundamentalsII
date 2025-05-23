using ProblemSolving.Recursion;
using ProblemSolving.Trees;


namespace ProblemSolving
{
    public class Program
    {
        public static void Main()
        {
            // var tree = new TreeNode<int>(10)
            // {
            //     Right = new TreeNode<int>(9)
            //     {
            //         Right = new TreeNode<int>(6),
            //         Left = new TreeNode<int>(5)
            //     },
            //     Left = new TreeNode<int>(8)
            //     {
            //         Right = new TreeNode<int>(3),
            //         Left = new TreeNode<int>(2)
            //         {
            //             Right = new TreeNode<int>(-1),
            //             Left = new TreeNode<int>(-2)
            //         }
            //     }
            // };

            // Tree.Preorder(tree);
            // Console.WriteLine();
            // Tree.Inorder(tree);
            // Console.WriteLine();
            // Tree.Postorder(tree);

            var paragraph = "This is a test for you, students, this is the best";
            var result = FindTheFirstRepeatedWordProblem.FindFirstRepeatedWord(paragraph);
            Console.WriteLine(result); 
        }
    }
}