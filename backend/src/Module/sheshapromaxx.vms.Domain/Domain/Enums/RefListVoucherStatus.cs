using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Enums
{
        [ReferenceList("sheshapromaxx.vms", "VoucherStatus")]
        public enum RefListVoucherStatus : long
        {
            [Description("Active")]
            Active = 1,

            /// <summary>
            /// Voucher has been used
            /// </summary>
            [Description("Used")]
            Used = 2,

            /// <summary>
            /// Voucher has expired
            /// </summary>
            [Description("Expired")]
            Expired = 3,

            /// <summary>
            /// Voucher has been cancelled
            /// </summary>
            [Description("Cancelled")]
            Cancelled = 4,

            /// <summary>
            /// Voucher is suspended temporarily
            /// </summary>
            [Description("Suspended")]
            Suspended = 5,

            /// <summary>
            /// Voucher is pending activation
            /// </summary>
            [Description("Pending")]
            Pending = 6
    }
    
}
