using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Enums
{
        [ReferenceList("sheshapromaxx.vms", "OrderType")]
        public enum RefListOrderType : long
        {
            /// <summary>
            /// Purchase order for goods
            /// </summary>
            [Description("Manual")]
            Purchase = 1,

            /// <summary>
            /// Service order for services
            /// </summary>
            [Description("Agent")]
            Service = 2,
    }
    
}
