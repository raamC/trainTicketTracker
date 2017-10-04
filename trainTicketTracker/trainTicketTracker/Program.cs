using System;
using System.Net; //for WebClient
using System.Collections.Generic; //for Lists
using System.Globalization; //for CultureInfo used by .StartsWith method



namespace trainTicketTracker
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string code = GetHTMLCode("http://ojp.nationalrail.co.uk/service/timesandfares/OXF/EVE/141017/1200/dep"); //raw HTML source code

			foreach (var item in SplitHTMLCode(code))
			{
				Console.WriteLine(item);
			}

		}








		//helper methods

		private static string GetHTMLCode(string url)
		{
			WebClient client = new WebClient();

			string htmlCode = client.DownloadString(url);
			return htmlCode;
		}

		private static List<string> SplitHTMLCode(string HTMLcode)
		{
			string[] splitCode = HTMLcode.Split(new Char[] { '<', '>' }); //source code split by HTML tags

			List<string> rawJSONdata = new List<string>(); //empty list to catch JSON data 

			foreach (string s in splitCode)
			//works through splitCode and adds the JSON data to the list
			{
				if (s.Trim() != "") //checks it's not an empty string
				{
					CultureInfo ci = new CultureInfo("en-GB"); //necessary for .StartsWith method

					bool json = s.Trim().StartsWith("{\"jsonJourneyBreakdown", true, ci); //looks for the start of the JSON blobs

					if (json)
						rawJSONdata.Add(s);
				}
			}
			return rawJSONdata;
		}


	}
}
