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
        public void GetTripsByUser_ViewerNotLoggedIn_ThrowsException()
        {
            var sut = new TestableTripService(null);

            var userBeingViewed = new User();

            Assert.Throws<UserNotLoggedInException>(() => sut.GetTripsByUser(userBeingViewed));
        }

        [Fact]
        public void GetTripsByUser_ViewerNotFriendsWithUserBeingViewed_ReturnsEmptyTripList()
        {
            var loggedInUser = new User();

            var sut = new TestableTripService(loggedInUser);

            var userBeingViewed = new User 
            { 
                Trips = new List<Trip> 
                { 
                    new Trip(),
                    new Trip(),
                    new Trip()
                } 
            };

            var trips = sut.GetTripsByUser(userBeingViewed);

            Assert.Empty(trips);
        }

        class TestableTripService : TripService
        {
            private readonly User _loggedInUser;

            public TestableTripService(User loggedInUser) => _loggedInUser = loggedInUser;

            protected override User GetLoggedInUser() => _loggedInUser;
        }
    }
}
