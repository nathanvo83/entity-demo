using System;
using System.Collections.Generic;
using System.Text;

namespace entity.service.model
{
    public class Job : ModelBase
    {
        public Guid Id { get; set; }
        public string JobName { get; set; }
        public bool? IsCompleted { get; set; }
        public Guid? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
