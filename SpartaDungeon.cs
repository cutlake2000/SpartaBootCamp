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
                case ConsoleKey.D2: // 나가기
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

        enum SceneStatus
        {
            FromMain,
            FromStatus
        }
    }
}
