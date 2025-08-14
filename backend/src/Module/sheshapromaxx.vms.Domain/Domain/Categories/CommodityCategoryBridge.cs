using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using sheshapromaxx.vms.Domain.Commoditys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Categories
{

    [Discriminator]
    public class CommodityCategoryBridge: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Navigation property to Commodity
        /// </summary>
        public virtual Commodity? Commodity { get; set; }

        /// <summary>
        /// Navigation property to Category
        /// </summary>
        public virtual Category? Category { get; set; }

    }
}

