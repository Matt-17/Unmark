using System.Text.RegularExpressions;

namespace Unmark.Core.Elements.Concrete
{
	sealed class HeaderElement : SingleLineElement
	{
		public HeaderElement() 
			: base(@"^(#{1,5})\s(.*)")
		{
		}

		public override void ProcessLine(string input)
		{
			Line = Regex.Replace(input, Replace);
		}

		private string Replace(Match match)
		{
			var length = match.Groups[1].Length;

			return $"<h{length}>{match.Groups[2]}</h{length}>";
		}
	}
}