using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Canvas
    {
        public int canvasWidth,
            canvasHeight,
            messagePanelHeight;

        public Canvas()
        {
            canvasWidth = 100; // 캔버스 가로 길이
            canvasHeight = 20; // 캔버스 세로 길이
            messagePanelHeight = canvasHeight - 8; // 메시지 패널 Y 좌표 고정
        }

        // 게임 스크린 아웃라인 그리기
        public void DrawCanvasOutLine()
        {
            // 콘솔창 초기화
            Console.Clear();
            Console.CursorVisible = false;

            // 상하단 가로 줄 표기 '-'
            for (int i = 0; i <= canvasWidth - 1; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
                Console.SetCursorPosition(i, canvasHeight - 1);
                Console.Write("-");
            }
            for (int i = 0; i < canvasHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(canvasWidth - 1, i);
                Console.Write("|");
            }

            // 각 모서리에 * 표기
            Console.SetCursorPosition(0, 0);
            Console.Write('*');
            Console.SetCursorPosition(0, canvasHeight - 1);
            Console.Write('*');
            Console.SetCursorPosition(canvasWidth - 1, 0);
            Console.Write('*');
            Console.SetCursorPosition(canvasWidth - 1, canvasHeight - 1);
            Console.Write('*');
        }

        // 타이틀 그리기
        public void DrawCanvasTitle()
        {
            // Font : Doom
            int titleWidth = 90; // 타이틀 가로 길이
            int titleHeight = 8; // 타이틀 세로 길이

            int startDrawingTitlePointX = (canvasWidth - titleWidth) / 2; // 타이틀을 그리기 시작할 X 좌표
            int startDrawingTitlePointY = (canvasHeight - titleHeight) / 2; // 타이틀을 그리기 시작할 Y 좌표

            // 타이틀 그리기
            Console.SetCursorPosition(startDrawingTitlePointX, startDrawingTitlePointY);
            Console.Write(
                " _____                      _            ______                                          "
            );
            Console.SetCursorPosition(startDrawingTitlePointX, startDrawingTitlePointY + 1);
            Console.Write(
                "/  ___|                    | |           |  _  \\                                         "
            );
            Console.SetCursorPosition(startDrawingTitlePointX, startDrawingTitlePointY + 2);
            Console.Write(
                "\\ `--.  _ __    __ _  _ __ | |_   __ _   | | | | _   _  _ __    __ _   ___   ___   _ __  "
            );
            Console.SetCursorPosition(startDrawingTitlePointX, startDrawingTitlePointY + 3);
            Console.Write(
                " `--. \\| '_ \\  / _` || '__|| __| / _` |  | | | || | | || '_ \\  / _` | / _ \\ / _ \\ | '_ \\ "
            );
            Console.SetCursorPosition(startDrawingTitlePointX, startDrawingTitlePointY + 4);
            Console.Write(
                "/\\__/ /| |_) || (_| || |   | |_ | (_| |  | |/ / | |_| || | | || (_| ||  __/| (_) || | | |"
            );
            Console.SetCursorPosition(startDrawingTitlePointX, startDrawingTitlePointY + 5);
            Console.Write(
                "\\____/ | .__/  \\__,_||_|    \\__| \\__,_|  |___/   \\__,_||_| |_| \\__, | \\___| \\___/ |_| |_|"
            );
            Console.SetCursorPosition(startDrawingTitlePointX, startDrawingTitlePointY + 6);
            Console.Write(
                "       | |                                                      __/ |                    "
            );
            Console.SetCursorPosition(startDrawingTitlePointX, startDrawingTitlePointY + 7);
            Console.Write(
                "       |_|                                                     |___/                     "
            );
        }

        // 메시지를 출력할 패널 그리기
        public void DrawMainMessagePanel(int posX1, int posX2, int posY)
        {
            for (int i = posX1; i <= posX2; i++)
            {
                Console.SetCursorPosition(i, posY);
                Console.Write("=");
            }
        }

        // 플레이어 상태창 그리기
        public void DrawPlayerStatus()
        {
            Console.SetCursorPosition(5, 2);
            Console.Write("༺═━━━━━━ Player ━━━━━═༻");
            Console.SetCursorPosition(5, canvasHeight - 3);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━═༻");

            for (int i = 1; i < canvasHeight - 1; i++)
            {
                Console.SetCursorPosition(34, i);
                Console.Write("║");
            }
        }

        // 플레이어 그리기
        public void DrawPlayer(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write("       (\\__/)     ");
            Console.SetCursorPosition(posX, posY + 1);
            Console.Write("       (•ㅅ•)  ");
            Console.SetCursorPosition(posX, posY + 2);
            Console.Write("   ＿ノヽ  ノ＼＿ ");
            Console.SetCursorPosition(posX, posY + 3);
            Console.Write(" /    Y ⌒Ｙ⌒ Ｙヽヽ");
            Console.SetCursorPosition(posX, posY + 4);
            Console.Write("(   (三ヽ人  /    |");
            Console.SetCursorPosition(posX, posY + 5);
            Console.Write("|   ﾉ ¯¯\\ ￣￣ヽ ノ");
            Console.SetCursorPosition(posX, posY + 6);
            Console.Write("ヽ＿＿＿  ＞､＿_／");
            Console.SetCursorPosition(posX, posY + 7);
            Console.Write("    ｜ ( 王 ) 〈");
            Console.SetCursorPosition(posX, posY + 8);
            Console.Write("    /  ﾐ`——彡  \\");
        }

        // 드래곤 그리기
        public void DrawDragon(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(" <>=======()");
            Console.SetCursorPosition(posX, posY + 1);
            Console.Write("(/\\___   /|\\\\          ()==========<>_");
            Console.SetCursorPosition(posX, posY + 2);
            Console.Write("      \\_/ | \\\\        //|\\   ______/ \\)");
            Console.SetCursorPosition(posX, posY + 3);
            Console.Write("        \\_|  \\\\      // | \\_/");
            Console.SetCursorPosition(posX, posY + 4);
            Console.Write("          \\|\\/|\\_   //  /\\/");
            Console.SetCursorPosition(posX, posY + 5);
            Console.Write("           (oo)\\ \\_//  /");
            Console.SetCursorPosition(posX, posY + 6);
            Console.Write("          //_/\\_\\/ /  |");
            Console.SetCursorPosition(posX, posY + 7);
            Console.Write("         @@/  |=\\  \\  |");
            Console.SetCursorPosition(posX, posY + 8);
            Console.Write("              \\_=\\_ \\ |");
            Console.SetCursorPosition(posX, posY + 9);
            Console.Write("                \\==\\ \\|\\_");
            Console.SetCursorPosition(posX, posY + 10);
            Console.Write("            ___(\\===\\(  )\\");
            Console.SetCursorPosition(posX, posY + 11);
            Console.Write("           (((~)  __(_/   |");
            Console.SetCursorPosition(posX, posY + 12);
            Console.Write("                 (((~) \\  /");
            Console.SetCursorPosition(posX, posY + 13);
            Console.Write("                 ______/ /");
            Console.SetCursorPosition(posX, posY + 14);
            Console.Write("                 '------'");

            Console.SetCursorPosition(0, 21);
        }
    }
}
