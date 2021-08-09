using System;

namespace GameCatalogApi.Controllers.Exceptions
{
    public class EmptyFieldsException : Exception
    {
        public EmptyFieldsException() : base("Empty Fields")
        {

        }

    }
}