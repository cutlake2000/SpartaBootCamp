using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Shopper
    {
        public List<Product> products = new List<Product>();

        public Shopper()
        {
            InventoryInit();
        }

        void InventoryInit()
        {
            products.Add(
                new Product(false, "수련자 갑옷", Item.StatOption.DEF, 5, "수련에 도움이 되는 갑옷입니다.", 1000)
            );
            products.Add(
                new Product(false, "무쇠갑옷", Item.StatOption.DEF, 9, "무쇠로 만들어져 튼튼한 갑옷입니다. ", 1800)
            );
            products.Add(
                new Product(
                    false,
                    "스파르타의 갑옷",
                    Item.StatOption.DEF,
                    15,
                    "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                    3500
                )
            );
            products.Add(
                new Product(false, "낡은 검", Item.StatOption.ATK, 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600)
            );
            products.Add(
                new Product(false, "청동 도끼", Item.StatOption.ATK, 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500)
            );
            products.Add(
                new Product(
                    false,
                    "스파르타의 창",
                    Item.StatOption.ATK,
                    7,
                    "스파르타의 전사들이 사용했다는 전설의 창입니다.",
                    2500
                )
            );
        }
    }
}
