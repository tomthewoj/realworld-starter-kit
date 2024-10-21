using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Domain.Entities
{
    public class Favorite (Guid userId, Guid articleId)
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } = userId;
        public User User { get; set; }
        public Guid ArticleId { get; set; } = articleId;
        public Article Article { get; set; } //używa konwencji

    }
}
