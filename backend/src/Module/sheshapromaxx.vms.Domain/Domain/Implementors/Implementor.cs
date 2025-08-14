using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Auditing;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System.ComponentModel;

namespace sheshapromaxx.vms.Domain.Implementors
{
    /// <summary>
    /// Represents an implementor in the system
    /// </summary>
    [Discriminator]
    public class Implementor : Person
    {
        /// <summary>
        /// Service fee charged by the implementor
        /// </summary>
        [Display(Name = "Service Fee")]
        [Description("Service fee charged by the implementor")]
        public virtual decimal ServiceFee { get; set; }
    }
}