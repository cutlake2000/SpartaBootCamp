using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class SceneManager
    {
        public Inventory inventory = new Inventory();
        public Canvas canvas = new Canvas();
        public Message message = new Message();
        public Player player = new Player();

        // 타이틀 출력하는 메소드
        public void SetTitleScene()
        {
            canvas.DrawCanvasOutLine();
            canvas.DrawCanvasTitle();
            message.SetMessageInTitleScene();
        }

        // 첫 스테이지를 출력하는 메소드
        public void SetMainScene()
        {
            canvas.DrawCanvasOutLine();
            canvas.DrawMainMessagePanel(1, canvas.canvasWidth - 1, canvas.canvasHeight - 8);
            canvas.DrawTown(2, 2);
            message.SetMessageInFirstStage();
        }

        // 플레이어 상태창을 출력하는 메소드
        public void SetStatus()
        {
            canvas.DrawCanvasOutLine();
            canvas.DrawPlayerStatus(
                player.playerLevel,
                player.playerClass,
                player.playerAttack,
                player.playerDefence,
                player.playerHealth,
                player.playerGold
            );
            canvas.DrawPlayer(7, 4);
            canvas.DrawMainMessagePanel(34, canvas.canvasWidth - 2, canvas.canvasHeight - 6);
            message.SetMessageInPlayerStatusPanel();
        }

        // 플레이어 인벤토리를 출력하는 메소드
        public void SetInventory()
        {
            canvas.DrawCanvasOutLine();
            canvas.DrawDragon(20, 20);
        }

        // 상점을 출력하는 메소드
        public void SetShop() { }
    }
}
