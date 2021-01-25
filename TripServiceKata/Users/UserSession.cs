﻿using System;
using System.Collections.Generic;
using System.Text;
using TripServiceKata.Exceptions;

namespace TripServiceKata.Users
{
    public class UserSession
    {
        private UserSession() { }

        public static UserSession Instance { get; } = new UserSession();

        public bool IsUserLoggedIn(User _)
        {
            throw new DependentClassCallException(
                "UserSession.IsUserLoggedIn() should not be called in an unit test");
        }

        public User GetLoggedUser()
        {
            throw new DependentClassCallException(
                "UserSession.GetLoggedUser() should not be called in an unit test");
        }
    }
}
