using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Application.Entities
{
    public class Tag (string name)
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = name;
        public  ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
