using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estable.Lib.Extensions
{
	public static class StringExtensions
	{
		public static bool IsNullOrEmpty(this string arg)
		{
			return arg == null || arg == string.Empty;
		}
		public static bool IsNotNullOrEmpty(this string arg)
		{
			return false == (arg == null || arg == string.Empty);
		}
	}
}
