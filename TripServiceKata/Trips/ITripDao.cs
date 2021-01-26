using System.Collections.Generic;
using TripServiceKata.Users;

namespace TripServiceKata.Trips
{
    public interface ITripDao
    {
        List<Trip> FindTripsFor(User user);
    }
}