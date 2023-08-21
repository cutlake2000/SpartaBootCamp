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
            messagePanelHeight,
            infoLongPanelWidth,
            infoShortPanelWidth;

        public Canvas()
        {
            canvasWidth = 100; // 캔버스 가로 길이
            canvasHeight = 20; // 캔버스 세로 길이
            infoLongPanelWidth = 33;
            infoShortPanelWidth = 62;
            messagePanelHeight = canvasHeight - 8; // 메시지 패널 Y 좌표 고정
        }

        // 게임 스크린 아웃라인 그리기
        public void DrawOutLine()
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
        public void DrawTitle()
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

        // 메시지를 출력할 패널 아웃라인 그리기
        public void DrawMessagePanel(int posX1, int posX2, int posY)
        {
            for (int i = posX1; i <= posX2; i++)
            {
                Console.SetCursorPosition(i, posY);
                Console.Write("=");
            }
        }

        // 스탯창 그리기
        public void DrawStatusPanel(Player player)
        {
            int equipmentStatATK = 0;
            int equipmentStatDEF = 0;
            int equipmentStatHP = 0;

            // 인벤토리 스캔해서 플레이어 Status 수정하기
            for (int i = 0; i < player.inventories.Count(); i++)
            {
                if (player.inventories[i].isEquiped == true)
                {
                    if (player.inventories[i].statPoint1 != 0)
                    {
                        equipmentStatATK += player.inventories[i].statPoint1;
                    }
                    if (player.inventories[i].statPoint2 != 0)
                    {
                        equipmentStatDEF += player.inventories[i].statPoint2;
                    }
                    if (player.inventories[i].statPoint3 != 0)
                    {
                        equipmentStatHP += player.inventories[i].statPoint3;
                    }
                }
            }

            string playerMainInfo = "Lv. " + player.level + "   " + player.job; // 플레이어 레벨과 직업 정보
            string playerAttackInfo = player.attack.ToString(); // 플레이어 공격력 정보
            string playerDefenceInfo = player.defence.ToString(); // 플레이어 방어력 정보
            string playerHealthInfo = player.health.ToString(); // 플레이어 체력 정보
            string playerGoldInfo = player.gold.ToString() + " G"; // 플레이어 소지금액 정보

            // Status 에 추가 스탯 표시하기
            if (equipmentStatATK != 0)
                playerAttackInfo += " (+" + equipmentStatATK + ")";
            if (equipmentStatDEF != 0)
                playerDefenceInfo += " (+" + equipmentStatDEF + ")";
            if (equipmentStatHP != 0)
                playerHealthInfo += " (+" + equipmentStatHP + ")";

            int playerMainInfoLength = playerMainInfo.Length; // playerMainInfo 길이
            int playerAttackInfoLength = playerAttackInfo.Length; // playerAttackInfo 길이
            int playerDefenceInfoLength = playerDefenceInfo.Length; // playerDefenceInfo 길이
            int playerHealthInfoLength = playerHealthInfo.Length; // playerHealthInfo 길이
            int playerGoldInfoLength = playerGoldInfo.Length; // playerGoldInfo 길이

            // Status 그리기
            Console.SetCursorPosition(infoLongPanelWidth + 4, 2);
            Console.Write("༺═━━━━━ Status ━━━━═༻");
            Console.SetCursorPosition(infoLongPanelWidth + 4, 12);
            Console.Write("༺═━━━━━━━━━━━━━━━━━═༻");

            Console.SetCursorPosition((33 - playerMainInfoLength) / 2, canvasHeight - 5);
            Console.Write(playerMainInfo);
            Console.SetCursorPosition(infoLongPanelWidth + 5, 4);
            Console.Write(" 공격력   | ");
            Console.SetCursorPosition(infoLongPanelWidth + 5, 6);
            Console.Write(" 방어력   | ");
            Console.SetCursorPosition(infoLongPanelWidth + 5, 8);
            Console.Write(" 체  력   | ");
            Console.SetCursorPosition(infoLongPanelWidth + 5, 10);
            Console.Write(" 소지금   | ");

            Console.SetCursorPosition((53 - playerAttackInfoLength) + 6, 4);
            Console.Write(playerAttackInfo);
            Console.SetCursorPosition((53 - playerDefenceInfoLength) + 6, 6);
            Console.Write(playerDefenceInfo);
            Console.SetCursorPosition((53 - playerHealthInfoLength) + 6, 8);
            Console.Write(playerHealthInfo);
            Console.SetCursorPosition((53 - playerGoldInfoLength) + 6, 10);
            Console.Write(playerGoldInfo);

            for (int i = 1; i < canvasHeight - 6; i++)
            {
                Console.SetCursorPosition(62, i);
                Console.Write("|");
            }
        }

        // 장착 중인 장비창 그리기
        public void DrawEquipmentPanel(Player player)
        {
            // Equipment에서 SetCursorPosition Y좌표를 잡아줄 변수
            int inventoryIndex = 3;

            // 장착 장비 그리기
            Console.SetCursorPosition(66, 2);
            Console.Write("༺═━━━━━━━ Equipment ━━━━━━═༻");
            Console.SetCursorPosition(66, 12);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━━━═༻");

            // 플레이어 인벤토리를 스캔해서
            for (int i = 0; i < player.inventories.Count; i++)
            {
                // 장착 중으로 표기된 장비가 있다면
                if (player.inventories[i].isEquiped == true)
                {
                    Console.SetCursorPosition(80, inventoryIndex);
                    Console.Write("|");
                    Console.SetCursorPosition(
                        (18 - player.inventories[i].name.Length) / 2 + 62,
                        inventoryIndex
                    );
                    Console.Write(player.inventories[i].name);

                    // 특정 스탯을 올려주는지 확인
                    Console.SetCursorPosition(82, inventoryIndex);
                    if (player.inventories[i].statPoint1 != 0)
                    {
                        Console.Write(
                            " + {0} ({1}) ",
                            player.inventories[i].statPoint1,
                            player.inventories[i].statClass1.ToString()
                        );
                    }
                    if (player.inventories[i].statPoint2 != 0)
                    {
                        Console.Write(
                            " + {0} ({1}) ",
                            player.inventories[i].statPoint2,
                            player.inventories[i].statClass2.ToString()
                        );
                    }
                    if (player.inventories[i].statPoint3 != 0)
                    {
                        Console.Write(
                            " + {0} ({1}) ",
                            player.inventories[i].statPoint3,
                            player.inventories[i].statClass3.ToString()
                        );
                    }
                }
            }
        }

        // 장비 장착창 그리기
        public void DrawEquipWeaponPanel(Player player)
        {
            int inventoryIndex = 3; // Inventory에서 SetCursorPosition Y좌표를 잡아줄 변수

            Console.SetCursorPosition(infoLongPanelWidth + 4, 2);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━ Equip Weapon ━━━━━━━━━━━━━━━━━━━━═༻");
            Console.SetCursorPosition(infoLongPanelWidth + 4, 12);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━═༻");

            for (int i = 0; i < player.inventories.Count; i++)
            {
                Console.SetCursorPosition(infoLongPanelWidth + 3, inventoryIndex);
                Console.Write("{0})", i + 1);

                // 장착 중이라면 [E] 마크 달기
                if (player.inventories[i].isEquiped == true)
                {
                    Console.SetCursorPosition(infoLongPanelWidth + 6, inventoryIndex);
                    Console.Write("[E]");
                }
                // 장비 이름 적기
                Console.SetCursorPosition(
                    ((12 - player.inventories[i].name.Length) / 2) + infoLongPanelWidth + 7,
                    inventoryIndex
                );
                Console.Write(player.inventories[i].name);
                Console.SetCursorPosition(54, inventoryIndex);
                Console.Write("|");

                // 장비 스탯 적기
                if (player.inventories[i].statPoint1 != 0)
                {
                    Console.SetCursorPosition(infoLongPanelWidth + 23, inventoryIndex);
                    Console.Write(
                        "{0} (+{1})",
                        player.inventories[i].statClass1,
                        player.inventories[i].statPoint1
                    );
                }
                if (player.inventories[i].statPoint2 != 0)
                {
                    Console.SetCursorPosition(infoLongPanelWidth + 23, inventoryIndex);
                    Console.Write(
                        "{0} (+{1})",
                        player.inventories[i].statClass2,
                        player.inventories[i].statPoint2
                    );
                }

                inventoryIndex++;
            }
        }

        //인벤토리 창 그리기
        public void DrawInventoryPanel(Player player)
        {
            int inventoryIndex = 3; // Inventory에서 SetCursorPosition Y좌표를 잡아줄 변수

            Console.SetCursorPosition(infoLongPanelWidth + 4, 2);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━ Inventory ━━━━━━━━━━━━━━━━━━━━━═༻");
            Console.SetCursorPosition(infoLongPanelWidth + 4, 12);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━═༻");

            for (int i = 0; i < player.inventories.Count; i++)
            {
                // 장착 중이라면 [E] 마크 달기
                if (player.inventories[i].isEquiped == true)
                {
                    Console.SetCursorPosition(infoLongPanelWidth + 2, inventoryIndex);
                    Console.Write("[E]");
                }
                // 장비 이름 적기
                Console.SetCursorPosition(
                    ((12 - player.inventories[i].name.Length) / 2) + infoLongPanelWidth + 3,
                    inventoryIndex
                );
                Console.Write(player.inventories[i].name);
                Console.SetCursorPosition(50, inventoryIndex);
                Console.Write("|");

                // 장비 스탯 적기
                if (player.inventories[i].statPoint1 != 0)
                {
                    Console.SetCursorPosition(52, inventoryIndex);
                    Console.Write(
                        "{0} (+{1})",
                        player.inventories[i].statClass1,
                        player.inventories[i].statPoint1
                    );
                }
                if (player.inventories[i].statPoint2 != 0)
                {
                    Console.SetCursorPosition(52, inventoryIndex);
                    Console.Write(
                        "{0} (+{1})",
                        player.inventories[i].statClass2,
                        player.inventories[i].statPoint2
                    );
                }
                if (player.inventories[i].statPoint3 != 0)
                {
                    Console.SetCursorPosition(52, inventoryIndex);
                    Console.Write(
                        " {0} (+{1})",
                        player.inventories[i].statClass3,
                        player.inventories[i].statPoint3
                    );
                }

                Console.SetCursorPosition(61, inventoryIndex);
                Console.Write("|");

                // 장비 설명 적기
                Console.SetCursorPosition(63, inventoryIndex);
                Console.Write(player.inventories[i].description);

                inventoryIndex++;
            }
        }

        // 플레이어 이미지를 좌측 패널에 그리기
        public void DrawPlayerPanel(Player player)
        {
            string playerMainInfo = "Lv. " + player.level + "   " + player.job;
            int playerMainInfoLength = playerMainInfo.Length;

            Console.SetCursorPosition((33 - playerMainInfoLength) / 2, canvasHeight - 5);
            Console.Write(playerMainInfo);

            Console.SetCursorPosition(5, 2);
            Console.Write("༺═━━━━━━ Player ━━━━━═༻");
            Console.SetCursorPosition(5, canvasHeight - 3);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━═༻");

            for (int i = 1; i < canvasHeight - 1; i++)
            {
                Console.SetCursorPosition(33, i);
                Console.Write("║");
            }

            DrawPlayer(7, 5);
        }

        // 플레이어 그리기
        void DrawPlayer(int posX, int posY)
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

        // 마을 그리기
        public void DrawTown(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY + 2);
            Console.Write("。° 。 ° ˛ ˚ ˛ ˚ ˛ ·˚");
            Console.SetCursorPosition(posX, posY + 3);
            Console.Write("· 。 ° · 。 · ˚ ˚ ˛ ˚ ˛");
            Console.SetCursorPosition(posX, posY + 4);
            Console.Write("。° 。 ° 。˚ ˛ · ˚ ˚ ˛");
            Console.SetCursorPosition(posX, posY + 5);
            Console.Write(" ˛ ˚ ˛ ˚ 。 · ˚ ˚ ˛ ˚ ˛ · ·");
            Console.SetCursorPosition(posX, posY + 6);
            Console.Write("。 ° · 。。* 。° 。 ° ˛ ˚ ˛");
            Console.SetCursorPosition(posX, posY + 7);
            Console.Write("* _Π_____*。*˚ ˚ ˛ ˚ ˛ ·˛ ·˚");
            Console.SetCursorPosition(posX, posY + 8);
            Console.Write("*/______/~~\\。˚ ˚ ˛ ˚ ˛ ·˛ ·˚");
            Console.SetCursorPosition(posX, posY + 9);
            Console.Write("｜田 田｜門｜ ˚ ˛ ˚ ˛ ·");
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
