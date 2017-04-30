using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unmark.Core.MarkdownParser;
using Unmark.Web.Models;

namespace Unmark.Web.Controllers
{
	[Route("api/[controller]")]
	public class ParserController : Controller
	{
		public IMarkdownParser Parser { get; }

		// GET api/values
		public ParserController(IMarkdownParser parser)
		{
			Parser = parser;
		}

		/// <summary>
		/// Receives a markdown string and converts it to HTML
		/// </summary>
		/// <param name="data">string inside StringObject with markdown content</param>
		/// <returns>HTML code</returns>
		[HttpPost]
		public string Post([FromBody]StringObject data)
		{
			return Parser.Parse(data.Text);
		}
	}
}
