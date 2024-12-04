using CrazyElephant.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrazyElephant.Service
{
    internal class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {
            

            System.IO.File.WriteAllLines(@"D:\dish.txt", dishes.ToArray());

        }
    }
}
