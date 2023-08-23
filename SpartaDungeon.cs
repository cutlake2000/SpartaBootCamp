using System;

namespace SpartaDungeonGame
{
    public class SpartaDungeon
    {
        SceneManager sceneManager = new SceneManager();
        EnumType enumType = new EnumType();
        ConsoleKey inputKey = ConsoleKey.Clear; // 플레이어 입력을 관리할 변수
        bool isGameEnd = false;

        public void Run()
        {
            // 타이틀 출력
            CallTitleScene();
            // 메인씬 출력
            CallMainScene();

            Console.SetCursorPosition(0, 21);
        }

        ConsoleKey InputKey()
        {
            return Console.ReadKey().Key;
        }

        // 타이틀 출력
        void CallTitleScene()
        {
            do
            {
                sceneManager.SetTitleScene();
            } while (InputKey() != ConsoleKey.Enter);
        }

        // 메인씬 출력
        void CallMainScene()
        {
            do
            {
                sceneManager.SetMainScene();

                switch (InputKey())
                {
                    case ConsoleKey.D1: // 캐릭터
                        CallStatusScene();
                        break;
                    case ConsoleKey.D2: // 인벤토리
                        CallInventoryScene(EnumType.SceneType.FromMain);
                        break;
                    case ConsoleKey.D3: // 상점
                        CallShopScene();
                        break;
                    case ConsoleKey.D4: // 던전
                        CallDungeonScene();
                        break;
                    default:
                        CallMainScene();
                        break;
                }
            } while (isGameEnd == false);
        }

        // 캐릭터 정보창 출력
        void CallStatusScene()
        {
            sceneManager.SetStatusScene();

            switch (InputKey())
            {
                case ConsoleKey.D1: // 인벤토리
                    CallInventoryScene(EnumType.SceneType.FromStatus);
                    break;
                case ConsoleKey.D0: // 나가기
                    CallMainScene();
                    break;
                default:
                    CallStatusScene();
                    break;
            }
        }

        // 인벤토리 창 출력
        void CallInventoryScene(EnumType.SceneType status)
        {
            sceneManager.SetInventoryScene();

            switch (InputKey())
            {
                case ConsoleKey.D1: // 아이템 장착
                    CallEquipWeaponScene(status);
                    break;
                case ConsoleKey.D2: // 아이템 정렬
                    CallInventorySortScene(status);
                    break;
                case ConsoleKey.D0: // 나가기
                    if (status == EnumType.SceneType.FromMain)
                        CallMainScene();
                    else if (status == EnumType.SceneType.FromStatus)
                        CallStatusScene();
                    break;
                default:
                    CallInventoryScene(status);
                    break;
            }
        }

        // 인벤토리 정렬창 출력
        public void CallInventorySortScene(EnumType.SceneType status)
        {
            int sortIndex;

            do
            {
                sceneManager.SetInventorySortScene(EnumType.SortType.Default);

                sortIndex = Console.ReadKey().KeyChar - 48;

                if (1 <= sortIndex && sortIndex <= 4)
                {
                    switch (sortIndex)
                    {
                        case 1: // 이름 정렬
                            sceneManager.SetInventorySortScene(EnumType.SortType.Name);
                            break;
                        case 2: // 장착 여부 정렬
                            sceneManager.SetInventorySortScene(EnumType.SortType.isEquiped);
                            break;
                        case 3: // 공격력 정렬
                            sceneManager.SetInventorySortScene(EnumType.SortType.ATK);
                            break;
                        case 4: // 방어력 정렬
                            sceneManager.SetInventorySortScene(EnumType.SortType.DEF);
                            break;
                    }
                }
            } while (sortIndex != 0);

            CallInventoryScene(status);
        }

        // 장비 장착창 출력
        void CallEquipWeaponScene(EnumType.SceneType status)
        {
            sceneManager.SetEquipWeaponScene();

            CallInventoryScene(status);
        }

        // 상점창 출력
        void CallShopScene()
        {
            sceneManager.SetShopScene();
        }

        // 아이템 구매창 출력()
        void CallShopSellScene() { }

        // 아이템 판매창 출력()
        void CallShopBuyScene() { }

        // 던전창 출력
        void CallDungeonScene()
        {
            sceneManager.SetDungeonScene();
            InputKey();
        }
    }
}
