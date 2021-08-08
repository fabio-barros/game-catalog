using System;

namespace UserDataApp.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException() : base("User not found.")
        {

        }
    }
}