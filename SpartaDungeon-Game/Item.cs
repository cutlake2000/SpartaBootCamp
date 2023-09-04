using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Item
    {
        public bool isEquiped; // 장착 여부
        public bool isSold; // 판매 여부
        public string name; // 아이템 이름
        public StatOption statClass; // 장비 스탯
        public int statPoint; // 장비 스탯 수치
        public EquipmentType equipmentType; // 장비 타입
        public string description; // 장비 설명
        public int price; // 상품 가격

        public enum StatOption
        {
            ATK,
            DEF,
            HP
        }

        public enum EquipmentType
        {
            Weapon,
            Armor
        }
    }
}
