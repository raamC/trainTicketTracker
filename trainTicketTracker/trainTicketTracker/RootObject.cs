using System;
using System.Collections.Generic;

namespace trainTicketTracker
{
    public class RootObject
    {
		public JsonJourneyBreakdown jsonJourneyBreakdown { get; set; }
		public List<SingleJsonFareBreakdown> singleJsonFareBreakdowns { get; set; }
		public List<object> returnJsonFareBreakdowns { get; set; }


        public RootObject()
        {
            //constructor
        }


		public void checkRootObject()
		{
			Console.WriteLine("Train departing from {0} to {1} at {2}. Ticket price {3:C}",
							  jsonJourneyBreakdown.departureStationName,
							  jsonJourneyBreakdown.arrivalStationName,
							  jsonJourneyBreakdown.departureTime,
							  singleJsonFareBreakdowns[0].fullFarePrice);

		}

    }




}
