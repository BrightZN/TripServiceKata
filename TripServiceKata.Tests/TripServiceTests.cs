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
            var sut = new TripService();

            var someUser = new User();

            Assert.Throws<UserNotLoggedInException>(() => sut.GetTripsByUser(someUser));
        }
    }
}
