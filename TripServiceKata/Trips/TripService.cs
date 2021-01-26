using System.Collections.Generic;
using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user, User loggedInUser)
        {
            if (No(loggedInUser))
                throw new UserNotLoggedInException();

            return user.FriendsWith(loggedInUser) 
                ? TripsBy(user) 
                : NoTrips();
        }

        protected virtual List<Trip> TripsBy(User user)
        {
            return TripDao.FindTripsByUser(user);
        }

        private static List<Trip> NoTrips()
        {
            return new List<Trip>();
        }

        private static bool No(User loggedInUser)
        {
            return loggedInUser == null;
        }
    }
}
