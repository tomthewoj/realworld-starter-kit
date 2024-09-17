using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Application.Entities
{
    public class FollowUser ()
    {
        public Guid Id { get; set; }

        public Guid FollowedUserId { get; set; }
        public User FollowedUser { get; set; }

        public Guid FollowerId { get; set; }
        public User Follower { get; set; }
    }
}
