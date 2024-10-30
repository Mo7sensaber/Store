using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class CustmerBusket
    {
        public string Id { get; set; }
        public IEnumerable<BaskitItem> Items { get; set; }
        public int DelivaryMethodId {  get; set; }
        public string PaymentIntentId { get; set; }
        public string ClientSecret { get; set; }

    }
}
