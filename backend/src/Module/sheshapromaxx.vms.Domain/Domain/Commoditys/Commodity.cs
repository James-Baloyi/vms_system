using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Auditing;
using Shesha.Domain.Attributes;

namespace sheshapromaxx.vms.Domain.Commoditys
{
    /// <summary>
    /// Represents a commodity or product item
    /// </summary>
    [Discriminator]
    public class Commodity : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// The name of the commodity
        /// </summary>
        [Description("The name of the commodity")]
        [Display(Name = "CommodityName")]
        public virtual string CommodityName { get; set; }
    }
}