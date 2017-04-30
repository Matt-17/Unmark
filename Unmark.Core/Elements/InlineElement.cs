using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	abstract class InlineElement : AbstractElement
	{
		protected string Replacement { get; }

		protected InlineElement(string regex, string replacement):base(regex)
		{
			Replacement = replacement;
		}
		public override bool HasMatch(string input)
		{
			return Regex.IsMatch(input);
		}

		public string Process(string input)
		{
			return Regex.Replace(input, Replacement);
		}
	}
}