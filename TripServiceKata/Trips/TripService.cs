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
            {

                return FriendsWith(user, loggedInUser) 
                    ? FindTripsBy(user)
                    : new List<Trip>();
            }
        }

        private static bool FriendsWith(User user, User loggedInUser)
        {

            foreach (var friend in user.Friends)
                if (friend.Equals(loggedInUser))
                    return true;

            return false;
        }

        protected virtual List<Trip> FindTripsBy(User user) => TripDao.FindTripsByUser(user);

        protected virtual User GetLoggedInUser() => UserSession.Instance.GetLoggedUser();
    }
}
