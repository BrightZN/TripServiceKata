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

            if (No(loggedInUser))
                throw new UserNotLoggedInException();

            var trips = new List<Trip>();

            if (user.FriendsWith(loggedInUser))
            {
                trips = TripDao.FindTripsByUser(user);
            }

            return trips;
        }

        private static bool No(User loggedInUser)
        {
            return loggedInUser == null;
        }

        protected virtual User GetLoggedInUser()
        {
            return UserSession.Instance.GetLoggedUser();
        }
    }
}
