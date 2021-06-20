using System;

namespace GameCatalogApi.Exceptions
{
    public class GameDoesNotExistException : Exception
    {
        public GameDoesNotExistException() : base("Game Does not Exist.")
        {

        }
    }
}