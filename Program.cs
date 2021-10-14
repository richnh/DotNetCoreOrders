using DotNetCoreOrders.Service;
using System;

namespace DotNetCoreOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Order CSV -> XML Output Application");

            OrderService service =
                new OrderService(new CSVOrderDataProvider(),
                    new CSVOrderDataParser(true),
                    new XMLOrderDataOutput());

            service.Process();

            Console.WriteLine("XML Output Generated Successfully ...");
        }
    }
}
