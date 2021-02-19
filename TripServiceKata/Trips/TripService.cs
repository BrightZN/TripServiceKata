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

            return user.FriendsWith(loggedInUser) 
                ? TripDao.FindTripsByUser(user) 
                : new List<Trip>();
        }

        protected virtual User GetLoggedInUser()
        {
            return UserSession.Instance.GetLoggedUser();
        }
    }
}
