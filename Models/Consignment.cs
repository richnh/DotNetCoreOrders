using System.Collections.Generic;

namespace DotNetCoreOrders.Models
{
    public class Consignment
    {
        public Consignment()
        {
            Parcels = new List<Parcel>();
        }

        public string ConsignmentNo { get; set; }

        public string ConsigneeName { get; set; }

        public IList<Parcel> Parcels { get; set; }
    }
}
