using System.Collections.Generic;
using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user, User loggedInUser)
        {
            if (loggedInUser == null)
                throw new UserNotLoggedInException();

            return user.FriendsWith(loggedInUser) 
                ? FindTripsBy(user) 
                : NoTrips();
        }

        private static List<Trip> NoTrips() => new List<Trip>();

        protected virtual List<Trip> FindTripsBy(User user) => TripDao.FindTripsByUser(user);
    }
}
