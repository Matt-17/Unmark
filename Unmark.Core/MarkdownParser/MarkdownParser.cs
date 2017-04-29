using System.Collections.Generic;
using System.Linq;
using Unmark.Core.Elements;

namespace Unmark.Core.MarkdownParser
{
	class MarkdownParser : IMarkdownParser
	{
		private readonly List<IElement> _elements;

		public MarkdownParser()
		{
			var elements = new List<IElement> {
				new HeaderElement(),
				new QuoteElement(),
				new BoldElement(),
				new ItalicElement()
			};
			_elements = elements.OrderBy(x => x.Priority).ToList();
		}

		public string Parse(string input)
		{
			// TODO extract to lines
			foreach (var element in _elements)
			{
				if (element.HasMatch(input))
					return element.ProcessLine(input);
			}
			return input;
		}
	}
}
