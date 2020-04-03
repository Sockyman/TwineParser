using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TwineParser
{
	public class BasicStoryFormat : Story
	{
		public string linkReplacement = "?\\link";


		public BasicStoryFormat(string name, int startNode) : base(name, startNode)
		{
			
		}



		protected override void DisplayPassage(Passage passage)
		{
			// This is cursed


			base.DisplayPassage(passage);


			Regex regex = new Regex(@"\[\[(.*?)]]");
			MatchCollection matches = regex.Matches(passage.RawText);

			string s = regex.Replace(passage.RawText, linkReplacement);

			List<string> passages = new List<string>();
			int i = 0;
			foreach (Match m in matches)
			{
				i++;

				string value = m.Groups[1].Value;
				string[] seperateValues = value.Split('|');
				string target = seperateValues[seperateValues.Length - 1];

				int index = s.IndexOf(linkReplacement);
				s = s.Remove(index, linkReplacement.Length);

				s = s.Insert(index, i.ToString() + ": " + seperateValues[0]);

				passages.Add(target);
			}

			Console.WriteLine("\n" + s);

			string input = Console.ReadLine();

			int numb;
			if (int.TryParse(input, out numb) && passages.Count >= numb && numb > 0)
			{
				GoToPassage(passages[numb - 1]);
			}
		}
	}
}
