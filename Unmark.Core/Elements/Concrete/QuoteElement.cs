namespace Unmark.Core.Elements.Concrete
{
	sealed class QuoteElement : SingleLineElement
	{
		private readonly string _replacement;

		public QuoteElement()
			: base(@"^\>\s(.*)")
		{
			_replacement = "<blockquote>$1</blockquote>";
		}

		public override void ProcessLine(string input)
		{
			Line = Regex.Replace(input, _replacement);
		}
	}
}