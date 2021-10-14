using DotNetCoreOrders.Models;
using System.Collections.Generic;

namespace DotNetCoreOrders
{
    public interface IOrderDataOutput
    {
        public void Output(IEnumerable<Order> orders);
    }
}
