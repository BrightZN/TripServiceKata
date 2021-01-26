using System.Collections.Generic;
using TripServiceKata.Exceptions;
using TripServiceKata.Trips;
using TripServiceKata.Users;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceTests
    {
        [Fact]
        public void GetTripsByUser_ViewingAsGuestUser_ThrowsException()
        {
            User guestUser = null;

            var sut = new TestableTripService();

            var someUser = new User();

            Assert.Throws<UserNotLoggedInException>(() => sut.GetTripsByUser(someUser, guestUser));
        }

        [Fact]
        public void GetTripsByUser_ViewingNonFriendAsLoggedInUser_ReturnsNoTrips()
        {
            var someUser = new User 
            { 
                Trips = new List<Trip>
                {
                    new Trip()
                }
            };

            var loggedInUser = new User();

            var sut = new TestableTripService();

            var trips = sut.GetTripsByUser(someUser, loggedInUser);

            Assert.Empty(trips);
        }

        [Fact]
        public void GetTripsByUser_ViewingFriendAsLoggedInUser_ReturnsTrips()
        {
            var loggedInUser = new User();

            var friend = new User
            {
                Friends = new List<User>
                {
                    loggedInUser
                },
                Trips = new List<Trip>
                {
                    new Trip(),
                    new Trip()
                }

            };

            var sut = new TestableTripService();

            var trips = sut.GetTripsByUser(friend, loggedInUser);
            
            Assert.NotNull(trips);
        }

        private class TestableTripService : TripService
        {

            protected override List<Trip> TripsBy(User user)
            {
                return user.Trips;
            }
        }
    }
}
