using System;

namespace UserDataApp.Exceptions
{
    public class UserAlredyExistException : Exception
    {
        public UserAlredyExistException() : base("User with the same email already exists.")
        {

        }
    }
}