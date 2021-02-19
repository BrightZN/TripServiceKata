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

        class TestableTripService : TripService
        {
            private readonly User _loggedInUser;

            public TestableTripService(User loggedInUser)
            {
                _loggedInUser = loggedInUser;
            }

            protected override User GetLoggedInUser() => _loggedInUser;
        }
    }
}
