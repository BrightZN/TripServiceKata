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
            
            var sut = new TestableTripService(loggedOutUser);

            var userBeingViewed = new User();

            Assert.Throws<UserNotLoggedInException>(() => sut.GetTripsByUser(userBeingViewed));
        }

        [Fact]
        public void GetTripsByUser_LoggedInUserViewingNonFriend_ReturnsEmptyTripList()
        {
            var loggedInUser = new User();
            
            var sut = new TestableTripService(loggedInUser);

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

            var trips = sut.GetTripsByUser(userBeingViewed);
            
            Assert.Empty(trips);
        }
    }

    public class TestableTripService : TripService
    {
        private readonly User _loggedInUser;

        public TestableTripService(User loggedInUser)
        {
            _loggedInUser = loggedInUser;
        }

        protected override User GetLoggedInUser() => _loggedInUser;
    }
}
