using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Domain.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
  
        public Guid UserId { get; set; } //funkcjonuj bez usera, softdelete
        public required User Author { get; set; }

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // czy komentarze zostają?
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

        public string Title { get; set; } = default!;
        public string Slug { get; set; } = default!; 
        public string Description { get; set; } = default!;
        public string? Body { get; set; }

        public required DateTime CreatedAt { get; set; } //zmień aby nie było seta po stworzeniu
        public required DateTime UpdatedAt { get; set; }
    }
}
