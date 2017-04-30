namespace Unmark.Core.Elements
{
	internal abstract class AbstractLineElement	 : AbstractElement
	{
		protected AbstractLineElement(string regex) : base (regex)
		{
		}

		public abstract void ProcessLine(string input);
		public abstract string Generate();
	}
}