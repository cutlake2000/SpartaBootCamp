using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Product : Item
    {
        public Product(
            bool isSold,
            string name,
            StatOption statClass,
            int statPoint,
            string description,
            int price
        )
        {
            this.isSold = isSold;
            this.name = name;
            this.statClass = statClass;
            this.statPoint = statPoint;
            this.description = description;
            this.price = price;
        }
    }
}
