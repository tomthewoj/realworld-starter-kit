using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Application.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!; //nie zapomnij o enkrypcji
        public string Email { get; set; } = default!;

        [Column(TypeName = "Text")] //EF fluent api
        public string? Bio { get; set; }
        public string? Image { get; set; }

        public DateTime CreatedAt { get; set; }
        public ICollection<Article> Articles { get; set; } = new List<Article>();
        public ICollection<FollowUser> Followers { get; set; } = new List<FollowUser>();
        public ICollection<FollowUser> FollowedUsers { get; set; } = new List<FollowUser>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
