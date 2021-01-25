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

            var sut = new TestableTripService(guestUser);

            var someUser = new User();

            Assert.Throws<UserNotLoggedInException>(() => sut.GetTripsByUser(someUser));
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

            var sut = new TestableTripService(loggedInUser);

            var trips = sut.GetTripsByUser(someUser);

            Assert.Empty(trips);
        }

        internal class TestableTripService : TripService
        {
            private readonly User _loggedInUser;

            public TestableTripService(User loggedInUser)
            {
                _loggedInUser = loggedInUser;
            }

            protected override User GetLoggedInUser()
            {
                return _loggedInUser;
            }
        }
    }
}
