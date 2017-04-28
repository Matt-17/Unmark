using System;
using Unmark.Core.MarkdownParser;
using Xunit;

namespace Unmark.Tests
{
    public class ElementTest
    {
	    private IMarkdownParser _parser;

	    public ElementTest()
	    {
		    _parser = MarkdownParserFactory.CreateMarkdownParser();
	    }

	    [Fact]
        public void TestHeaderElement()
        {
			
        }
    }
}
