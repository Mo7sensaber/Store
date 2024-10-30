using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities.Order
{
    public class DelevaryMethod : BaseEntity<int>
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public TimeSpan? DelevaryTime { get; set; } = TimeSpan.Zero;  // أو DateTime إذا كنت تقصد تاريخ ووقت
        public decimal Cost { get; set; }
    }

}
