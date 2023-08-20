using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontWpf
{
    public static class Extensions
	{
		public static bool HasUniqueDigits(this ushort number)
		{
			return HasUniqueDigitsInNumber(number);
		}

		private static bool HasUniqueDigitsInNumber(ushort number)
		{
			HashSet<char> digits = new HashSet<char>();

			string numberStr = number.ToString();
			foreach (char digit in numberStr)
			{
				if (!digits.Add(digit))
				{
					return false;
				}
			}

			return true;
		}
	}
}
