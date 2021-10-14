namespace DotNetCoreOrders
{
    public class CSVOrderDataProvider : IOrderDataProvider
    {
        public string[] Read(string fullPath)
        {
            string[] lines = System.IO.File.ReadAllLines(fullPath);

            return lines; 
        }
    }
}
