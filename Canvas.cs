using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Canvas
    {
        EnumType enumType = new EnumType();

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
                    if (player.inventories[i].statClass == Item.StatOption.ATK)
                    {
                        equipmentStatATK += player.inventories[i].statPoint;
                    }
                    else if (player.inventories[i].statClass == Item.StatOption.DEF)
                    {
                        equipmentStatDEF += player.inventories[i].statPoint;
                    }
                    else if (player.inventories[i].statClass == Item.StatOption.HP)
                    {
                        equipmentStatHP += player.inventories[i].statPoint;
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
            Console.SetCursorPosition(infoLongPanelWidth + 4, 13);
            Console.Write("༺═━━━━━━━━━━━━━━━━━═༻");

            Console.SetCursorPosition((33 - playerMainInfoLength) / 2, canvasHeight - 5);
            Console.Write(playerMainInfo);
            Console.SetCursorPosition(infoLongPanelWidth + 5, 4);
            Console.Write(" 공격력   | ");
            Console.SetCursorPosition(infoLongPanelWidth + 5, 6);
            Console.Write(" 방어력   | ");
            Console.SetCursorPosition(infoLongPanelWidth + 5, 8);
            Console.Write(" 체  력   | ");
            Console.SetCursorPosition(infoLongPanelWidth + 5, 11);
            Console.Write(" 소지금   | ");

            Console.SetCursorPosition(infoLongPanelWidth + 19, 4);
            Console.Write(playerAttackInfo);
            Console.SetCursorPosition(infoLongPanelWidth + 19, 6);
            Console.Write(playerDefenceInfo);
            Console.SetCursorPosition(infoLongPanelWidth + 19, 8);
            Console.Write(playerHealthInfo);
            Console.SetCursorPosition(infoLongPanelWidth + 19, 11);
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
            Console.SetCursorPosition(66, 13);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━━━═༻");

            // 플레이어 인벤토리를 스캔해서
            for (int i = 0; i < player.inventories.Count; i++)
            {
                // 장착 중으로 표기된 장비가 있다면
                if (player.inventories[i].isEquiped == true)
                {
                    Console.SetCursorPosition(
                        74 - player.inventories[i].name.Length,
                        inventoryIndex
                    );
                    Console.Write(player.inventories[i].name);

                    Console.SetCursorPosition(80, inventoryIndex);
                    Console.Write("|");

                    // 특정 스탯을 올려주는지 확인
                    Console.SetCursorPosition(82, inventoryIndex);
                    if (player.inventories[i].statPoint != 0)
                    {
                        Console.Write(
                            " (+ {0} {1}) ",
                            player.inventories[i].statClass.ToString(),
                            player.inventories[i].statPoint
                        );
                    }
                    inventoryIndex++;
                }
            }
        }

        // 장비 장착창 그리기
        public void DrawEquipWeaponPanel(Player player)
        {
            int locationX = infoLongPanelWidth;
            int locationCount = 0;
            int inventoryIndex = 3; // Inventory에서 SetCursorPosition Y좌표를 잡아줄 변수

            Console.SetCursorPosition(locationX + 4, 2);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━ Equipment ━━━━━━━━━━━━━━━━━━━━━═༻");
            Console.SetCursorPosition(locationX + 4, 12);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━═༻");

            for (int i = 0; i < player.inventories.Count; i++)
            {
                Console.SetCursorPosition(locationX + 3, inventoryIndex);
                Console.Write("{0})", i + 1);

                // 장착 중이라면 [E] 마크 달기
                if (player.inventories[i].isEquiped == true)
                {
                    Console.SetCursorPosition(locationX + 6, inventoryIndex);
                    Console.Write("[E]");
                }
                else
                {
                    Console.SetCursorPosition(locationX + 6, inventoryIndex);
                    Console.Write("[ ]");
                }

                // 장비 이름 적기
                Console.SetCursorPosition(
                    ((12 - player.inventories[i].name.Length) / 2) + locationX + 7,
                    inventoryIndex
                );
                Console.Write(player.inventories[i].name);
                Console.SetCursorPosition(locationX + 20, inventoryIndex);
                Console.Write("|");

                // 장비 스탯 적기
                if (player.inventories[i].statPoint != 0)
                {
                    Console.SetCursorPosition(locationX + 22, inventoryIndex);
                    Console.Write(
                        "{0} (+{1})",
                        player.inventories[i].statClass,
                        player.inventories[i].statPoint
                    );
                }

                if (locationCount == 0)
                {
                    locationCount++;
                    locationX += 31;
                }
                else if (locationCount == 1)
                {
                    locationCount--;
                    locationX -= 31;
                    Console.SetCursorPosition(locationX + 32, inventoryIndex);
                    Console.Write("║");
                    inventoryIndex++;
                }
            }
        }

        //인벤토리 창 그리기
        public void DrawInventoryPanel(Player player, EnumType.SortType sortType)
        {
            int nameType = 0;
            int isEquipedType = 0;
            int ATKType = 0;
            int DEFType = 0;

            if (sortType == EnumType.SortType.Name)
            {
                if (nameType == 0)
                {
                    player.inventories = new List<Inventory>(
                        player.inventories.OrderBy(p => p.name.Length)
                    );
                    nameType++;
                }
                else
                {
                    player.inventories = new List<Inventory>(
                        player.inventories.OrderByDescending(p => p.name.Length)
                    );
                    nameType--;
                }
            }
            else if (sortType == EnumType.SortType.isEquiped)
            {
                if (isEquipedType == 0)
                {
                    player.inventories = new List<Inventory>(
                        player.inventories.OrderByDescending(p => p.isEquiped)
                    );
                    isEquipedType++;
                }
                else
                {
                    player.inventories = new List<Inventory>(
                        player.inventories.OrderBy(p => p.isEquiped)
                    );
                    isEquipedType--;
                }
            }
            else if (sortType == EnumType.SortType.ATK)
            {
                if (ATKType == 0)
                {
                    player.inventories = new List<Inventory>(
                        player.inventories.OrderBy(p => p.statClass).ThenBy(p => p.statPoint)
                    );
                    ATKType++;
                }
                else
                {
                    player.inventories = new List<Inventory>(
                        player.inventories
                            .OrderBy(p => p.statClass)
                            .ThenByDescending(p => p.statPoint)
                    );
                    ATKType--;
                }
            }
            else if (sortType == EnumType.SortType.DEF)
            {
                if (DEFType == 0)
                {
                    player.inventories = new List<Inventory>(
                        player.inventories
                            .OrderByDescending(p => p.statClass)
                            .ThenBy(p => p.statPoint)
                    );
                    DEFType++;
                }
                else
                {
                    player.inventories = new List<Inventory>(
                        player.inventories
                            .OrderByDescending(p => p.statClass)
                            .ThenByDescending(p => p.statPoint)
                    );
                    DEFType--;
                }
            }
            int inventoryIndex = 3; // Inventory에서 SetCursorPosition Y좌표를 잡아줄 변수

            Console.SetCursorPosition(infoLongPanelWidth + 4, 2);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━ Inventory ━━━━━━━━━━━━━━━━━━━━━═༻");
            Console.SetCursorPosition(infoLongPanelWidth + 4, 13);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━═༻");

            for (int i = 0; i < player.inventories.Count; i++)
            {
                // 장착 중이라면 [E] 마크 달기
                if (player.inventories[i].isEquiped == true)
                {
                    Console.SetCursorPosition(infoLongPanelWidth + 2, inventoryIndex);
                    Console.Write("[E] | ");
                }
                else
                {
                    Console.SetCursorPosition(infoLongPanelWidth + 6, inventoryIndex);
                    Console.Write("|");
                }
                // 장비 이름 적기
                Console.SetCursorPosition(infoLongPanelWidth + 8, inventoryIndex);
                Console.Write(player.inventories[i].name);

                Console.SetCursorPosition(57, inventoryIndex);
                Console.Write("|");

                // 장비 스탯 적기
                if (player.inventories[i].statPoint != 0)
                {
                    string statPoint = "(+" + player.inventories[i].statPoint + ")";
                    Console.SetCursorPosition(59, inventoryIndex);
                    Console.Write(player.inventories[i].statClass);
                    Console.SetCursorPosition(68 - statPoint.Length, inventoryIndex);
                    Console.Write(statPoint);
                }

                Console.SetCursorPosition(69, inventoryIndex);
                Console.Write("|");

                // 장비 설명 적기
                if (player.inventories[i].description.Length > 14)
                {
                    Console.SetCursorPosition(39, inventoryIndex);
                    Console.Write("|");
                    Console.SetCursorPosition(71, inventoryIndex);
                    Console.Write(player.inventories[i].description.Substring(0, 14));
                    inventoryIndex++;
                    Console.SetCursorPosition(infoLongPanelWidth + 6, inventoryIndex);
                    Console.Write("|");
                    Console.SetCursorPosition(57, inventoryIndex);
                    Console.Write("|");
                    Console.SetCursorPosition(69, inventoryIndex);
                    Console.Write("|");

                    Console.SetCursorPosition(71, inventoryIndex);
                    Console.Write(player.inventories[i].description.Substring(14));
                }
                else
                {
                    Console.SetCursorPosition(71, inventoryIndex);
                    Console.Write(player.inventories[i].description);
                }

                inventoryIndex++;
            }
        }

        // 상점 창 그리기
        public void DrawShopPanel(Player player, Shopper shopper)
        {
            string price;
            int locationX = infoLongPanelWidth + 6;
            int inventoryIndex = 3; // SetCursorPosition Y좌표를 잡아줄 변수

            Console.SetCursorPosition(locationX - 2, 2);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━━ Shop ━━━━━━━━━━━━━━━━━━━━━━━━═༻");
            Console.SetCursorPosition(locationX - 2, 12);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━═༻");

            for (int i = 0; i < shopper.products.Count; i++)
            {
                Console.SetCursorPosition(locationX + 3, inventoryIndex);
                Console.Write("{0})", i + 1);

                // 장비 이름 적기
                Console.SetCursorPosition(
                    locationX + 15 - shopper.products[i].name.Length,
                    inventoryIndex
                );
                Console.Write(shopper.products[i].name);
                Console.SetCursorPosition(locationX + 24, inventoryIndex);
                Console.Write("|");

                // 장비 스탯 적기
                if (shopper.products[i].statPoint != 0)
                {
                    string statPoint = "(+" + shopper.products[i].statPoint + ")";
                    Console.SetCursorPosition(locationX + 27, inventoryIndex);
                    Console.Write(shopper.products[i].statClass);
                    Console.SetCursorPosition(locationX + 36 - statPoint.Length, inventoryIndex);
                    Console.Write(statPoint);
                }

                Console.SetCursorPosition(locationX + 37, inventoryIndex);
                Console.Write("|");

                // 장비 가격 / 구매 여부 적기
                if (shopper.products[i].isSold != true)
                {
                    price = shopper.products[i].price + " G";
                    Console.SetCursorPosition(locationX + 49 - price.Length, inventoryIndex);
                    Console.Write(price);
                }
                else
                {
                    price = "구매 완료";
                    Console.SetCursorPosition(locationX + 45 - price.Length, inventoryIndex);
                    Console.Write(price);
                }
                inventoryIndex++;
            }
        }

        // 던전 창 (고양이) 그리기
        public void DrawCatPanel(int posX, int posY)
        {
            Console.SetCursorPosition(posX + 4, posY);
            Console.Write("༺═━━━━━━━━ Cat ━━━━━━━━━═༻");

            DrawCat(posX + 9, posY + 5);
            Console.SetCursorPosition(posX + 4, posY + 15);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━═༻");
        }

        // 던전 창 (햄스터) 그리기
        public void DrawHamsterPanel(int posX, int posY)
        {
            Console.SetCursorPosition(posX + 4, posY);
            Console.Write("༺═━━━━━━━ Hamster ━━━━━━━═༻");

            DrawHamster(posX + 6, posY + 5);

            Console.SetCursorPosition(posX + 5, posY + 15);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━═༻");
        }

        // 던전 창 (드래곤) 그리기
        public void DrawDragonPanel(int posX, int posY)
        {
            Console.SetCursorPosition(posX + 4, posY);
            Console.Write("༺═━━━━━━━ Dragon ━━━━━━━═༻");

            DrawDragon(posX, posY + 1);
            Console.SetCursorPosition(posX + 4, posY + 14);
            Console.SetCursorPosition(posX + 4, posY + 15);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━━━━═༻");
        }

        // 플레이어 이미지를 좌측 패널에 그리기
        public void DrawPlayerPanel(Player player)
        {
            string playerMainInfo = "Lv. " + player.level + "   " + player.job;
            int playerMainInfoLength = playerMainInfo.Length;

            Console.SetCursorPosition(
                (infoLongPanelWidth - playerMainInfoLength) / 2,
                canvasHeight - 5
            );
            Console.Write(playerMainInfo);

            Console.SetCursorPosition(5, 2);
            Console.Write("༺═━━━━━━ Player ━━━━━═༻");
            Console.SetCursorPosition(5, canvasHeight - 3);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━═༻");

            for (int i = 1; i < canvasHeight - 1; i++)
            {
                Console.SetCursorPosition(infoLongPanelWidth, i);
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

        // 햄스터 그리기
        void DrawHamster(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write("          /)─―-/)");
            Console.SetCursorPosition(posX, posY + 1);
            Console.Write("      _／        ＼");
            Console.SetCursorPosition(posX, posY + 2);
            Console.Write("  @／        ●    ●丶");
            Console.SetCursorPosition(posX, posY + 3);
            Console.Write("  ｜              ▼  |");
            Console.SetCursorPosition(posX, posY + 4);
            Console.Write("  ｜              亠ノ");
            Console.SetCursorPosition(posX, posY + 5);
            Console.Write("   U￣U￣￣￣U￣￣U");
        }

        // 상점 주인 이미지를 좌측 패널에 그리기
        public void DrawShopperPanel()
        {
            Console.SetCursorPosition(5, 2);
            Console.Write("༺═━━━━ 상점 주인 ━━━━═༻");
            Console.SetCursorPosition(5, canvasHeight - 3);
            Console.Write("༺═━━━━━━━━━━━━━━━━━━━═༻");

            for (int i = 1; i < canvasHeight - 1; i++)
            {
                Console.SetCursorPosition(33, i);
                Console.Write("║");
            }

            DrawShopper(7, 7);
        }

        // 고양이 그리기
        void DrawCat(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write("        ∧,,      ");
            Console.SetCursorPosition(posX, posY + 1);
            Console.Write("     ヾ ｀. ､`フ");
            Console.SetCursorPosition(posX, posY + 2);
            Console.Write("   (,｀'´ヽ､､ﾂﾞ");
            Console.SetCursorPosition(posX, posY + 3);
            Console.Write("(ヽｖ'　　　`''ﾞつ");
            Console.SetCursorPosition(posX, posY + 4);
            Console.Write(" ,ゝ　 ⌒`ｙ'''´");
            Console.SetCursorPosition(posX, posY + 5);
            Console.Write("（ (´＾ヽこつ");
            Console.SetCursorPosition(posX, posY + 6);
            Console.Write("  ) )");
            Console.SetCursorPosition(posX, posY + 7);
            Console.Write(" (ノ");
        }

        // 상점 주인 그리기
        void DrawShopper(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write("   __[ 상  점 ]__");
            Console.SetCursorPosition(posX, posY + 1);
            Console.Write("  /＼＼＼＼＼＼＼＼");
            Console.SetCursorPosition(posX, posY + 2);
            Console.Write(" //┏＼＼＼＼＼＼＼＼");
            Console.SetCursorPosition(posX, posY + 3);
            Console.Write("// 三 \\Lﾘﾘﾘﾘﾘﾘﾘﾘﾘﾘﾘﾘ｣");
            Console.SetCursorPosition(posX, posY + 4);
            Console.Write("|{ﾆ영ﾆ}|　∧__∧　 　|");
            Console.SetCursorPosition(posX, posY + 5);
            Console.Write("|{ﾆ업ﾆ}| (´･ω･)∬∬　|");
            Console.SetCursorPosition(posX, posY + 6);
            Console.Write("|{ﾆ중ﾆ}| (つ┌───┐　|");
            Console.SetCursorPosition(posX, posY + 7);
            Console.Write("|| 三 |Γ￣￣￣￣￣￣|");
            Console.SetCursorPosition(posX, posY + 8);
            Console.Write("||┗┛┗┛|　　　　　　 |");
        }

        // 마을 그리기
        public void DrawTown()
        {
            for (int i = 1; i <= 11; i++)
            {
                for (int j = 1; j <= 97; j += 2)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write("　");
                }
            }

            Console.SetCursorPosition(2, 9);
            Console.Write("  _Π_______");
            Console.SetCursorPosition(2, 10);
            Console.Write(" /______/~~\\");
            Console.SetCursorPosition(2, 11);
            Console.Write("｜田 田｜門｜");

            Console.SetCursorPosition(15, 9);
            Console.Write("  _Π_______");
            Console.SetCursorPosition(15, 10);
            Console.Write(" /______/~~\\");
            Console.SetCursorPosition(15, 11);
            Console.Write("｜田 田｜門｜");

            Console.SetCursorPosition(49, 9);
            Console.Write("  _Π_______");
            Console.SetCursorPosition(49, 10);
            Console.Write(" /______/~~\\");
            Console.SetCursorPosition(49, 11);
            Console.Write("｜田 田｜門｜");
        }

        // 드래곤 그리기
        public void DrawDragon(int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(" <>=======()");
            Console.SetCursorPosition(posX, posY + 1);
            Console.Write("(/\\___   /|\\\\          ()=========="); // <>_
            Console.SetCursorPosition(posX, posY + 2);
            Console.Write("      \\_/ | \\\\        //|\\   ______"); // / \\)
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
            // Console.SetCursorPosition(posX, posY + 14);
            // Console.Write("                 '------'");
            Console.SetCursorPosition(0, 21);
        }
    }
}
