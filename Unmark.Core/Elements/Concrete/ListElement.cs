using System.Collections.Generic;
using System.Text;

namespace Unmark.Core.Elements.Concrete
{
	class ListElement : MultiLineElement
	{
		private readonly List<string> _lines;
		private readonly string _replacement;

		public ListElement() : base(@"^\*(?:\s+(.*)|\s*$)")
		{
			_lines = new List<string>();
			_replacement = "<li>$1</li>";
		}

		public override void ProcessLine(string input)
		{
			_lines.Add(input);
		}

		public override string Generate()
		{
			var sb = new StringBuilder();
			sb.AppendLine("<ul>");
			foreach (var line in _lines)
			{
				sb.AppendLine(Regex.Replace(line, _replacement));
			}
			sb.AppendLine("</ul>");
			_lines.Clear();
			return sb.ToString();
		}
	}
}