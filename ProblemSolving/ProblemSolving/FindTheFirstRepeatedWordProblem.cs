
using System.Text.RegularExpressions;

namespace ProblemSolving
{
    /// <summary>
    /// Given a string represeting a paragraph, find the first word
    /// that repeats. Return the word itself. If no word is repeated,
    /// return null.
    /// 
    /// - Words are case-insensitive (This = this)
    /// - Punctuation should be ignored (even, = even)
    /// - Consider only alphanumeric characters as part of words
    /// 
    /// Input:
    /// "This is a test for you, students, this is the best"
    /// Output:
    /// "this"
    /// 
    /// Best data structure:
    /// Queue, because you need to track the order of the words.
    /// </summary>
    public static class FindTheFirstRepeatedWordProblem
    {
        public static string FindFirstRepeatedWord(string paragraph)
        {
           
            var matches = Regex.Matches(paragraph, @"[A-Za-z0-9]+");
            var seenWords = new Queue<string>();
            
            foreach (Match match in matches)
            {
                string word = match.Value.ToLower();
                if (seenWords.Contains(word))
                {
                    return word;
                }
                seenWords.Enqueue(word);
            }      
            return null!; 
        }
    }
}
