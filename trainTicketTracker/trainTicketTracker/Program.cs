using System;
using System.Net;


namespace trainTicketTracker
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string code = GetHTMLCode("http://ojp.nationalrail.co.uk/service/timesandfares/OXF/EVE/141017/1200/dep"); //raw HTML source code
			Console.WriteLine(code);
		}

		//helper methods

		private static string GetHTMLCode(string url)
		{
			WebClient client = new WebClient();

			string htmlCode = client.DownloadString(url);
			return htmlCode;
		}

	}
}
