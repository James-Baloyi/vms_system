using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using sheshapromaxx.vms.Domain.Domain.Programs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.Suppliers
{
    [Discriminator]
    public class SupplierProgramBridge : FullAuditedEntity<Guid>
    {

        /// <summary>
        /// Navigation property to Supplier
        /// </summary>
        public virtual Supplier? Supplier { get; set; }

        /// <summary>
        /// Navigation property to Program
        /// </summary>
        public virtual Program? Program { get; set; }
    }
}
