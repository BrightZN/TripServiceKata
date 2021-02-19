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
                bool isFriend = false;

                foreach (var friend in user.Friends)
                {
                    if (friend.Equals(loggedInUser))
                    {
                        isFriend = true;
                        break;
                    }
                }

                return isFriend 
                    ? FindTripsBy(user) 
                    : new List<Trip>();
            }
        }

        protected virtual List<Trip> FindTripsBy(User user) => TripDao.FindTripsByUser(user);

        protected virtual User GetLoggedInUser() => UserSession.Instance.GetLoggedUser();
    }
}
