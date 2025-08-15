using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sheshapromaxx.vms.Domain.Domain.Applications;

namespace sheshapromaxx.vms.Domain.Domain.Programs
{
    [Discriminator]
    public class Program: FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        // <summary>
        /// Navigation property to program-application relationships
        /// </summary>
        [Display(Name = "Application Links")]
        [Description("Bridge relationships linking this program to applications")]
        public virtual ICollection<ProgramBridge> ProgramBridges { get; set; }

        /// <summary>
        /// Helper property to get all applications for this program
        /// </summary>
        [Display(Name = "Applications")]
        [Description("All applications associated with this program")]
        public IEnumerable<Application> Applications =>
            ProgramBridges?.Select(pb => pb.Application) ?? new List<Application>();

    }
}
