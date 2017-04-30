namespace Unmark.Core.MarkdownParser
{
	public interface IMarkdownParser
	{
		/// <summary>
		/// Parses the text and converts to HTML code
		/// </summary>
		/// <param name="inputText">Text which should be converted</param>
		/// <returns>The generated HTML code</returns>
		string Parse(string inputText);


		/// <summary>
		/// Parses the text and converts to HTML code
		/// </summary>
		/// <param name="lines">Text which should be converted as lines</param>
		/// <returns>The generated HTML code</returns>
		string Parse(string[] lines);
	}
}