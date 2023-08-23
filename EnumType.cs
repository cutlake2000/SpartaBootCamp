using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class EnumType
    {
        // 정렬 타입
        public enum SortType
        {
            Default,
            Name,
            isEquiped,
            ATK,
            DEF
        }

        // 씬 전환 타입
        public enum SceneType
        {
            FromMain,
            FromStatus,
            FromInventory
        }
    }
}
