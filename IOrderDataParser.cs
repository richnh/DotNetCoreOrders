using DotNetCoreOrders.Models;
using System.Collections.Generic;

namespace DotNetCoreOrders
{
    public interface IOrderDataParser
    {
        public IEnumerable<Order> Parse(string[] lines);
    }
}
