using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using sheshapromaxx.vms.Domain.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shesha.Domain;
using sheshapromaxx.vms.Domain.Domain.Products;
using sheshapromaxx.vms.Domain.Domain.Vouchers;

namespace sheshapromaxx.vms.Domain.Domain.Orders
{
    [Discriminator]
    public class Order : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Type of the order
        /// </summary>
        [Display(Name = "Order Type")]
        [Description("Type of the order (Purchase, Service, etc.)")]
        [ReferenceList("sheshapromaxx.vms", "OrderType")]
        public virtual RefListOrderType? OrderType { get; set; }


        /// <summary>
        /// Navigation property to Product
        /// </summary>
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        /// <summary>
        /// Navigation property to Voucher
        /// </summary>
        [ForeignKey("VoucherId")]
        public virtual Voucher? Voucher { get; set; }

        /// <summary>
        /// Cost of the order
        /// </summary>
        [Display(Name = "Cost")]
        [Description("Total cost of the order")]
        public virtual double? Cost { get; set; }

        /// <summary>
        /// Foreign key to Implementor (Person)
        /// </summary>
        [Display(Name = "Implementor")]
        [Description("Person responsible for implementing this order")]
        public virtual Person? Implementor { get; set; }


        /// <summary>
        /// Date and time when the order was created
        /// </summary>
        [Display(Name = "Created At")]
        [Description("Date and time when the order was created")]
        public virtual DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Delivery date for the order
        /// </summary>
        [Display(Name = "Delivery Date")]
        [Description("Expected or actual delivery date")]
        public virtual DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Current tracking status of the order
        /// </summary>
        [Display(Name = "Track Status")]
        [Description("Current tracking status of the order")]
        [ReferenceList("sheshapromaxx.vms", "TrackStatus")]
        public virtual RefListTrackStatus? TrackStatus { get; set; }

        /// <summary>
        /// Order reference number
        /// </summary>
        [Display(Name = "Order Reference")]
        [Description("Unique reference number for the order")]
        public virtual string OrderRef { get; set; }

        /// <summary>
        /// Delivery notes and instructions
        /// </summary>
        [Display(Name = "Delivery Notes")]
        [Description("Special notes and instructions for delivery")]
        public virtual string DeliveryNotes { get; set; }

        public virtual int Quantity { get; set; }
    }
}
