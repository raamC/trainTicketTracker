using System;

namespace trainTicketTracker
{
	public class SingleJsonFareBreakdown
	{

		public string breakdownType { get; set; }
		public string fareTicketType { get; set; }
		public string ticketRestriction { get; set; }
		public string fareRouteDescription { get; set; }
		public string fareRouteName { get; set; }
		public string passengerType { get; set; }
		public string railcardName { get; set; }
		public string ticketType { get; set; }
		public string ticketTypeCode { get; set; }
		public string fareSetter { get; set; }
		public string fareProvider { get; set; }
		public string tocName { get; set; }
		public string tocProvider { get; set; }
		public int fareId { get; set; }
		public int numberOfTickets { get; set; }
		public double fullFarePrice { get; set; }
		public int discount { get; set; }
		public double ticketPrice { get; set; }
		public double cheapestFirstClassFare { get; set; }
		public string nreFareCategory { get; set; }
		public bool redRoute { get; set; }

		public SingleJsonFareBreakdown()
		{
			//constructor
		}
	}
}
