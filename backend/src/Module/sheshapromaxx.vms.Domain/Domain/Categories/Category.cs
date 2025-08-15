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


        [Display(Name = "Commodity Id")]
        public virtual Commodity? Commodity { get; set; }

        /*[Display(Name = "Commodities")]
        [Description("List  of the commodities")]
        public virtual CommodityCategoryBridge? CommodityCategory { get; set; }*/

        /// <summary>
        /// Navigation property to commodity-category relationships
        /// </summary>
       /* [Display(Name = "Commodity Category Links")]
        [Description("Bridge relationships linking this category to commodities")]
        public virtual ICollection<CommodityCategoryBridge>? CommodityCategoryBridges { get; set; }

        /// <summary>
        /// Helper property to get all commodities in this category
        /// </summary>
        [Display(Name = "Commodities")]
        [Description("All commodities that belong to this category")]
        public IEnumerable<Commodity> Commodities => CommodityCategoryBridges?.Select(cb => cb.Commodity) ?? new List<Commodity>();*/



    }
}
