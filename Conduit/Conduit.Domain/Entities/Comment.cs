using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Conduit.Domain.Entities
{
    public class Comment (Guid userId, Guid articleId, string body)
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } = userId;
        public User Author { get; set; }
        public Guid ArticleId { get; set; } = articleId;
        public Article Article { get; set; }
        public required string Body { get; set; } = body;
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}
