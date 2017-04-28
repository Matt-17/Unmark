namespace Unmark.Core.MarkdownParser
{
	public static class MarkdownParserFactory
	{
		public static IMarkdownParser CreateMarkdownParser()
		{
			return new MarkdownParser();
		}
	}
}