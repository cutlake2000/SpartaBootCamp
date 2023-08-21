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
                        CallInventoryScene();
                        break;
                    case ConsoleKey.D3: // 상점
                        CallShopScene();
                        break;
                }
            } while (isGameEnd == false);
        }

        // 캐릭터창 출력
        void CallStatusScene()
        {
            sceneManager.SetStatus();

            switch (InputKey())
            {
                case ConsoleKey.D1: // 인벤토리
                    CallInventoryScene();
                    break;
                case ConsoleKey.D2: // 나가기
                    CallMainScene();
                    break;
            }
        }

        // 인벤토리창 출력
        void CallInventoryScene()
        {
            sceneManager.SetInventory();
        }

        // 상점창 출력
        void CallShopScene()
        {
            sceneManager.SetShop();
        }
    }
}
