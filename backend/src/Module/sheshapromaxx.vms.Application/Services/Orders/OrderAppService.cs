using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using sheshapromaxx.vms.Common.Services.Farmers.Dto;
using sheshapromaxx.vms.Domain.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheshapromaxx.vms.Common.Services.Orders
{
    public class OrderAppService : SheshaAppServiceBase
    {
        private readonly IRepository<Order, Guid> _orderRepository;
        public OrderAppService(IRepository<Order, Guid> orderRepository)
        {

            _orderRepository = orderRepository;

        }

        [HttpGet("order/getProductsByOrderRef")]
        public async Task<List<ProductDto_>> GetProductsByOrderRefAsync(string orderRef)
        {
            if (string.IsNullOrWhiteSpace(orderRef))
            {
                throw new Abp.UI.UserFriendlyException("Order reference is required");
            }

            // Get all orders with the given orderRef and include Product details
            var orders = await _orderRepository.GetAllListAsync(
                o => o.OrderRef == orderRef && o.Product != null && !o.IsDeleted
            );

            if (!orders.Any())
            {
                return new List<ProductDto_>(); // Return empty list if no orders found
            }

            // Extract products from orders and convert to DTO
            var products = orders
                .Where(o => o.Product != null)
                .Select(o => new ProductDto_
                {
                    ProductId = o.Product.Id,
                    Name = o.Product.Name,
                    Price = o.Product.Price,
                    CategoryName = o.Product.Category?.Name
                })
                .Distinct() // Remove duplicates if same product appears in multiple orders
                .ToList();

            return products;
        }
    }

}
