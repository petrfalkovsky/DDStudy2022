using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTimeOffset Created { get; set; }
    }
}
