using System.Collections.Generic;
using Unmark.Core.Elements;

namespace Unmark.Core.MarkdownParser
{
	class MarkdownParser : IMarkdownParser
	{
		private List<IElement> elements = new List<IElement>();
		public MarkdownParser()
		{
			elements.Add(new HeaderElement());
		}

		public string Parse(string input)
		{
			// TODO extract to lines
			foreach (var element in elements)
			{
				if (element.HasMatch(input))
					return element.ProcessLine(input);
			}
			return input;
		}	 
	}
}
