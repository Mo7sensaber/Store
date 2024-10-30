using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities.Order
{
    public class OrderItems:BaseEntity<int>
    {
        public OrderItems()
        {
        }

        public OrderItems(ProductItemOrder Product, decimal Price, int Quantity)
        {
            product = Product;
            price = Price;
            quantity = Quantity;
        }

        public ProductItemOrder product {  get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
