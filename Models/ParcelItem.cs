
namespace DotNetCoreOrders.Models
{
    public class ParcelItem
    {
        internal string OrderNo { get; set; }

        internal string ConsignmentNo { get; set; }

        internal string ParcelCode { get; set; }

        internal string ConsigneeName { get; set; }

        internal string Address1 { get; set; }

        internal string Address2 { get; set; }

        internal string City { get; set; }

        internal string State { get; set; }

        internal string CountryCode { get; set; } = "GB";

        internal int ItemQuantity { get; set; }

        internal decimal ItemValue { get; set; }

        internal double ItemWeight { get; set; }

        internal string ItemDescription { get; set; }

        internal string ItemCurrency { get; set; } = "GBP";
    }
}
