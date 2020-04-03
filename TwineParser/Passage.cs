using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace TwineParser
{
	/// <summary>
	/// A passage is an individual story element or node in Twine. It contains text as well as instructions to progress the story.
	/// </summary>
	public class Passage
	{
		public string Name { get; }

		/// <summary>
		/// The id given to the passage by Twine. Rarely used.
		/// </summary>
		public int PId { get; }

		/// <summary>
		/// The text of the passage with no formatting or links.
		/// </summary>
		public string RawText { get; }

		/// <summary>
		/// The parent story to the passage.
		/// </summary>
		private Story story;

		public Passage(Story story, string name, int pId, string text)
		{
			this.story = story;
			Name = name;
			PId = pId;
			RawText = text;
		}


		public override string ToString()
		{
			return Name;
		}
	}
}
