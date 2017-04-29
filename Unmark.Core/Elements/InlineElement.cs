using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	abstract class InlineElement : IElement
	{
		public virtual int Priority => 100;
		protected Regex Regex { get; }
		protected string Replacement { get; }

		protected InlineElement(string regex, string replacement)
		{
			Regex = new Regex(regex);
			Replacement = replacement;
		}
		public bool HasMatch(string input)
		{
			return Regex.IsMatch(input);
		}

		public string Process(string input)
		{
			return Regex.Replace(input, Replacement);
		}
	}
}