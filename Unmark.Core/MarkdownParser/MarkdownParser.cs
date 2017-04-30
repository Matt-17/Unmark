using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unmark.Core.Elements;
using Unmark.Core.Elements.Concrete;

namespace Unmark.Core.MarkdownParser
{
	/// <summary>
	/// Parser for Markdown code. 
	/// </summary>
	class MarkdownParser : IMarkdownParser
	{
		private readonly List<IElement> _elements;

		/// <summary>
		/// Creates a new instance of Markdown Parser
		/// </summary>
		public MarkdownParser()
		{
			var elements = new List<IElement>
			{
				new HeaderElement(),
				new QuoteElement(),
				new BoldElement(),
				new ItalicElement(),
				new ListElement(),
				new TextElement()
			};

			// Order them by priority (e.g. *italic* markup after **bold** markup)
			_elements = elements.OrderBy(x => x.Priority).ToList();
		}

		/// <summary>
		/// Parses the text and converts to HTML code
		/// </summary>
		/// <param name="inputText">Text which should be converted</param>
		/// <returns>The generated HTML code</returns>
		public string Parse(string inputText)
		{
			// split lines by new line char
			var lines = inputText.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
			return Parse(lines);
		}

		/// <summary>
		/// Parses the text and converts to HTML code
		/// </summary>
		/// <param name="lines">Text which should be converted as lines</param>
		/// <returns>The generated HTML code</returns>
		public string Parse(string[] lines)
		{								
			// create a StringBuilder for the output
			var sb = new StringBuilder();

			// there can only be one multiline element at once
			MultiLineElement multiLine = null;

			// analyze every line
			foreach (var input in lines)
			{
				// if already an working multiline ...
				if (multiLine != null)
				{
					var finish = false;
					// ... check if it general text element
					if (multiLine is TextElement)
					{
						// ... in this case check if higher priorized elements occur
						foreach (var element in _elements.OfType<AbstractLineElement>())
						{
							if (element is TextElement)
								continue;
							if (!element.HasMatch(input))
								continue;
							finish = true;
							break;
						}
					}
					// ... otherwise check if it can be processed by current
					if (!finish && multiLine.HasMatch(input))
					{
						multiLine.ProcessLine(input);
						continue;
					}
					// ... if not flush to output 
					sb.Append(multiLine.Generate());
					multiLine = null;
				}

				// check all line elements by priority if they find a match
				foreach (var element in _elements.OfType<AbstractLineElement>())
				{
					if (!element.HasMatch(input))
						continue;
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
			}

			// Multiline element still in work, flush it
			if (multiLine != null)
			{
				sb.Append(multiLine.Generate());
				multiLine = null;
			}

			// output text to string
			var text = sb.ToString();

			// Inline elements can be in whole text and should be analyzed in priority over full text
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