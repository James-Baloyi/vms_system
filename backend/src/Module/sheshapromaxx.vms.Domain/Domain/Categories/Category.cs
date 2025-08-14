using Shesha.Domain.Attributes;
using sheshapromaxx.vms.Domain.Commoditys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace sheshapromaxx.vms.Domain.Domain.Categories
{
    [Discriminator]
    public class Category: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Name of the category
        /// </summary>
        [Display(Name = "Category Name")]
        [Description("Name of the category")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Description of the category
        /// </summary>
        [Display(Name = "Description")]
        [Description("Description of the category")]
        public virtual string Description { get; set; }

        [Display(Name = "Commodities")]
        [Description("List  of the commodities")]
        public virtual CommodityCategoryBridge? CommodityCategory { get; set; }

     

    }
}
