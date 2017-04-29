using System.Text.RegularExpressions;

namespace Unmark.Core.Elements
{
	sealed class BoldElement : InlineElement
	{
		public override int Priority => 110; 

		public BoldElement() 
			: base(@"(\*\*|__)(.*?)\1", "<b>$2</b>")
		{
		}
	}
}							