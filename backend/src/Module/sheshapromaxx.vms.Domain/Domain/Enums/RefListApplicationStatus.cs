using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Enums
{
        [ReferenceList("sheshapromaxx.vms", "ApplicationStatus")]
        public enum RefListApplicationStatus : long
        {
            /// <summary>
            /// Application is in draft stage
            /// </summary>
            [Description("Draft")]
            Draft = 1,

            /// <summary>
            /// Application has been submitted
            /// </summary>
            [Description("Submitted")]
            Submitted = 2,

            /// <summary>
            /// Application is under review
            /// </summary>
            [Description("Under Review")]
            UnderReview = 3,

            /// <summary>
            /// Application has been approved
            /// </summary>
            [Description("Approved")]
            Approved = 4,

            /// <summary>
            /// Application has been rejected
            /// </summary>
            [Description("Rejected")]
            Rejected = 5,
        }
    
}
