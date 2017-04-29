using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	sealed class ItalicElement : InlineElement
	{
		public override int Priority => 120;

		public ItalicElement() 
			: base(@"(\*|_)(.*?)\1", "<i>$2</i>")
		{
		}
	}
}