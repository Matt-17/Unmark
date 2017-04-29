using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	sealed class HeaderElement : SingleLineElement
	{
		public HeaderElement() 
			: base(@"^(#{1,5})\s(.*)")
		{
		}

		public override string ProcessLine(string input)
		{
			var processLine = Regex.Replace(input, Replace);
			return processLine;
		}

		private string Replace(Match match)
		{
			var length = match.Groups[1].Length;

			return $"<h{length}>{match.Groups[2]}</h{length}>";
		}
	}
}