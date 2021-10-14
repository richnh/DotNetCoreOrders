using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreOrders.Models
{
    public class Order
    {
        public Order()
        {
            Consignments = new List<Consignment>();
        }

        internal string OrderNo { get; set; }

        internal IList<Consignment> Consignments { get; set; }

        internal string Address1 { get; set; }

        internal string Address2 { get; set; }

        internal string City { get; set; }

        internal string State { get; set; }

        internal string CountryCode { get; set; } = "GB";

        internal decimal TotalValue { get; set; }

        internal double TotalWeight { get; set; }
    }
}
