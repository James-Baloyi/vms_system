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
using sheshapromaxx.vms.Domain.Domain.Applications;
using Shesha.Domain;
using sheshapromaxx.vms.Domain.Domain.Suppliers;
using sheshapromaxx.vms.Domain.Domain.Orders;

namespace sheshapromaxx.vms.Domain.Domain.Vouchers
{
    [Discriminator]
    public class Voucher : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Unique voucher reference number
        /// </summary>
        [Display(Name = "Voucher Reference")]
        [Description("Unique reference number for the voucher")]
        public virtual string VoucherRef { get; set; }

        /// <summary>
        /// Status of the voucher
        /// </summary>
        [Display(Name = "Status")]
        [Description("Current status of the voucher")]
        [ReferenceList("sheshapromaxx.vms", "VoucherStatus")]
        public virtual RefListVoucherStatus? Status { get; set; }


        /// <summary>
        /// Navigation property to Application
        /// </summary>
        [ForeignKey("ApplicationId")]
        public virtual Application? Application { get; set; }

        /// <summary>
        /// Expiry date of the voucher
        /// </summary>
        [Display(Name = "Expiry Date")]
        [Description("Date when the voucher expires")]
        public virtual DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Total amount of the voucher
        /// </summary>
        [Display(Name = "Amount")]
        [Description("Total amount of the voucher")]
        public virtual double? Amount { get; set; }

        /// <summary>
        /// Payment status of the voucher
        /// </summary>
        [Display(Name = "Payment Status")]
        [Description("Payment status of the voucher")]
        [ReferenceList("sheshapromaxx.vms", "PaymentStatus")]
        public virtual RefListPaymentStatus? PaymentStatusRef { get; set; }

        /// <summary>
        /// Current remaining amount of the voucher
        /// </summary>
        [Display(Name = "Current Amount")]
        [Description("Current remaining amount of the voucher")]
        public virtual double? CurrentAmount { get; set; }

        public virtual bool? IsRedeem { get; set; }


        [Display(Name = "Program Id")]
        public virtual Order? Order { get; set; }

        /// <summary>
        /// Navigation property to voucher-supplier relationships
        /// </summary>
       /* [Display(Name = "Supplier Links")]
        [Description("Bridge relationships linking this voucher to suppliers")]
        public virtual ICollection<VoucherSupplierBridge> VoucherSupplierBridges { get; set; }

        /// <summary>
        /// Helper property to get all suppliers for this voucher
        /// </summary>
        [Display(Name = "Suppliers")]
        [Description("All suppliers associated with this voucher")]
        public IEnumerable<Supplier> Suppliers =>
            VoucherSupplierBridges?.Select(vsb => vsb.Supplier) ?? new List<Supplier>();*/


        /// <summary>
        /// Navigation property to Supplier
        /// </summary>
        /*[ForeignKey("SupplierId")]
        public virtual Supplier? Supplier { get; set; }*/
    }
}
