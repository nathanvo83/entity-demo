using System;
using System.Collections.Generic;

#nullable disable

namespace entity.data.Entity
{
    public partial class User : EntityBase
    {
        public User()
        {
            Jobs = new HashSet<Job>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public string ObjectId { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
