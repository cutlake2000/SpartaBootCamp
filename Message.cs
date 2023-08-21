using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Message
    {
        Canvas canvas = new Canvas();

        int messageLeftPadding = 2; // 좌측 패딩

        // 타이틀 메시지 출력
        public void SetMessageInTitleScene()
        {
            int messageWidth = 31; // 메시지 가로 길이
            int startDrawingMessagePointX = (canvas.canvasWidth - messageWidth) / 2; // 메시지를 그리기 시작할 X 좌표
            int startDrawingMessagePointY = canvas.canvasHeight - 4; // 메시지를 그리기 시작할 X 좌표

            Console.SetCursorPosition(startDrawingMessagePointX, startDrawingMessagePointY);
            Console.Write("<< Press any button to start >>");
        }

        // 첫 화면 메시지 출력
        public void SetMessageInFirstStage()
        {
            Console.SetCursorPosition(messageLeftPadding, canvas.messagePanelHeight + 1);
            Console.Write("스파르타 마을에 오신 여러분 환영합니다.");
            Console.SetCursorPosition(messageLeftPadding, canvas.messagePanelHeight + 2);
            Console.Write("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.SetCursorPosition(messageLeftPadding, canvas.messagePanelHeight + 4);
            Console.Write("1. 캐릭터");
            Console.SetCursorPosition(messageLeftPadding, canvas.messagePanelHeight + 5);
            Console.Write("2. 인벤토리");
            Console.SetCursorPosition(messageLeftPadding, canvas.messagePanelHeight + 6);
            Console.Write("3. 상점");
        }

        // 플레이어 상태창 메시지 출력
        public void SetMessageInPlayerStatusPanel()
        {
            Console.SetCursorPosition(35, canvas.canvasHeight - 4);
            Console.Write("1. 인벤토리");
            Console.SetCursorPosition(35, canvas.canvasHeight - 3);
            Console.Write("2. 나가기");
        }
    }
}
