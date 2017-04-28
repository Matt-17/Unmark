using System;
using Unmark.Core;

namespace Unmark
{
    class Program
    {
        static void Main(string[] args)
        {
	        var parser = new MarkdownParser();
	        Console.WriteLine(parser.Parse("Hello World!"));
	        Console.ReadLine();
        }
    }
}