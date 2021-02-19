using System.Collections.Generic;
using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips
{
    public class TripDao : ITripDao
    {
        public virtual List<Trip> FindTripsBy(User user) => FindTripsByUser(user);

        public static List<Trip> FindTripsByUser(User _)
        {
            throw new DependentClassCallException(
                "TripDao should not be invoked in a unit test.");
        }
    }
}
