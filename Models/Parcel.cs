using System.Collections.Generic;

namespace DotNetCoreOrders.Models
{
    public class Parcel
    {
        public Parcel()
        {
            ParcelItems = new List<ParcelItem>();
        }

        internal string ParcelCode { get; set; }

        internal IList<ParcelItem> ParcelItems { get; set; }
    }
}
