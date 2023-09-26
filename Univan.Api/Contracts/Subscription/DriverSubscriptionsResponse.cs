﻿namespace Univan.Api.Contracts.Subscription
{
    public class DriverSubscriptionsResponse
    {
        public int FreeSeats { get; set; }
        public List<DriverStudents> Students { get; set; }

        public class DriverStudents
        {
            public int SubscriptionId { get; set; }
            public string Name { get; set; }
            public string Situation { get; set; }
        }
    }
}
