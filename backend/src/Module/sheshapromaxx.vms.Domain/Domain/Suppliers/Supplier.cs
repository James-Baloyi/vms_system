using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using sheshapromaxx.vms.Domain.Domain.Programs;
using sheshapromaxx.vms.Domain.Domain.Vouchers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Suppliers
{
    [Discriminator]
    public class Supplier : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Name of the supplier
        /// </summary>
        [Display(Name = "Supplier Name")]
        [Description("Name of the supplier")]
        public virtual string Name { get; set; }

        /// <summary>
        /// GPS coordinates of the supplier location
        /// </summary>
        [Display(Name = "Coordinates")]
        [Description("GPS coordinates of the supplier location")]
        public virtual string Coordinates { get; set; }

        /// <summary>
        /// Physical address of the supplier
        /// </summary>
        [Display(Name = "Address")]
        [Description("Physical address of the supplier")]
        public virtual string Address { get; set; }

        /// <summary>
        /// Phone number of the supplier
        /// </summary>
        [Display(Name = "Phone Number")]
        [Description("Contact phone number of the supplier")]
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// Email address of the supplier
        /// </summary>
        [Display(Name = "Email")]
        [Description("Contact email address of the supplier")]
        public virtual string Email { get; set; }

        /// <summary>
        /// Navigation property to supplier-program relationships
        /// </summary>
        [Display(Name = "Program Links")]
        [Description("Bridge relationships linking this supplier to programs")]
        public virtual ICollection<SupplierProgramBridge> SupplierProgramBridges { get; set; }

        /// <summary>
        /// Helper property to get all programs for this supplier
        /// </summary>
        [Display(Name = "Programs")]
        [Description("All programs associated with this supplier")]
        public IEnumerable<Program> Programs =>
            SupplierProgramBridges?.Select(spb => spb.Program) ?? new List<Program>();

        /// <summary>
        /// Navigation property to voucher-supplier relationships
        /// </summary>
        [Display(Name = "Voucher Links")]
        [Description("Bridge relationships linking this supplier to vouchers")]
        public virtual ICollection<VoucherSupplierBridge>? VoucherSupplierBridges { get; set; }

        /// <summary>
        /// Helper property to get all vouchers for this supplier
        /// </summary>
        [Display(Name = "Vouchers")]
        [Description("All vouchers that can be used at this supplier")]
        public IEnumerable<Voucher> Vouchers =>
            VoucherSupplierBridges?.Select(vsb => vsb.Voucher) ?? new List<Voucher>();



    }
}
