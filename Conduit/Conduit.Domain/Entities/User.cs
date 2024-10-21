
using Microsoft.AspNetCore.Identity;

namespace Conduit.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
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
