using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	sealed class HeaderElement : IElement
	{
		public int Priority => 100;

		private readonly Regex _regex;
		private readonly string _replacement;

		public HeaderElement()
		{
			_regex = new Regex(@"^(#{1,5})\s(.*)");
			_replacement = "<h1>$2</h1>";
		}

		public bool HasMatch(string input)
		{
			return _regex.IsMatch(input);
		}

		public string ProcessLine(string input)
		{
			var processLine = _regex.Replace(input, new MatchEvaluator(Replace));
			return processLine;
		}

		private string Replace(Match match)
		{
			var length = match.Groups[1].Length;

			return $"<h{length}>{match.Groups[2]}</h{length}>";
		}
	}
}