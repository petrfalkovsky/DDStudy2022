﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "empty";
        public string Email { get; set; } = "empty";
        public string PasswordHash { get; set; } = "empty";
        public DateTimeOffset BirthDate { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        public virtual Avatar? Avatar { get; set; }
        public virtual ICollection<UserSession>? Sessions { get; set; }
    }
}
