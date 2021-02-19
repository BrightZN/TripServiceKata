using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripServiceKata.Trips;

namespace TripServiceKata.Users
{
    public class User
    {
        public List<User> Friends { get; } = new List<User>();
        public List<Trip> Trips { get; } = new List<Trip>();

        public bool FriendsWith(User loggedInUser)
        {
            foreach (var friend in this.Friends)
            {
                if (friend.Equals(loggedInUser))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
