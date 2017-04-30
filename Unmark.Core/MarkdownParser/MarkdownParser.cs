using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unmark.Core.Elements;
using Unmark.Core.Elements.Concrete;

namespace Unmark.Core.MarkdownParser
{
	class MarkdownParser : IMarkdownParser
	{
		private readonly List<IElement> _elements;

		public MarkdownParser()
		{
			var elements = new List<IElement>
			{
				new HeaderElement(),
				new QuoteElement(),
				new BoldElement(),
				new ItalicElement()	 ,
				new ListElement(),
			};

			// Order them by priority (e.g. *italic* markup after **bold** markup)
			_elements = elements.OrderBy(x => x.Priority).ToList();
		}

		public string Parse(string inputText)
		{
			var strings = inputText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

			StringBuilder sb = new StringBuilder();


			MultiLineElement multiLine = null;

			foreach (var input in strings)
			{
				if (multiLine != null)
				{
					if (multiLine.HasMatch(input))
					{
						multiLine.ProcessLine(input);
						continue;
					}
					sb.Append(multiLine.Generate());
					multiLine = null;
				}
				var isProcessed = false;
				foreach (var element in _elements.OfType<AbstractLineElement>())
				{
					if (!element.HasMatch(input))
						continue;
					isProcessed = true;
					element.ProcessLine(input);
					if (element is MultiLineElement multiLineElement)
					{
						multiLine = multiLineElement;
						break;
					}
					var s = element.Generate();
					sb.AppendLine(s);
					break;
				}
				if (!isProcessed)
					sb.AppendLine(input);
			}

			if (multiLine != null)
			{				   
				sb.Append(multiLine.Generate());
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