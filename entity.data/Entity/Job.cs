using System;
using System.Collections.Generic;

#nullable disable

namespace entity.data.Entity
{
    public partial class Job : EntityBase
    {
        public Guid Id { get; set; }
        public string JobName { get; set; }
        public bool? IsCompleted { get; set; }
        public Guid? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
