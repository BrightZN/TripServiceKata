using System.Collections.Generic;
using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            var tripList = new List<Trip>();

            var loggedInUser = GetLoggedInUser();

            bool isFriend = false;

            if (loggedInUser == null)
                throw new UserNotLoggedInException();

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
                tripList = TripDao.FindTripsByUser(user);
            }

            return tripList;
        }

        protected virtual User GetLoggedInUser()
        {
            return UserSession.Instance.GetLoggedUser();
        }
    }
}
