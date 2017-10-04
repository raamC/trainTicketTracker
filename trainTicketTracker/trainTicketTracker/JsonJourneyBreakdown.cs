using System;

namespace trainTicketTracker
{
	
	public class JsonJourneyBreakdown
	{
		public string departureStationName { get; set; }
		public string departureStationCRS { get; set; }
		public string arrivalStationName { get; set; }
		public string arrivalStationCRS { get; set; }
		public object statusMessage { get; set; }
		public string departureTime { get; set; }
		public string arrivalTime { get; set; }
		public int durationHours { get; set; }
		public int durationMinutes { get; set; }
		public int changes { get; set; }
		public int journeyId { get; set; }
		public int responseId { get; set; }
		public string statusIcon { get; set; }
		public object hoverInformation { get; set; }	

		public JsonJourneyBreakdown()
		{
			//constructor
		}


	}
}
