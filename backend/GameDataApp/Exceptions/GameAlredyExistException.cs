using System;

namespace GameDataApp.Exceptions
{
    public class GameAlreadyExistException : Exception
    {
        public GameAlreadyExistException() : base("Game with the same Name, from the same Publisher and from the same Year already exists .")
        {

        }
    }
}