using System;
using Unmark.Core.MarkdownParser;
using Xunit;

namespace Unmark.Tests
{
	public class MarkdownParserTest
	{
		private readonly IMarkdownParser _parser;

		public MarkdownParserTest()
		{
			_parser = MarkdownParserFactory.CreateMarkdownParser();
		}

		[Fact]
		public void TestHeaderLines()
		{
			Assert.Equal(_parser.Parse("# Test"), "<h1>Test</h1>");
			Assert.Equal(_parser.Parse("## Test"), "<h2>Test</h2>");
			Assert.Equal(_parser.Parse("### Test"), "<h3>Test</h3>");
			Assert.Equal(_parser.Parse("#### Test"), "<h4>Test</h4>");
			Assert.Equal(_parser.Parse("##### Test"), "<h5>Test</h5>");
		}
		[Fact]
		public void TestQuoteLines()
		{
			Assert.Equal(_parser.Parse("> Test"), "<blockquote>Test</blockquote>");
			var s = "This is a test for a longer blockquote. Should work.";
			Assert.Equal(_parser.Parse($"> {s}"), $"<blockquote>{s}</blockquote>");
			Assert.Equal(_parser.Parse(" > Test"), " > Test");
			Assert.Equal(_parser.Parse(">Test"), ">Test");
		}
	}
}
