using DotNetCoreOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreOrders
{
    public class CSVOrderDataParser : IOrderDataParser
    {
        private readonly int _offset;

        public CSVOrderDataParser(bool hasHeader)
        {
            _offset = hasHeader ? 1 : 0; ;
        }

        public IEnumerable<Order> Parse(string[] lines)
        {
            var parcels = new List<Parcel>();

            var consignments = new List<Consignment>();

            var orders = new List<Order>();

            foreach (string line in lines.Skip(_offset))
            {
                string[] orderItem 
                    = line.Split(new string[] { "," }, StringSplitOptions.None);

                var itemEntry
                    = new ParcelItem()
                    {
                        OrderNo = orderItem[0],
                        ConsignmentNo = orderItem[1],
                        ParcelCode = orderItem[2],
                        ConsigneeName = orderItem[3],
                        Address1 = orderItem[4],
                        Address2 = orderItem[5],
                        City = orderItem[6],
                        State = orderItem[7],
                        CountryCode = orderItem[8],
                        ItemQuantity = Convert.ToInt32(orderItem[9]),
                        ItemValue = Convert.ToDecimal(orderItem[10]),
                        ItemWeight = Convert.ToDouble(orderItem[11]),
                        ItemDescription = orderItem[12],
                        ItemCurrency = orderItem[13] == string.Empty ? "GBP" : orderItem[13],
                    };

                var parcel = parcels.Find(x => x.ParcelCode == itemEntry.ParcelCode);
                if (parcel == null)
                {
                    parcel = new Parcel()
                    {
                        ParcelCode = itemEntry.ParcelCode
                    };

                    parcels.Add(parcel);
                }

                var consignment = consignments.Find(x => x.ConsignmentNo == itemEntry.ConsignmentNo);
                if (consignment == null)
                {
                    consignment = new Consignment()
                    {
                        ConsignmentNo = itemEntry.ConsignmentNo,
                        ConsigneeName = itemEntry.ConsigneeName
                    };

                    consignments.Add(consignment);
                }

                var order = orders.Find(x => x.OrderNo == itemEntry.OrderNo);
                if (order == null)
                {
                    order = new Order()
                    {
                        OrderNo     = itemEntry.OrderNo,
                        Address1    = itemEntry.Address1,
                        Address2    = itemEntry.Address2,
                        City        = itemEntry.City,
                        State       = itemEntry.State,
                        CountryCode = itemEntry.CountryCode
                    };
                    orders.Add(order);
                }

                order.TotalValue += itemEntry.ItemValue;
                order.TotalWeight += itemEntry.ItemWeight;

                parcel.ParcelItems.Add(itemEntry);
                consignment.Parcels.Add(parcel);
                order.Consignments.Add(consignment);
            }

            return orders;
        }       
    }
}
