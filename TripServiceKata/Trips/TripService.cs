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

            bool isFriend = false;

            if (No(loggedInUser))
                throw new UserNotLoggedInException();

            var trips = new List<Trip>();

            foreach (User friend in user.Friends)
            {
                if (friend.Equals(loggedInUser))
                {
                    isFriend = true;
                    break;
                }
            }

            if (isFriend)
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
