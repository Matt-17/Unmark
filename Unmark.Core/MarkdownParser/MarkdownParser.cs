using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

			// Order them by priority (e.g. *italic* markup after **bold** markup)
			_elements = elements.OrderBy(x => x.Priority).ToList();
		}

		public string Parse(string inputText)
		{
			var strings = inputText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

			StringBuilder sb = new StringBuilder();





			foreach (var input in strings)
			{
				var s = input;
				foreach (var element in _elements.OfType<SingleLineElement>())
				{
					if (!element.HasMatch(s))
						continue;
					s = element.ProcessLine(s);
				}
				sb.AppendLine(s);
			}
			var text = sb.ToString();

			foreach (var element in _elements.OfType<InlineElement>())
			{
				if (!element.HasMatch(text))
					continue;
				text = element.Process(text);
			}
			return text;
		}
	}
}
