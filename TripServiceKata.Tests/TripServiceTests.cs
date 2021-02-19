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
        public void GetTripsByUser_LoggedOutUserViewingNonFriend_ThrowsException()
        {
            User loggedOutUser = null;
            
            var sut = new TestableTripService();

            var userBeingViewed = new User();

            Assert.Throws<UserNotLoggedInException>(() => sut.GetTripsByUser(userBeingViewed, loggedOutUser));
        }

        [Fact]
        public void GetTripsByUser_LoggedInUserViewingNonFriend_ReturnsEmptyTripList()
        {
            var loggedInUser = new User();
            
            var sut = new TestableTripService();

            var userBeingViewed = new User
            {
                Friends =
                {
                    new User()
                },
                Trips =
                {
                    new Trip(),
                    new Trip()
                }
            };

            var trips = sut.GetTripsByUser(userBeingViewed, loggedInUser);
            
            Assert.Empty(trips);
        }

        [Fact]
        public void GetTripsByUser_LoggedInUserViewingFriend_ReturnsTripListWithTrips()
        {
            var loggedInUser = new User();
            
            var sut = new TestableTripService();

            var userBeingViewed = new User
            {
                Friends =
                {
                    new User(),
                    loggedInUser
                },
                Trips =
                {
                    new Trip(),
                    new Trip()
                }
            };

            var trips = sut.GetTripsByUser(userBeingViewed, loggedInUser);
            
            Assert.Equal(userBeingViewed.Trips, trips);
        }
    }

    public class TestableTripService : TripService
    {
        protected override List<Trip> FindTripsBy(User user) => user.Trips;
    }
}
