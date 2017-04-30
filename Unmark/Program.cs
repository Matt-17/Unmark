using System;
using System.IO;
using CommandLine;
using Unmark.Core.MarkdownParser;

namespace Unmark
{
	class Program
	{
		/// <summary>
		/// Reads a markdown file and outputs everything on screen
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			// Load command line option, in this case just file
			var options = Parser.Default.ParseArguments<Options>(args);
			options.WithParsed(Ececute);
			
			Console.ReadLine();
		}

		/// <summary>
		/// Executes with the desired options
		/// </summary>
		/// <param name="options">Options to run</param>
		private static void Ececute(Options options)
		{
			var parser = MarkdownParserFactory.CreateMarkdownParser();	
			var lines = File.ReadAllLines(options.InputFile);
			Console.WriteLine(parser.Parse(lines));
		}
	}
}