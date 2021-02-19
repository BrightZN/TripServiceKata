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
            var sut = new TripService(new TestTripDao());

            var userBeingViewed = new User();

            Assert.Throws<UserNotLoggedInException>(() => sut.GetTripsByUser(userBeingViewed, null));
        }

        [Fact]
        public void GetTripsByUser_ViewerNotFriendsWithUserBeingViewed_ReturnsEmptyTripList()
        {
            var loggedInUser = new User();

            var sut = new TripService(new TestTripDao());

            var userBeingViewed = new User 
            { 
                Trips = new List<Trip> 
                { 
                    new Trip(),
                    new Trip(),
                    new Trip()
                } 
            };

            var trips = sut.GetTripsByUser(userBeingViewed, loggedInUser);

            Assert.Empty(trips);
        }

        [Fact]
        public void GetTripsByUser_ViewerFriendsWithUserBeingViewed_ReturnsTripList()
        {
            var loggedInUser = new User();

            var sut = new TripService(new TestTripDao());

            var userBeingViewed = new User
            {
                Friends = new List<User>
                {
                    loggedInUser
                },
                Trips = new List<Trip>
                {
                    new Trip(),
                    new Trip(),
                    new Trip()
                }
            };

            var trips = sut.GetTripsByUser(userBeingViewed, loggedInUser);

            Assert.Equal(userBeingViewed.Trips, trips);
        }

        class TestTripDao : ITripDao
        {
            public List<Trip> FindTripsBy(User user) => user.Trips;
        }
    }
}
