using System;

namespace Northwind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo employeeFetcher = new Demo();
            employeeFetcher.GetCustomerByID();
            //employeeFetcher.FetchCustomers();
            
        }
    }
}
