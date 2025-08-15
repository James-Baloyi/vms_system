using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Enums
{
        [ReferenceList("sheshapromaxx.vms", "TrackStatus")]
    public enum RefListTrackStatus : long
    {
        /// <summary>
        /// Order has been created
        /// </summary>
        [Description("Created")]
        Created = 1,

        /// <summary>
        /// Order is being processed
        /// </summary>
        [Description("Processing")]
        Processing = 2,

        /// <summary>
        /// Order has been confirmed
        /// </summary>
        [Description("Confirmed")]
        Confirmed = 3,

        /// <summary>
        /// Order is being prepared
        /// </summary>
        [Description("Preparing")]
        Preparing = 4,

        /// <summary>
        /// Order is in transit
        /// </summary>
        [Description("In Transit")]
        InTransit = 5,

        /// <summary>
        /// Order is out for delivery
        /// </summary>
        [Description("Out for Delivery")]
        OutForDelivery = 6,

        /// <summary>
        /// Order has been delivered
        /// </summary>
        [Description("Delivered")]
        Delivered = 7,

        /// <summary>
        /// Order has been cancelled
        /// </summary>
        [Description("Cancelled")]
        Cancelled = 8,

        /// <summary>
        /// Order has been returned
        /// </summary>
        [Description("Returned")]
        Returned = 9
    }
    
}
