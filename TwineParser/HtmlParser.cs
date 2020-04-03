using System;
using System.Collections.Generic;
using HtmlAgilityPack; 

namespace TwineParser
{
	public static class HtmlParser
	{
		/// <summary>
		/// Creates a new instance of story from an html file.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static Story LoadStoryFromFile(string filePath)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.Load(filePath);

			// This is the stroy element in the html file.
			HtmlNode rootNode = new List<HtmlNode>(doc.DocumentNode.Descendants("tw-storydata"))[0];


			string storyName = rootNode.GetAttributeValue("name", "");
			int startNodePId = rootNode.GetAttributeValue<int>("startnode", 1);
			// This is the story that is returned.
			Story story = new BasicStoryFormat(storyName, startNodePId);


			// Finds all passage data elements in the story.
			List<HtmlNode> nodes = new List<HtmlNode>(rootNode.Descendants("tw-passagedata"));

			// Adds each passage to the story.
			foreach (HtmlNode n in nodes)
			{
				int pId = n.GetAttributeValue<int>("pid", 1);
				string name = n.GetAttributeValue("name", pId.ToString());
				string text = n.InnerText;
				Passage p = new Passage(story, name, pId, text);

				story.AddPassage(p);
			}

			return story;
		}

	}
}
