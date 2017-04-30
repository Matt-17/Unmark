using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	internal abstract class AbstractElement : IElement
	{
		protected AbstractElement(string regex)
		{
			Regex = new Regex(regex);

		}

		public virtual int Priority => 100;
		protected Regex Regex { get; }

		public virtual bool HasMatch(string input)
		{
			return Regex.IsMatch(input);
		}
	}
}