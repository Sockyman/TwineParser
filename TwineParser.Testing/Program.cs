using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwineParser.Testing
{
	class Program
	{
		static void Main(string[] args)
		{
			BasicStoryFormat s = (BasicStoryFormat)HtmlParser.LoadStoryFromFile("asdf.html");

			s.Begin();

			//Console.ReadKey();
		}
	}
}
