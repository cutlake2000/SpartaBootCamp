using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class SceneManager
    {
        public Canvas canvas = new Canvas();
        public Message message = new Message();
        public Player player = new Player();

        // 타이틀 출력하는 메소드
        public void SetTitleScene()
        {
            canvas.DrawOutLine();
            canvas.DrawTitle();

            message.SetMessageInTitleScene();
        }

        // 메인 스테이지를 출력하는 메소드
        public void SetMainScene()
        {
            canvas.DrawOutLine();
            canvas.DrawMessagePanel(1, canvas.canvasWidth - 1, canvas.canvasHeight - 8);
            canvas.DrawTown(2, 2);

            message.SetMessageInFirstStage();
        }

        // 스탯씬을 출력하는 메소드
        public void SetStatusScene()
        {
            canvas.DrawOutLine();
            canvas.DrawPlayerPanel(player);
            canvas.DrawEquipmentPanel(player);
            canvas.DrawStatusPanel(player);
            canvas.DrawMessagePanel(
                canvas.infoLongPanelWidth + 1,
                canvas.canvasWidth - 2,
                canvas.canvasHeight - 6
            );

            message.SetMessageInPlayerStatusPanel();
        }

        // 인벤토리씬을 출력하는 메소드
        public void SetInventoryScene()
        {
            canvas.DrawOutLine();
            canvas.DrawPlayerPanel(player);
            canvas.DrawInventoryPanel(player);
            canvas.DrawMessagePanel(
                canvas.infoLongPanelWidth + 1,
                canvas.canvasWidth - 2,
                canvas.canvasHeight - 6
            );

            message.SetMessageInInventoryPanel();
        }

        // 장비 장착씬을 출력하는 메소드
        public void SetEquipWeaponScene()
        {
            int inventoryIndex;

            canvas.DrawOutLine();
            canvas.DrawPlayerPanel(player);
            canvas.DrawEquipWeaponPanel(player);
            canvas.DrawMessagePanel(
                canvas.infoLongPanelWidth + 1,
                canvas.canvasWidth - 2,
                canvas.canvasHeight - 6
            );
            message.SetMessageInEquipWeaponPanel();

            do
            {
                inventoryIndex = int.Parse(Console.ReadKey().KeyChar.ToString()) - 1;
                Console.Write(inventoryIndex);

                if (inventoryIndex > player.inventories.Count || inventoryIndex < 0)
                {
                    // Console.Write("Wrong!!!!!!");
                }
                else
                {
                    if (player.inventories[inventoryIndex].isEquiped == true)
                    {
                        player.inventories[inventoryIndex].isEquiped = false;
                    }
                    else
                    {
                        player.inventories[inventoryIndex].isEquiped = true;
                    }
                }

                canvas.DrawOutLine();
                canvas.DrawPlayerPanel(player);
                canvas.DrawEquipWeaponPanel(player);
                canvas.DrawMessagePanel(
                    canvas.infoLongPanelWidth + 1,
                    canvas.canvasWidth - 2,
                    canvas.canvasHeight - 6
                );
                message.SetMessageInEquipWeaponPanel();
            } while (Console.ReadKey().Key == ConsoleKey.D0);
        }

        // 상점을 출력하는 메소드
        public void SetShop() { }
    }
}
