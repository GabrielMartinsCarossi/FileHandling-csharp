using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace FileHandling
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qnt { get; set; }

        public Product(string name, double price, int qnt)
        {
            Name = name;
            Price = price;
            Qnt = qnt;
        }

        public double Total()
        {
            return Price * Qnt;
        }

        public override string ToString()
        {
            return "Name,"+ Total().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
