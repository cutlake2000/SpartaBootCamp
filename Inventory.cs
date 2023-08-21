using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Inventory
    {
        public bool isEquiped;
        public string name;
        public StatOption statClass1;
        public int statPoint1;
        public StatOption statClass2;
        public int statPoint2;
        public StatOption statClass3;
        public int statPoint3;
        public string description;

        public Inventory(
            bool _isEquiped,
            string _name,
            StatOption _statClass1,
            int _statPoint1,
            StatOption _statClass2,
            int _statPoint2,
            StatOption _statClass3,
            int _statPoint3,
            string _description
        )
        {
            this.isEquiped = _isEquiped;
            this.name = _name;
            this.statClass1 = _statClass1;
            this.statPoint1 = _statPoint1;
            this.statClass2 = _statClass2;
            this.statPoint2 = _statPoint2;
            this.statClass3 = _statClass3;
            this.statPoint3 = _statPoint3;
            this.description = _description;
        }

        public enum StatOption
        {
            ATK,
            DEF,
            HP
        }
    }
}
