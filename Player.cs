using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Player
    {
        public List<Inventory> inventories = new List<Inventory>();
        public int level { get; private set; }
        public string job { get; private set; }
        public int attack { get; private set; }
        public int defence { get; private set; }
        public int health { get; private set; }
        public int gold { get; private set; }

        public Player()
        {
            level = 1;
            job = "전사";
            attack = 10;
            defence = 5;
            health = 100;
            gold = 1500;

            InventoryInit();

            AddStatFromEquipment();
        }

        void AddStatFromEquipment()
        {
            for (int i = 0; i < inventories.Count(); i++)
            {
                if (inventories[i].isEquiped == true)
                {
                    if (inventories[i].statPoint1 != 0)
                    {
                        attack += inventories[i].statPoint1;
                    }
                    if (inventories[i].statPoint2 != 0)
                    {
                        defence += inventories[i].statPoint2;
                    }
                    if (inventories[i].statPoint3 != 0)
                    {
                        health += inventories[i].statPoint3;
                    }
                }
            }
        }

        void InventoryInit()
        {
            inventories.Add(
                new Inventory(
                    false,
                    "낡은 검",
                    Inventory.StatOption.ATK,
                    2,
                    Inventory.StatOption.DEF,
                    0,
                    Inventory.StatOption.HP,
                    0,
                    "쉽게 볼 수 있는 낡은 검입니다."
                )
            );

            inventories.Add(
                new Inventory(
                    true,
                    "무쇠 갑옷",
                    Inventory.StatOption.ATK,
                    0,
                    Inventory.StatOption.DEF,
                    5,
                    Inventory.StatOption.HP,
                    0,
                    "무쇠로 만들어져 튼튼한 갑옷입니다."
                )
            );
        }
    }
}
