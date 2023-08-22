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
        public Shopper shopper = new Shopper();

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
            canvas.DrawTown();

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
                canvas.canvasHeight - 5
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
                canvas.canvasHeight - 5
            );

            message.SetMessageInInventoryPanel();
        }

        // 장비 장착씬을 출력하는 메소드
        public void SetEquipWeaponScene()
        {
            int inventoryIndex;

            do
            {
                canvas.DrawOutLine();
                canvas.DrawPlayerPanel(player);
                canvas.DrawEquipWeaponPanel(player);
                canvas.DrawMessagePanel(
                    canvas.infoLongPanelWidth + 1,
                    canvas.canvasWidth - 2,
                    canvas.canvasHeight - 6
                );

                message.SetMessageInEquipWeaponPanel();

                inventoryIndex = Console.ReadKey().KeyChar - 48;

                Console.SetCursorPosition(38, canvas.canvasHeight - 3);

                if (0 <= inventoryIndex && inventoryIndex <= player.inventories.Count)
                {
                    if (inventoryIndex != 0)
                    {
                        if (player.inventories[inventoryIndex - 1].isEquiped == true)
                        {
                            player.inventories[inventoryIndex - 1].isEquiped = false;
                        }
                        else
                        {
                            player.inventories[inventoryIndex - 1].isEquiped = true;
                        }
                    }
                }
                else
                {
                    message.SetErrorMessageInEquipWeaponPanel();
                }
            } while (inventoryIndex != 0);
        }

        // 상점을 출력하는 메소드
        public void SetShopScene()
        {
            int productIndex;

            do
            {
                canvas.DrawOutLine();
                canvas.DrawShopperPanel();
                canvas.DrawShopPanel(player, shopper);
                canvas.DrawMessagePanel(
                    canvas.infoLongPanelWidth + 1,
                    canvas.canvasWidth - 2,
                    canvas.canvasHeight - 6
                );
                message.SetMessageInShopPanel();

                productIndex = Console.ReadKey().KeyChar - 48;

                Console.SetCursorPosition(38, canvas.canvasHeight - 3);

                if (0 <= productIndex && productIndex <= shopper.products.Count)
                {
                    if (productIndex != 0)
                    {
                        if (shopper.products[productIndex - 1].isSold == true)
                        {
                            message.SetErrorMessageInShopPanel();
                        }
                        else
                        {
                            if (shopper.products[productIndex - 1].price > player.gold) { }
                            else
                            {
                                player.Purchase(shopper.products[productIndex - 1].price);

                                shopper.products[productIndex - 1].isSold = true;

                                player.inventories.Add(
                                    new Inventory(
                                        false,
                                        shopper.products[productIndex - 1].name,
                                        shopper.products[productIndex - 1].statClass,
                                        shopper.products[productIndex - 1].statPoint,
                                        shopper.products[productIndex - 1].description
                                    )
                                );
                            }
                        }
                    }
                }
                else
                {
                    message.SetErrorMessageInEquipWeaponPanel();
                }
            } while (productIndex != 0);
        }
    }
}
