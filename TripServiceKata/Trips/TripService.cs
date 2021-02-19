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
                ? _tripDao.FindTripsBy(user)
                : NoTrips();
        }

        private static bool No(User loggedInUser) => loggedInUser == null;

        private static List<Trip> NoTrips() => new List<Trip>();
    }
}
