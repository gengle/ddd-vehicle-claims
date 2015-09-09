using System;
using System.Runtime.Serialization;

namespace Domain.Shared
{
    [Serializable]
    public class ClaimException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ClaimException()
        {
        }

        public ClaimException(string message) : base(message)
        {
        }

        public ClaimException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ClaimException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}