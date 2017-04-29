using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	sealed class BoldElement : IElement
	{
		public int Priority => 110;

		private readonly Regex _regex;
		private readonly string _replacement;

		public BoldElement()
		{
			_regex = new Regex(@"\*\*(.*?)\*\*");
			_replacement = "<b>$1</b>";
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