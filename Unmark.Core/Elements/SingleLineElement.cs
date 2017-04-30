namespace Unmark.Core.Elements
{
	abstract class SingleLineElement : AbstractLineElement
	{
		protected string Line;

		protected SingleLineElement(string regex)
			: base(regex)
		{
		}	   

		public override string Generate()
		{
			var result = Line;
			Line = null;
			return result;
		}
	}
}