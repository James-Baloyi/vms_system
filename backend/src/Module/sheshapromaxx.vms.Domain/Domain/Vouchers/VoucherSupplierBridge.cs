using Abp.Domain.Entities.Auditing;
using sheshapromaxx.vms.Domain.Domain.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Vouchers
{
    public class VoucherSupplierBridge : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Navigation property to Voucher
        /// </summary>
        [ForeignKey("VoucherId")]
        public virtual Voucher? Voucher { get; set; }

        /// <summary>
        /// Navigation property to Supplier
        /// </summary>
        [ForeignKey("SupplierId")]
        public virtual Supplier? Supplier { get; set; }
    }
}
