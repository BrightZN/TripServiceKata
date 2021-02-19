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
                ? FindTripsBy(user) 
                : new List<Trip>();
        }

        protected virtual List<Trip> FindTripsBy(User user)
        {
            return TripDao.FindTripsByUser(user);
        }

        protected virtual User GetLoggedInUser()
        {
            return UserSession.Instance.GetLoggedUser();
        }
    }
}
