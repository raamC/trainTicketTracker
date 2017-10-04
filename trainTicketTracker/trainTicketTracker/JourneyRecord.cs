using System;
using System.Collections.Generic;

namespace trainTicketTracker
{
	public class JourneyRecord
	{

        public DateTime date { get; set; }
        public string departureStationName { get; set; }
		public string departureStationCRS { get; set; }
		public string arrivalStationName { get; set; }
		public string arrivalStationCRS { get; set; }
		public string departureTime { get; set; } //datetime
		public string arrivalTime { get; set; } //datetime
		public int durationHours { get; set; } //timespan
		public int durationMinutes { get; set; } //timespan
		public int changes { get; set; }
		
		public string fareTicketType { get; set; }
		public string fareRouteDescription { get; set; }
		public string fareRouteName { get; set; }
		public double fullFarePrice { get; set; }
		
		

	public JourneyRecord(DateTime theDate, RootObject rootObject)
	{
		date = theDate;

		departureStationName = rootObject.jsonJourneyBreakdown.departureStationName;
		departureStationCRS = rootObject.jsonJourneyBreakdown.departureStationCRS;
		arrivalStationName = rootObject.jsonJourneyBreakdown.arrivalStationName;
		arrivalStationCRS = rootObject.jsonJourneyBreakdown.arrivalStationCRS;
		departureTime = rootObject.jsonJourneyBreakdown.departureTime;  //datetime
		arrivalTime = rootObject.jsonJourneyBreakdown.arrivalTime;
		durationHours = rootObject.jsonJourneyBreakdown.durationHours;
		durationMinutes = rootObject.jsonJourneyBreakdown.durationMinutes; //calculate
		changes = rootObject.jsonJourneyBreakdown.changes;

		fareTicketType = rootObject.singleJsonFareBreakdowns[0].fareTicketType;
		fareRouteDescription = rootObject.singleJsonFareBreakdowns[0].fareRouteDescription;
		fareRouteName = rootObject.singleJsonFareBreakdowns[0].fareRouteName;
		fullFarePrice = rootObject.singleJsonFareBreakdowns[0].fullFarePrice;

    }

    public void checkRecord()
        {
            Console.WriteLine("Train departing from {0} to {1} at {2}. Ticket price {3:C}", departureStationName, arrivalStationName, departureTime, fullFarePrice);
        }


	}
}
