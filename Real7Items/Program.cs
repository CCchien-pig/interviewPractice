using System.Collections.Generic;

namespace Real7Items
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=== C# 上機考題測試 ===");

			// 1. 空心三角形
			Console.WriteLine("\n[1] 空心三角形座標 (高度 5)");
			PrintHollowTriangle(5);

			// 2. 質因數分解
			Console.WriteLine("\n[2] 質因數分解 (Input: 5832)");
			Console.WriteLine(PrimeFactorization(5832)); // 預期: 2^3*3^6

			// 3. 字串模糊查詢
			Console.WriteLine("\n[3] 字串模糊查詢");
			string[] dict = { "apple", "ban", "banana", "baking", "abandon", "ba" };
			// 題目要求：查找包含 "ba" 的字，按長度排序，再按字母序，回傳原始 index
			var result3 = FuzzySearch("ba", dict);
			Console.WriteLine($"{{{string.Join(", ", result3.Select(i => dict[i]))}}}");

			// 4. 括弧成對檢查
			Console.WriteLine("\n[4] 括弧檢查");
			Console.WriteLine($"{{[()]}}: {CheckParentheses("{[()]}")}");
			Console.WriteLine($"{{[(])}}: {CheckParentheses("{[(])}")}");

			// 5. 基因序列查詢
			Console.WriteLine("\n[5] 基因序列查詢 (找 ATG)");
			string gene = "CCATGTTATGGGATG";
			var result5 = FindGeneSequence(gene, "ATG");
			Console.WriteLine(string.Join(", ", result5));

			// 6. 硬幣組合
			Console.WriteLine("\n[6] 硬幣組合 (湊 30元)");
			var result6 = CoinCombinations(30);
			foreach (var s in result6) Console.WriteLine(s);

			// 7. 計算機
			Console.WriteLine("\n[7] 計算機");
			string expr = "6*(6+4(3+2))";
			// 題目要求輸出格式： (6*(6+4(3+2)))=156
			Console.WriteLine($"({expr})={Calculate(expr)}");

			Console.WriteLine("\n測試結束，按任意鍵離開...");
			Console.ReadKey();
		}

		// ==========================================
		// 請在下方實作區塊填寫程式碼
		// ==========================================

		/// <summary>
		/// 1. 印出空心三角形座標 (Row, Col)
		/// 假設是直角三角形或是正三角形皆可，此處以直角三角形為例
		/// *
		/// * *
		/// * *
		/// * * * *
		/// </summary>
		static void PrintHollowTriangle(int n)
		{
			// 用來暫存座標的清單，稍後再依序印出
			List<string> coordinates = new List<string>();

			Console.WriteLine("===圖形預覽===");

			for (int i = 0; i < n; i++)
			{
				// 1. 印出前導空白 (讓星星置中)
				// 為了讓 * 號圖形好看，這裡建議用單純的空白 " "，不要用 \t
				for (int s = 0; s < n - 1 - i; s++)
				{
					Console.Write(" ");
				}

				// 2. 處理每一行的內容
				for (int j = 0; j <= 2 * i; j++)
				{
					// 判斷邊界：左邊(j==0)、右邊(j==2*i)、底邊(i==n-1)
					if (j == 0 || j == 2 * i || i == n - 1)
					{
						// 條件成立：印出星星
						Console.Write("*");

						// 【關鍵】同時將此時的座標紀錄起來
						coordinates.Add($"({i},{j})");
					}
					else
					{
						// 條件不成立：印出中間的空心
						Console.Write(" ");
					}
				}
				// 該層結束，換行
				Console.WriteLine();
			}

			Console.WriteLine("\n===所有座標列表===");

			// 3. 將剛剛蒐集到的座標依序印出
			foreach (var coord in coordinates)
			{
				Console.Write(coord + " ");
			}

			// 最後補一個換行美觀
			Console.WriteLine();
		}

		/// <summary>
		/// 2. 質因數分解，回傳如 2^3*3^7 的字串
		/// </summary>
		static string PrimeFactorization(int num)
		{
			Dictionary<int,int> factors = new Dictionary<int,int>();

			int numcount = 0;
			while (num % 2 == 0) { 
				num /= 2;
				numcount++;
			}
			factors.Add(2, numcount);

			for (int i = 3; i * i <= num; i=i+2) {
				numcount = 0;
				while (num % i == 0)
				{
					num /= i;
					numcount++;
				}

				if (factors.ContainsKey(i))
				{
					factors[i] = numcount;
				}
				else
				{
					factors.Add(i, numcount);
				}

				if (num > 1) factors.Add(num, 1);
			}

			List<string> result = new List<string>();
			foreach (var f in factors)
			{
				 result.Add($"{f.Key}^{f.Value}");
			}
			return string.Join("*", result);
		}

		/// <summary>
		/// 3. 查找字典所有包含 query 的字
		/// 排序條件：1.長度(短到長) 2.字母順序
		/// 回傳：該字串在原始陣列的 Index
		/// linq運用
		/// </summary>
		static List<int> FuzzySearch(string query, string[] dictionary)
		{
			var result3 = dictionary
				.Select((str,i)=>new {str,i})
				.Where(x => x.str.Contains(query))
				.OrderBy(x => x.str.Length)
				.ThenBy(x => x.str)
				.Select(x => x.i)
				.ToList();
			return result3;


		}

		/// <summary>
		/// 4. 括弧成對檢查 (需支援 (), [], {})
		/// </summary>
		static bool CheckParentheses(string s)
		{
			Stack<char> parents = new Stack<char>();
			foreach (char c in s)
			{
				if (c == '{' | c == '[' | c == '(')
				{
					parents.Push(c);
				}
				else
				{
					
					if (parents.Count == 0) return false;
					char top = parents.Pop();
					if (c == '}' & top != '{') return false;
					if (c == ']' & top != '[') return false;
					if (c == ')' & top != '(') return false;
				}
			}
			return parents.Count == 0;
		}

		/// <summary>
		/// 5. 基因鹼基對序列重要序列查詢，回傳出現的起始索引
		/// </summary>
		static List<int> FindGeneSequence(string gene, string pattern)
		{
			// TODO: 請實作
			return new List<int>();
		}

		/// <summary>
		/// 6. 有5元、10元、1元，組成 amount 的所有可能性
		/// 回傳字串列表，如 "10元:x, 5元:y, 1元:z"
		/// </summary>
		static List<string> CoinCombinations(int amount)
		{
			// TODO: 請實作
			return new List<string>();
		}

		/// <summary>
		/// 7. 計算機，支援 +, *, () 以及隱藏乘號如 4(2)
		/// </summary>
		static int Calculate(string expression)
		{
			// TODO: 請實作
			return 0;
		}
	}
}
