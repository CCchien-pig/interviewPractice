using System.Diagnostics.Tracing;

namespace stringProcessing
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string inp = "Hello, My. John saw saw saw";
			Execute(inp);
			Console.ReadLine();
		}

		public static void Execute(string inp) 
		{
			if (string.IsNullOrEmpty(inp)) return;
			// Split the string into words, removing punctuation
			string[] words = inp.Replace(",", " ").Replace(".", " ").Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

			//reverse the list of words
			Stack<string> reversedStack = new Stack<string>(words);

			//Count the frequency of each word
			Dictionary<string, int> map = new Dictionary<string, int>();
			foreach (var word in words)
			{
				if (map.ContainsKey(word))
				{
					map[word]++;
				}
				else
				{
					map.Add(word, 1);
				}
			}

			Console.WriteLine("Reversed words: ");
			foreach (var w in reversedStack)
			{
				Console.Write(w + " ");
			}

			Console.WriteLine("\n\nWord Frequencies: ");
			foreach (var kvp in map)
			{
				Console.WriteLine($"{kvp.Key}: {kvp.Value}");
			}

		}
	}
}
