using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unmark.Core.Elements.Concrete
{
	class TextElement : MultiLineElement
	{
		// List of lines as paragraphs
		private readonly List<List<string>> _paragraphs;

		// Priority is lowest since everything will be treated as text
		public override int Priority => 1000;

		public TextElement() : base(string.Empty)
		{
			_paragraphs = new List<List<string>> {
				new List<string>()
			};
		}

		public override bool HasMatch(string input)
		{
			// Accepts everything as text
			return true;
		}

		public override void ProcessLine(string input)
		{
			input = input.Trim();
			var lastParagraph = _paragraphs.Last();
			if (string.IsNullOrWhiteSpace(input))
			{
				if (lastParagraph.Count > 0)
					_paragraphs.Add(new List<string>());
				return;
			}
			lastParagraph.Add(input);
		}

		public override string Generate()
		{
			var sb = new StringBuilder();

			foreach (var paragraph in _paragraphs)
			{
				if (paragraph.Count == 0)
					continue;
				sb.AppendLine("<p>");
				for (var index = 0; index < paragraph.Count; index++)
				{
					var line = paragraph[index];
					if (index < paragraph.Count - 1)
						line += "<br />";
					sb.AppendLine(line);
				}
				sb.AppendLine("</p>");
			}
			_paragraphs.Clear();
			_paragraphs.Add(new List<string>());
			return sb.ToString();
		}
	}
}