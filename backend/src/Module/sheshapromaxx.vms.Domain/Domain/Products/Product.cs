using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sheshapromaxx.vms.Domain.Domain.Categories;

namespace sheshapromaxx.vms.Domain.Domain.Products
{
    [Discriminator]
    public class Product : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Name of the product
        /// </summary>
        [Display(Name = "Product Name")]
        [Description("Name of the product")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        [Display(Name = "Price")]
        [Description("Price of the product")]
        public virtual double? Price { get; set; }

        /// <summary>
        /// Navigation property to Category
        /// </summary>
        public virtual Category? Category { get; set; }
    }
}
