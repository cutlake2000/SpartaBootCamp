using System;

namespace TikTakToe
{
    class Program
    {
        // 플레이어의 마크를 기억할 목적의 배열
        static char[] drawMark = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        // 현재 플레이 중인 플레이어 확인 목적의 변수
        static int playerTurn = 1;

        // 진행 중인 턴을 확인 목적의 변수
        static int turnCount = 1;

        // 플레이어의 입력을 받아 추후에 배열 값을 수정해주기 위한 변수
        static int playerInput = 0;

        // 출력할 메시지 플래그를 담당할 변수
        static int warningMessage = 0;

        // 게임 상태 플래그를 담당할 변수
        static int isGameOver = 2;

        static void Main(string[] args)
        {
            do // do ~ while() 문을 사용해 먼저 한 번 실행 후에 조건 비교하도록 하기
            {
                // 게임 시작 전 Console 창을 Clear하고 간단한 설명과 플레이어 차례 보여주기
                Console.Clear();
                Console.WriteLine("플레이어 1: X 와 플레이어 2: O\n");
                Console.WriteLine("# 플레이어 {0}의 차례\n", playerTurn);

                // 3 x 3 표 그리기
                DrawPanel();

                // warningMessage를 통해 출력할 메시지 변경
                switch (warningMessage)
                {
                    case 1: // 이미 마커가 위치한 곳에 마커를 두려고 할 경우
                        Console.WriteLine("# 이미 마커가 위치하고 있습니다, 다른 위치를 골라주세요!\n");
                        break;
                    case 2: // 1 ~ 9 사이의 값을 입력하지 않은 경우
                        Console.WriteLine("# 잘못된 위치입니다, 다른 위치를 골라주세요!\n");
                        break;
                }

                // 사용자에게서 입력 받기
                playerInput = int.Parse(Console.ReadLine());

                // 입력 받은 위치에 마커 표기
                DrawMarkerOnPanel();

                // 줄이 완성되었는지 확인
                IsGameOver();
            } while (isGameOver == 2);

            // 게임 종료 후 승자 표시 패널 띄우기
            DrawEndPanel();
        }

        // 3 x 3 표 그리기
        static void DrawPanel()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", drawMark[0], drawMark[1], drawMark[2]);
            Console.WriteLine("_____|_____|______");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", drawMark[3], drawMark[4], drawMark[5]);
            Console.WriteLine("_____|_____|______");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", drawMark[6], drawMark[7], drawMark[8]);
            Console.WriteLine("     |     |      \n");
        }

        static void DrawMarkerOnPanel()
        {
            // Input 값이 1 ~ 9 사이 값인 경우
            if (1 <= playerInput && playerInput <= 9)
            {
                // 해당 위치의 drawCheck에 값이 들어있지 않은 경우
                if ((drawMark[playerInput - 1] != 79) && (drawMark[playerInput - 1] != 88))
                {
                    // 마커다운
                    // 플레이어 1의 턴이라면
                    if (playerTurn == 1)
                    {
                        drawMark[playerInput - 1] = 'O'; // O로 마커다운
                    }
                    else
                    {
                        drawMark[playerInput - 1] = 'X'; // X로 마커다운
                    }

                    // turnCount + 1
                    turnCount++;

                    // warningMessage 끄기
                    warningMessage = 0;

                    // playerTurn 조정
                    playerTurn = (playerTurn == 1) ? 2 : 1;
                }
                else
                {
                    // 이미 마커가 위치한 곳에 마커를 두려고 할 경우
                    warningMessage = 1;
                }
            }
            else
            {
                // 1 ~ 9 사이의 값을 입력하지 않은 경우
                warningMessage = 2;
            }
        }

        // 줄이 완성되었는지 확인
        static void IsGameOver()
        {
            // 아무 문제가 없다면
            if (warningMessage == 0)
            {
                // 1열 일치 여부
                if ((drawMark[0] == drawMark[1]) && (drawMark[0] == drawMark[2]))
                {
                    isGameOver = 1;
                }
                // 2열 일치 여부
                else if ((drawMark[3] == drawMark[4]) && (drawMark[3] == drawMark[5]))
                {
                    isGameOver = 1;
                }
                // 3열 일치 여부
                else if ((drawMark[6] == drawMark[7]) && (drawMark[6] == drawMark[8]))
                {
                    isGameOver = 1;
                }
                // 1행 일치 여부
                else if ((drawMark[0] == drawMark[3]) && (drawMark[0] == drawMark[6]))
                {
                    isGameOver = 1;
                }
                // 2행 일치 여부
                else if ((drawMark[1] == drawMark[4]) && (drawMark[1] == drawMark[7]))
                {
                    isGameOver = 1;
                }
                // 3행 일치 여부
                else if ((drawMark[2] == drawMark[5]) && (drawMark[2] == drawMark[8]))
                {
                    isGameOver = 1;
                }
                // 대각선 일치 여부 1
                else if ((drawMark[0] == drawMark[4]) && (drawMark[0] == drawMark[8]))
                {
                    isGameOver = 1;
                }
                // 대각선 일치 여부 2
                else if ((drawMark[2] == drawMark[4]) && (drawMark[2] == drawMark[6]))
                {
                    isGameOver = 1;
                }

                // 일치하는 라인이 하나라도 존재할 경우
                if ((isGameOver == 1))
                {
                    // 마지막에 찍힌 마커가 플레이어 2의 마커라면
                    // isGameOver = -1
                    // 그렇지 않다면 (플레이어 1의 마커라면)
                    // isGameOver = 1
                    if (drawMark[playerInput] == 'O')
                    {
                        isGameOver = -1;
                    }
                }
                // 9번째 턴이고 아직 일치하는 라인이 만들어지지 않았다면
                else if ((isGameOver == 2) && (turnCount >= 9))
                {
                    isGameOver = 0;
                }
            }
        }

        // 게임 종료 후 승자 표시 패널 띄우기
        static void DrawEndPanel()
        {
            // 콘솔창을 클리어 후에
            Console.Clear();

            // isGameOver 플래그에 따라 메시지 출력
            switch (isGameOver)
            {
                case 1: // 플레이어 1의 승리
                    Console.WriteLine("Winner Winner Chicken Dinner!!\nWinner is Player1");
                    break;
                case -1: // 플레이어 2의 승리
                    Console.WriteLine("Winner Winner Chicken Dinner!!\nWinner is Player2");
                    break;
                case 0: // 무승부
                    Console.WriteLine("무승부!");
                    break;
            }

            // 패널 그리기
            DrawPanel();
        }
    }
}
