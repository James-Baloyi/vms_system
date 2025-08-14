using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using sheshapromaxx.vms.Domain.Commoditys;
using sheshapromaxx.vms.Domain.Farmers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Domain.Domain.FarmInfromation
{

    [Discriminator]
    public class FarmInformation: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Size of the farm in hectares
        /// </summary>
        [Display(Name = "Farm Size")]
        [Description("Size of the farm in hectares")]
        public virtual double FarmSize { get; set; }

        /// <summary>
        /// Navigation property to Commodity
        /// </summary>
        public virtual Commodity? Commodity { get; set; }

        /// <summary>
        /// Production size/volume
        /// </summary>
        [Display(Name = "Production Size")]
        [Description("The production size or volume of the farm")]
        public virtual double ProductionSize { get; set; }

        /// <summary>
        /// Navigation property to Farmer
        /// </summary>
        public virtual Farmer? Farmer { get; set; }
    }
}
