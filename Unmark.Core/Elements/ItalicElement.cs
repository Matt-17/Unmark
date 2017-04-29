using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	sealed class ItalicElement : IElement
	{
		public int Priority => 120;

		private readonly Regex _regex;
		private readonly string _replacement;

		public ItalicElement()
		{
			_regex = new Regex(@"\*(.*?)\*");
			_replacement = "<i>$1</i>";
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