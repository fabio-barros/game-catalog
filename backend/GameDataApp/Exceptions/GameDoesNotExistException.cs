using System;

namespace GameDataApp.Exceptions
{
    public class GameDoesNotExistException : Exception
    {
        public GameDoesNotExistException() : base("Game Does not Exist.")
        {

        }
    }
}