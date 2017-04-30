using System;
using Unmark.Core;
using Unmark.Core.MarkdownParser;

namespace Unmark
{
	class Program
	{
		static void Main(string[] args)
		{
			var parser = MarkdownParserFactory.CreateMarkdownParser();
			Console.WriteLine(parser.Parse("* Test\r\n* Test 2\r\n\r\n* Test"));

			Console.ReadLine();
		}
	}
}