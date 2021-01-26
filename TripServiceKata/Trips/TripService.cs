using System.Collections.Generic;
using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips
{
    public class TripService
    {
        private readonly ITripDao _tripDao;

        public TripService(ITripDao tripDao)
        {
            _tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User user, User loggedInUser)
        {
            if (No(loggedInUser))
                throw new UserNotLoggedInException();

            return user.FriendsWith(loggedInUser) 
                ? TripsFor(user) 
                : NoTrips();
        }

        private List<Trip> TripsFor(User user)
        {
            return _tripDao.FindTripsFor(user);
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
