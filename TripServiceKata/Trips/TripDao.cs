using System;
using System.Collections.Generic;
using System.Text;
using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips
{
    public class TripDao
    {
        public static List<Trip> FindTripsByUser(User _)
        {
            throw new DependentClassCallException(
                "TripDAO should not be invoked on an unit test.");
        }
    }
}
