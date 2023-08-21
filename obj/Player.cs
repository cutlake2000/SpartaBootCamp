using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Player
    {
        public int playerLevel { get; private set; }
        public string playerClass { get; private set; }
        public int playerAttack { get; private set; }
        public int playerDefence { get; private set; }
        public int playerHealth { get; private set; }
        public int playerGold { get; private set; }

        public Player()
        {
            playerLevel = 1;
            playerClass = "전사";
            playerAttack = 10;
            playerDefence = 5;
            playerHealth = 100;
            playerGold = 1500;
        }
    }
}
