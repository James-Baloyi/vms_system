using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Enums
{
        [ReferenceList("sheshapromaxx.vms", "PaymentStatus")]
        public enum RefListPaymentStatus : long
        {
            /// <summary>
            /// Payment is pending
            /// </summary>
            [Description("Pending")]
            Pending = 1,

            /// <summary>
            /// Payment has been processed successfully
            /// </summary>
            [Description("Paid")]
            Paid = 2,

            /// <summary>
            /// Payment has failed
            /// </summary>
            [Description("Failed")]
            Failed = 3,

            /// <summary>
            /// Payment has been refunded
            /// </summary>
            [Description("Refunded")]
            Refunded = 4,

            /// <summary>
            /// Payment is being processed
            /// </summary>
            [Description("Processing")]
            Processing = 5,

            /// <summary>
            /// Payment has been cancelled
            /// </summary>
            [Description("Cancelled")]
            Cancelled = 6
    }
    
}
