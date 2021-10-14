
namespace DotNetCoreOrders.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDataProvider _provider;

        private readonly IOrderDataParser _parser;

        private readonly IOrderDataOutput _output;

        public OrderService(
            IOrderDataProvider provider, 
            IOrderDataParser parser, 
            IOrderDataOutput output)
        {
            _provider   = provider;
            _parser     = parser;
            _output     = output;
        }

        public void Process()
        {
            // TODO : add file location to config
            string [] orderLines = _provider.Read("Data//orders.csv");

            var parcelItems = _parser.Parse(orderLines);

            _output.Output(parcelItems);
        }
    }
}
