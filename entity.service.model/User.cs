using System;
using System.Collections.Generic;
using System.Text;

namespace entity.service.model
{
    public class User : ModelBase
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public string ObjectId { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
