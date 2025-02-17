﻿using System.Runtime.Serialization;

namespace MovieBookingBackend.Exceptions.Auth
{
    [Serializable]
    internal class UnableToRegisterException : Exception
    {
        public UnableToRegisterException()
        {
        }

        public UnableToRegisterException(string? message) : base(message)
        {
        }

        public UnableToRegisterException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToRegisterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}