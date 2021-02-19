using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripServiceKata.Trips;

namespace TripServiceKata.Users
{
    public class User
    {
        public List<User> Friends { get; set; } = new List<User>();
        public List<Trip> Trips { get; set; } = new List<Trip>();

        internal bool FriendsWith(User loggedInUser)
        {
            foreach (var friend in Friends)
                if (friend.Equals(loggedInUser))
                    return true;

            return false;
        }
    }
}
