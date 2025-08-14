using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using sheshapromaxx.vms.Domain.Commoditys;
using sheshapromaxx.vms.Domain.Domain.Applications;
using sheshapromaxx.vms.Domain.Domain.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Programs
{

    [Discriminator]
    public class ProgramBridge : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Navigation property to Commodity
        /// </summary>
        public virtual Program? Program { get; set; }

        /// <summary>
        /// Navigation property to Category
        /// </summary>
        public virtual Application? Application { get; set; }

    }
}

