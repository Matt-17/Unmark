using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unmark.Core.Elements
{
	interface IElement
	{
		int Priority { get; }
		bool HasMatch(string input);
	}
}
