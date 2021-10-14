namespace DotNetCoreOrders
{
    public interface IOrderDataProvider
    {
        public string [] Read(string fullPath);
    }
}
