using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities.Order
{
    public enum OrderStatus
    {
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "peyment received")]
        PeymentReceived,
        [EnumMember(Value = "peyment failed")]
        PeymentFailed,
    }
}
