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

            if (user.FriendsWith(loggedInUser))
                return TripDao.FindTripsByUser(user);

            return new List<Trip>();
        }

        protected virtual User GetLoggedInUser()
        {
            return UserSession.Instance.GetLoggedUser();
        }
    }
}
