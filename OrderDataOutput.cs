using DotNetCoreOrders.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DotNetCoreOrders
{
    public class XMLOrderDataOutput : IOrderDataOutput
    {
        public void Output(IEnumerable<Order> orders)
        {
            XElement output = new XElement("Orders",
                from order in orders
                select new XElement("Order",
                    new XAttribute("OrderNo", order.OrderNo),
                    new XAttribute("Address1", order.Address1),
                    new XAttribute("Address2", order.Address2),
                    new XAttribute("City", order.City),
                    new XAttribute("State", order.State),
                    new XElement("TotalValue", order.TotalValue), 
                    new XElement("TotalWeight", order.TotalWeight),
                    new XElement("Consignments",
                        from consignment in order.Consignments 
                        select new XElement("Consignment", new XAttribute("ConsignmentNo", consignment.ConsignmentNo), new XAttribute("Consignee", consignment.ConsigneeName),
                            new XElement("Parcels", 
                            from parcel in consignment.Parcels
                            select new XElement("Parcel", new XAttribute("ParcelCode", parcel.ParcelCode), 
                            from parcelItem in parcel.ParcelItems
                            select new XElement("Parceltem", new XAttribute("Description", parcelItem.ItemDescription),
                            new XAttribute("Currency", parcelItem.ItemCurrency),
                            new XAttribute("Quantity", parcelItem.ItemQuantity),
                            new XAttribute("Value", parcelItem.ItemValue)))))))
            );

            // TODO - add to config
            output.Save("orders.xml");        
        }
    }
}
