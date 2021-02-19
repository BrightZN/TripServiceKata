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
            
            var isFriend = false;
            
            foreach (var friend in user.Friends)
            {
                if (friend.Equals(loggedInUser))
                {
                    isFriend = true;
                    break;
                }
            }

            var tripList = new List<Trip>();
            
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
