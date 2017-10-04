using System;
using System.Net; //for WebClient
using System.Collections.Generic; //for Lists
using System.Globalization; //for CultureInfo used by .StartsWith method
using System.Web.Script.Serialization; //for JavaScriptSerializer






namespace trainTicketTracker
{
	class MainClass
	{
		public static void Main(string[] args)
		{


			string rawHTML = GetHTMLCode("http://ojp.nationalrail.co.uk/service/timesandfares/OXF/EVE/141017/1200/dep"); //raw HTML source code

			DateTime departureDate = DateTime.Now.Date.AddDays(10);

			List<JourneyRecord> journeyRecords = SplitIntoJourneyRecords(departureDate,rawHTML);

			foreach (var item in journeyRecords)
            {
                item.checkRecord();
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


		private static RootObject ConvertFromJSON(string JSONblob)
		{
			JavaScriptSerializer deserializer = new JavaScriptSerializer();

			RootObject rootObject = deserializer.Deserialize<RootObject>(JSONblob);
			return rootObject;
		}


		private static List<RootObject> SplitIntoRootObjects(string HTMLcode)
		{
			List<string> rawJSONdata = SplitHTMLCode(HTMLcode); //rawJSONdata is now a List of strings, each containing the raw JSON data for one journey

			List<RootObject> journeyData = new List<RootObject>();

			foreach (string blob in rawJSONdata)
			{
				RootObject output = ConvertFromJSON(blob);
				journeyData.Add(output);
			}

			return journeyData;	
		}


		private static List<JourneyRecord> SplitIntoJourneyRecords(DateTime theDate, string HTMLcode)
		{
			List<RootObject> rootObjects = SplitIntoRootObjects(HTMLcode);

			List<JourneyRecord> journeyRecords = new List<JourneyRecord>();

			foreach (var item in rootObjects)
				{
	                journeyRecords.Add(new JourneyRecord(theDate, item));
				}

			return journeyRecords;
		}




	}
}
