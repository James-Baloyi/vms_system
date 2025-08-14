using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Programs
{
    [Discriminator]
    public class Program: FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ProgramBridge? ProgramBridge { get; set; }

    }
}
