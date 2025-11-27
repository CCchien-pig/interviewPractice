namespace nameOrdering
{
	public class SortNames
	{
		static void Main(string[] args)
		{
			Execute();
		}
		public static void Execute()
		{
			string[] names = { "Zoe", "Alice", "John", "Bob" };
			List<string> nameList = new List<string>(names);
			nameList.Sort((s1, s2) => { return s1.CompareTo(s2); });
			foreach (var name in nameList) { 
			Console.WriteLine(name);
			}
		}
	}
}
