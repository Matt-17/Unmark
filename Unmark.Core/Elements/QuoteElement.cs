using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	sealed class QuoteElement : IElement
	{
		public int Priority => 100;

		private readonly Regex _regex;
		private readonly string _replacement;

		public QuoteElement()
		{
			_regex = new Regex(@"^\>\s(.*)");
			_replacement = "<blockquote>$1</blockquote>";
		}

		public bool HasMatch(string input)
		{
			return _regex.IsMatch(input);
		}

		public string ProcessLine(string input)
		{
			return _regex.Replace(input, _replacement);
		}
	}
}