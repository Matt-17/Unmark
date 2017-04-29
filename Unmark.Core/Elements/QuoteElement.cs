using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	sealed class QuoteElement : SingleLineElement
	{					   
		private readonly string _replacement;

		public QuoteElement()
			: base(@"^\>\s(.*)")
		{
			_replacement = "<blockquote>$1</blockquote>";
		}		   

		public override string ProcessLine(string input)
		{
			return Regex.Replace(input, _replacement);
		}
	}
}