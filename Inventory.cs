using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Inventory : Item
    {
        public Inventory(
            bool isEquiped,
            string name,
            StatOption statClass,
            int statPoint,
            EquipmentType equipmentType,
            string description,
            int price
        )
        {
            this.isEquiped = isEquiped;
            this.name = name;
            this.statClass = statClass;
            this.statPoint = statPoint;
            this.equipmentType = equipmentType;
            this.description = description;
        }
    }
}
