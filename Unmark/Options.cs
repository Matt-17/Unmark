using CommandLine;

namespace Unmark
{
	class Options
	{
		[Option('f', "file", Required = true, HelpText = "Input file to be processed.")]
		public string InputFile { get; set; }	 
	}
}