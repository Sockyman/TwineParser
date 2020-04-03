using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwineParser
{
	/// <summary>
	/// A stroy holds all of the information about the story including all passages and the currently selected passage.
	/// To implement features
	/// </summary>
	public class Story
	{
		/// <summary>
		/// The name of the story.
		/// </summary>
		public string Name { get; }
		/// <summary>
		/// The id of the first node in the story.
		/// </summary>
		public int StartNode { get; }


		/// <summary>
		/// The passage which is currently being displayed.
		/// </summary>
		public Passage CurrentPassage { get; private set; }


		/// <summary>
		/// All passages in the story. A dictionary is used instead of a list so that it can be quickly parsed.
		/// </summary>
		protected Dictionary<string, Passage> passages;


		public Story(string name, int startNode)
		{
			Name = name;
			StartNode = startNode;

			passages = new Dictionary<string, Passage>();
		}


		/// <summary>
		/// Adds a passage to the collection of all passages.
		/// </summary>
		/// <param name="passage"></param>
		/// <returns></returns>
		public Passage AddPassage(Passage passage)
		{
			passages.Add(passage.Name, passage);

			return passage;
		}


		/// <summary>
		/// Displays the starting passage of the story.
		/// </summary>
		public void Begin()
		{
			Begin(GetPassage(StartNode).Name);
		}
		/// <summary>
		/// Displays the given passage and begins the story.
		/// </summary>
		/// <param name="passageName"></param>
		public void Begin(string passageName)
		{
			GoToPassage(passageName);
		}


		/// <summary>
		/// Returns the instance of a passage with the given name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public Passage GetPassage(string name)
		{
			return passages[name];
		}
		/// <summary>
		/// Returns the instance of a passage with the given id.
		/// </summary>
		/// <param name="pId"></param>
		/// <returns></returns>
		public Passage GetPassage(int pId)
		{
			foreach(Passage p in passages.Values)
			{
				if (p.PId == pId)
					return p;
			}
			return null;
		}


		/// <summary>
		/// Displays the current passage.
		/// </summary>
		public void DisplayPassage()
		{
			DisplayPassage(CurrentPassage);
		}
		/// <summary>
		/// Displays the given passage. The implementation of this is left mostly up to children of the story class.
		/// </summary>
		/// <param name="passage"></param>
		protected virtual void DisplayPassage(Passage passage)
		{

		}


		/// <summary>
		/// Sets the current passage to the passage with the given passage name.
		/// </summary>
		/// <param name="passageName"></param>
		/// <returns></returns>
		public Passage GoToPassage(string passageName)
		{
			return GoToPassage(GetPassage(passageName));
		}
		/// <summary>
		/// Sets the current passage to the passage with the given passage id.
		/// </summary>
		/// <param name="pId"></param>
		/// <returns></returns>
		public Passage GoToPassage(int pId)
		{
			return GoToPassage(GetPassage(pId));
		}
		/// <summary>
		/// Sets the current passage to the given passage.
		/// </summary>
		/// <param name="passage"></param>
		/// <returns></returns>
		protected Passage GoToPassage(Passage passage)
		{
			CurrentPassage = passage;
			DisplayPassage();
			return passage;
		}


		public override string ToString()
		{
			return Name;
		}
	}
}
