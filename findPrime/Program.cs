using System;
using System.Collections.Generic;	
namespace findPrime
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Execute();
		}

		public static void Execute() {
			int m = 10;
			int n = 50;
			List<int> res = FindPrimes(m, n);
			foreach (var num in res) {
				Console.WriteLine(num);
			}
		}

		public static List<int> FindPrimes(int m, int n) {
			List<int> result = new List<int>();
			bool[] isNotPrime = new bool[n + 1];
			if (isNotPrime[1] == false) isNotPrime[1] = true;

			for (int i = 2; i <= n; i++) 
			{
				if (isNotPrime[i]==false)
				{
					for(int j = i*2;j<=n;j+=i)
					{
						isNotPrime[j] = true;
					}
				}
			}

			for (int k = m; k <= n ; k++)
			{ 
				if(isNotPrime[k] == false)
				{
					result.Add(k);
				}
			}

			return result;
		}
	}
}
