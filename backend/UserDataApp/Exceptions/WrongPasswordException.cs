using System;

namespace UserDataApp.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base("Wrong password.")
        {

        }
    }
}