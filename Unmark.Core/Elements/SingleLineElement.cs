using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	abstract class SingleLineElement : IElement
	{
		public virtual int Priority => 100;
		protected Regex Regex { get; }

		protected SingleLineElement(string regex)
		{
			Regex = new Regex(regex);
		}

		public abstract string ProcessLine(string input);				

		public bool HasMatch(string input)
		{
			return Regex.IsMatch(input);
		}
	}
}