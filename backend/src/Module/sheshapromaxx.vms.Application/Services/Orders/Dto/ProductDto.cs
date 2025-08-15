using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Common.Services.Farmers.Dto
{
    public class ProductDto_ 
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string CategoryName { get; set; }
    }
}
