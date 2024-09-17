using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Application.Exceptions
{
    internal class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException(string email) : base($"\"{email}\" is already taken.")
        {
            Email = email;
        }

        string Email { get; }

    }
}
