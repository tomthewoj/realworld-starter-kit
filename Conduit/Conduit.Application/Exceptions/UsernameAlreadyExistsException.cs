using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Application.Exceptions
{
    internal class UsernameAlreadyExistsException : Exception
    {
        public string Username { get;}

        public UsernameAlreadyExistsException(string username) : base($"The \"{username}\" username is already taken.")
        {
            Username = username;
        }
    }
}
