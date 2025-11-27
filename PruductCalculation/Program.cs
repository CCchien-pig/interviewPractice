using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace PruductCalculation
{
	internal class Program
	{
		//計算產品總價及均價
		static void Main(string[] args)
		{
			string str = "COMPUTER 2 1000;MEMORY 2 5000";
			Execute(str);
		}

		public static void Execute(String str)
		{ 
			List<string> result = Process(str);
			foreach (var res in result)
			{
				Console.WriteLine(res);
			}
		}

		public static List<string> Process(string str)
		{ 
			List<string> result = new List<string>();
			if (string.IsNullOrEmpty(str)) return result;
			Dictionary<string, Product> map = new Dictionary<string, Product>();
			string[] split1 = str.Split(';', StringSplitOptions.RemoveEmptyEntries);

			foreach (var item in split1)
			{
				string[] split2 = item.Trim().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
				if (split2.Length != 3) continue;
				string name = split2[0];
				bool isAmountOk = int.TryParse(split2[1], out int amount);
				bool isPriceOk = int.TryParse(split2[2], out int price);

				if (isAmountOk && isPriceOk)
				{
					if (map.ContainsKey(name))
					{
						map[name].Amount += amount;
						map[name].TotalPrice += price* amount;
					}
					else
					{
						map.Add(name, new Product(amount, price * amount));
					}
				}
				else
				{
					continue;
				}

			}

			foreach (var kvp in map)
			{
				string name = kvp.Key;
				Product p = kvp.Value;
				string res = $"{name}的總價為{p.TotalPrice}，均價為{p.TotalPrice / p.Amount}";
				result.Add(res);
			}

			return result;
		}
	}

	public class Product
	{ 
		public int Amount { get; set; }
		public int TotalPrice { get; set; }

		public Product( int amount, int totalPrice)
		{
			Amount = amount;
			TotalPrice = totalPrice;
		}
	}
}
