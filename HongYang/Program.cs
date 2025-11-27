using System.Numerics;
using System.Text.RegularExpressions;

namespace WordCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string paragraph = "Hello world! This is a sample paragraph. This paragraph is for testing word count.";
            Execute(paragraph);
        }

        public static void Execute(string paragraph)
        { 
          List<string> result = CountWords(paragraph);
			foreach (var res in result)
			{
				Console.WriteLine(res);
			}
		}

        public static List<string> CountWords(string paragraph)
        {
			List<string> result = new List<string>();
            paragraph = Regex.Replace(paragraph.ToLower(), "[^a-z]", " ");
            string[] words = paragraph.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string,int> wordCounts = new Dictionary<string,int>();

            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;

				}
				else
				{
                    wordCounts.Add(word, 1);
				}
			}

            int maxValue = 0;
            foreach (var kvp in wordCounts)
            { 
                if(kvp.Value> maxValue) maxValue = kvp.Value;

			}

            foreach (var kvp in wordCounts)
            { 
                if (kvp.Value == maxValue) result.Add($"{kvp.Key}: {kvp.Value}次");
			}


			return result;

		}
    }
}
