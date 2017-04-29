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
			Assert.Equal(_parser.Parse("# Test"), "<h1>Test</h1>" + Environment.NewLine);
			Assert.Equal(_parser.Parse("## Test"), "<h2>Test</h2>" + Environment.NewLine);
			Assert.Equal(_parser.Parse("### Test"), "<h3>Test</h3>" + Environment.NewLine);
			Assert.Equal(_parser.Parse("#### Test"), "<h4>Test</h4>" + Environment.NewLine);
			Assert.Equal(_parser.Parse("##### Test"), "<h5>Test</h5>" + Environment.NewLine);
			Assert.Equal(_parser.Parse("###### Test"), "###### Test" + Environment.NewLine);
		}
		[Fact]
		public void TestQuoteLines()
		{
			Assert.Equal(_parser.Parse("> Test"), "<blockquote>Test</blockquote>" + Environment.NewLine);
			var s = "This is a test for a longer blockquote. Should work.";
			Assert.Equal(_parser.Parse($"> {s}"), $"<blockquote>{s}</blockquote>" + Environment.NewLine);
			Assert.Equal(_parser.Parse(" > Test"), " > Test" + Environment.NewLine);
			Assert.Equal(_parser.Parse(">Test"), ">Test" + Environment.NewLine);
		}

		[Fact]
		public void TestBoldLines()
		{
			Assert.Equal(_parser.Parse("**test**"), "<b>test</b>" + Environment.NewLine);
			Assert.Equal(_parser.Parse("This is a **test** line."), "This is a <b>test</b> line." + Environment.NewLine);
			Assert.Equal(_parser.Parse("This **is** a **test** line with **multiple** entries."), "This <b>is</b> a <b>test</b> line with <b>multiple</b> entries." + Environment.NewLine);
		}
		[Fact]
		public void TestItalicLines()
		{
			Assert.Equal(_parser.Parse("*test*"), "<i>test</i>" + Environment.NewLine);
			Assert.Equal(_parser.Parse("This is a *test* line."), "This is a <i>test</i> line." + Environment.NewLine);
			Assert.Equal(_parser.Parse("This *is* a *test* line with *multiple* entries."), "This <i>is</i> a <i>test</i> line with <i>multiple</i> entries." + Environment.NewLine);
		}
	}

}
