using System;
using Unmark.Core.MarkdownParser;
using Xunit;

namespace Unmark.Tests
{
	public class MarkdownParserTest
	{
		private readonly IMarkdownParser _parser;
		private readonly string nl = Environment.NewLine;
		private readonly string ps = "<p>" + Environment.NewLine;
		private readonly string pe = "</p>" + Environment.NewLine;

		public MarkdownParserTest()
		{
			_parser = MarkdownParserFactory.CreateMarkdownParser();
		}

		[Fact]
		public void TestHeaderLines()
		{
			Assert.Equal(_parser.Parse("# Test"), "<h1>Test</h1>" + nl);
			Assert.Equal(_parser.Parse("## Test"), "<h2>Test</h2>" + nl);
			Assert.Equal(_parser.Parse("### Test"), "<h3>Test</h3>" + nl);
			Assert.Equal(_parser.Parse("#### Test"), "<h4>Test</h4>" + nl);
			Assert.Equal(_parser.Parse("##### Test"), "<h5>Test</h5>" + nl);
			Assert.Equal(_parser.Parse("###### Test"), ps + "###### Test" + nl + pe);
		}

		[Fact]
		public void TestQuoteLines()
		{
			Assert.Equal(_parser.Parse("> Test"), "<blockquote>Test</blockquote>" + nl);
			var s = "This is a test for a longer blockquote. Should work.";
			Assert.Equal(_parser.Parse($"> {s}"), $"<blockquote>{s}</blockquote>" + nl);
			Assert.Equal(_parser.Parse(" > Test"), ps + "> Test" + nl + pe);
			Assert.Equal(_parser.Parse(">Test"), ps + ">Test" + nl + pe);
		}

		[Fact]
		public void TestBoldLines()
		{
			Assert.Equal(_parser.Parse("**test**"), ps + "<b>test</b>" + nl + pe);
			Assert.Equal(_parser.Parse("This is a **test** line."), ps + "This is a <b>test</b> line." + nl + pe);
			Assert.Equal(_parser.Parse("This **is** a **test** line with **multiple** entries."), ps + "This <b>is</b> a <b>test</b> line with <b>multiple</b> entries." + nl + pe);
		}

		[Fact]
		public void TestItalicLines()
		{
			Assert.Equal(_parser.Parse("*test*"), ps + "<i>test</i>" + nl + pe);
			Assert.Equal(_parser.Parse("This is a *test* line."), ps + "This is a <i>test</i> line." + nl + pe);
			Assert.Equal(_parser.Parse("This *is* a *test* line with *multiple* entries."), ps + "This <i>is</i> a <i>test</i> line with <i>multiple</i> entries." + nl + pe);
		}

		[Fact]
		public void TestListLines()
		{
			Assert.Equal(_parser.Parse("* Test"), "<ul>" + nl + "<li>Test</li>" + nl + "</ul>" + nl);
			Assert.Equal(_parser.Parse("* foo" + nl + "* bar"), "<ul>" + nl + "<li>foo</li>" + nl + "<li>bar</li>" + nl + "</ul>" + nl);
			Assert.Equal(_parser.Parse("*"), "<ul>" + nl + "<li></li>" + nl + "</ul>" + nl);
			Assert.Equal(_parser.Parse("*Test"), ps + "*Test" + nl + pe);
			Assert.Equal(_parser.Parse("* Test" + nl + nl + "* Test"), "<ul>" + nl + "<li>Test</li>" + nl + "</ul>" + nl + "<ul>" + nl + "<li>Test</li>" + nl + "</ul>" + nl);
		}

		[Fact]
		public void TestTextLines()
		{
			Assert.Equal(_parser.Parse("Test"), ps + "Test" + nl + "</p>" + nl);
			Assert.Equal(_parser.Parse("Test\r\nTest"), ps + "Test<br />" + nl + "Test" + nl + "</p>" + nl);
		}
	}
}
