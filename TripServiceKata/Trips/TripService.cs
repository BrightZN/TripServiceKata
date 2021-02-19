using System.Collections.Generic;
using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips
{
    public sealed class TripService
    {
        private readonly ITripDao _tripDao;

        public TripService(ITripDao tripDao)
        {
            _tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User user, User loggedInUser)
        {
            if (loggedInUser == null)
                throw new UserNotLoggedInException();

            return user.FriendsWith(loggedInUser) 
                ? FindTripsBy(user) 
                : NoTrips();
        }

        private static List<Trip> NoTrips() => new List<Trip>();

        private List<Trip> FindTripsBy(User user) => _tripDao.FindTripsBy(user);
    }
}
