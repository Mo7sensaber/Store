using StackExchange.Redis;
using Store.Core.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications.OrdersSpes
{
    public class OrderSpecefication:BaseSpecifications<Orders,int>
    {
        public OrderSpecefication(string buyerEmail,int orderId):base(O=>O.BuyerEmail==buyerEmail&&O.Id==orderId)
        {
            Include.Add(O => O.DeliveryMethod);
            Include.Add(O => O.Items);
        }
        public OrderSpecefication(string buyerEmail) : base(O => O.BuyerEmail == buyerEmail )
        {
            Include.Add(O => O.DeliveryMethod);
            Include.Add(O => O.Items);
        }
    }
}
