using System.Collections.Generic;
using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            var loggedInUser = GetLoggedInUser();

            if (loggedInUser == null)
                throw new UserNotLoggedInException();
            else
                return user.FriendsWith(loggedInUser)
                    ? FindTripsBy(user)
                    : NoTrips();
        }

        private static List<Trip> NoTrips() => new List<Trip>();

        protected virtual List<Trip> FindTripsBy(User user) => TripDao.FindTripsByUser(user);

        protected virtual User GetLoggedInUser() => UserSession.Instance.GetLoggedUser();
    }
}
