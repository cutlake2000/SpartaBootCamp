using System;

namespace SpartaDungeonGame
{
    public class SpartaDungeon
    {
        SceneManager sceneManager = new SceneManager();

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
                        CallInventoryScene(SceneStatus.FromMain);
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
                    CallInventoryScene(SceneStatus.FromStatus);
                    break;
                case ConsoleKey.D2: // 나가기
                    CallMainScene();
                    break;
                default:
                    CallStatusScene();
                    break;
            }
        }

        // 인벤토리 창 출력
        void CallInventoryScene(SceneStatus status)
        {
            sceneManager.SetInventoryScene();

            switch (InputKey())
            {
                case ConsoleKey.D1: // 아이템 장착
                    CallEquipWeaponScene(status);
                    break;
                case ConsoleKey.D2: // 아이템 정렬
                    // CallSortInventoryScene(status);
                    break;
                case ConsoleKey.D3: // 나가기
                    if (status == SceneStatus.FromMain)
                        CallMainScene();
                    else if (status == SceneStatus.FromStatus)
                        CallStatusScene();
                    break;
                default:
                    CallInventoryScene(status);
                    break;
            }
        }

        // 인벤토리 정렬
        // void CallSortInventoryScene(SceneStatus status)
        // {
        // sceneManager.SetInventorySortScene(SceneManager.SortType.Default);

        // switch (InputKey())
        // {
        //     case ConsoleKey.D1: // 이름 정렬
        //         sceneManager.SetInventorySortScene(SceneManager.SortType.Name);
        //         break;
        //     case ConsoleKey.D2: // 장착 여부 정렬
        //         sceneManager.SetInventorySortScene(SceneManager.SortType.isEquiped);
        //         break;
        //     case ConsoleKey.D3: // 공격력 정렬
        //         sceneManager.SetInventorySortScene(SceneManager.SortType.ATK);
        //         break;
        //     case ConsoleKey.D4: // 방어력 정렬
        //         sceneManager.SetInventorySortScene(SceneManager.SortType.DEF);
        //         break;
        //     case ConsoleKey.D0: // 나가기
        //         CallInventoryScene(status);
        //         break;
        // }
        // }

        // 장비 장착창 출력
        void CallEquipWeaponScene(SceneStatus status)
        {
            sceneManager.SetEquipWeaponScene();

            CallInventoryScene(status);
        }

        // 상점창 출력
        void CallShopScene()
        {
            sceneManager.SetShopScene();
        }

        // 던전창 출력
        void CallDungeonScene()
        {
            sceneManager.SetDungeonScene();
            InputKey();
        }

        enum SceneStatus
        {
            FromMain,
            FromStatus,
            FromInventory
        }
    }
}
