using System.Collections.Generic;
using TripServiceKata.Trips;

namespace TripServiceKata.Users
{
    public class User
    {
        public List<User> Friends { get; } = new List<User>();
        public List<Trip> Trips { get; } = new List<Trip>();

        public bool FriendsWith(User loggedInUser) => Friends.Contains(loggedInUser);
    }
}
