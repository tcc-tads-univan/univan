﻿namespace Univan.Application.Contracts.Subscription
{
    public class DriverSubscriptionsResult
    {
        public int FreeSeats { get; set; }
        public List<DriverStudents> Students { get; set; }
    }
}
