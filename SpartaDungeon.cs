using System;

namespace SpartaDungeonGame
{
    public class SpartaDungeon
    {
        Canvas canvas = new Canvas();
        Message message = new Message();

        public void Run()
        {
            // 타이틀 출력하는 메소드
            SetTitleScene();

            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                SetInGameScene();
            }

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    SetPlayerStatus();
                    break;
                case '2':
                    Console.Write("2번 눌렀음");
                    break;
                case '3':
                    Console.Write("3번 눌렀음");
                    break;
            }

            Console.SetCursorPosition(0, 21);
        }

        // 타이틀 출력하는 메소드
        void SetTitleScene()
        {
            canvas.DrawCanvasOutLine();
            canvas.DrawCanvasTitle();
            message.SetMessageInTitleScene();
        }

        // 첫 스테이지를 출력하는 메소드
        void SetInGameScene()
        {
            canvas.DrawCanvasOutLine();
            canvas.DrawMainMessagePanel(1, canvas.canvasWidth - 1, canvas.canvasHeight - 8);
            message.SetMessageFirstStage();
        }

        // 플레이어 상태창을 출력하는 메소드
        void SetPlayerStatus()
        {
            canvas.DrawCanvasOutLine();
            canvas.DrawPlayerStatus();
            canvas.DrawPlayer(7, 6);
            canvas.DrawMainMessagePanel(35, canvas.canvasWidth - 2, canvas.canvasHeight - 8);
        }
    }
}
