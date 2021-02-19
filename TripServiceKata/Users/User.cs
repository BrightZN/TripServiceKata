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

        public bool FriendsWith(User loggedInUser) => Friends.Any(f => f.Equals(loggedInUser));
    }
}
