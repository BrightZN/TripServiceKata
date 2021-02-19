using TripServiceKata.Exceptions;
using TripServiceKata.Trips;
using TripServiceKata.Users;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceTests
    {
        [Fact]
        public void GetTripsByUser_ViewingAsLoggedOutUser_ThrowsException()
        {
            User loggedOutUser = null;
            
            var sut = new TestableTripService(loggedOutUser);

            var userBeingViewed = new User();

            Assert.Throws<UserNotLoggedInException>(() => sut.GetTripsByUser(userBeingViewed));
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
