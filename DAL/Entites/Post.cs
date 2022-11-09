using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Post
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PostPicture>? PostPictures { get; set; }
    }
}
