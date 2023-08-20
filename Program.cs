using System;
using System.Collections.Generic;
using System.Threading;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackJack blackJack = new BlackJack();

            blackJack.Run();
        }
    }

    public class BlackJack
    {
        GameManager gameManager = new GameManager();
        Canvas canvas = new Canvas();
        UI ui = new UI();
        GameFlag gameFlag = new GameFlag();

        public void Run()
        {
            gameFlag = GameFlag.StartGame;

            do
            {
                Console.Clear();

                ui.PanelUI();
                canvas.DrawCanvas();

                if (gameFlag == GameFlag.StartGame)
                {
                    ui.DrawStartUI();

                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        gameFlag = GameFlag.InGame;
                    }
                }

                gameFlag = gameManager.Run();
            } while (gameFlag == GameFlag.RestartGame);

            Thread.Sleep(50000);
        }
    }

    public class GameManager
    {
        Player player = new Player(0, 2, 13);
        Dealer dealer = new Dealer(0, 2, 3);
        Deck deck = new Deck();
        UI ui = new UI();
        GameFlag gameFlag = new GameFlag();
        InGameTurn inGameTurn = new InGameTurn();

        public GameFlag Run()
        {
            inGameTurn = InGameTurn.DealerShuffleTurn;
            ui.DrawInGameUI(inGameTurn);
            Thread.Sleep(500);

            inGameTurn = InGameTurn.DealerDrawTurn;
            ui.DrawInGameUI(inGameTurn);
            Thread.Sleep(500);

            SetEachCards();

            if (PlayerTurn() == GameFlag.InGame)
            {
                gameFlag = DealerTurn();
            }

            if (gameFlag == GameFlag.BlackJack)
            {
                Thread.Sleep(1000);
                ui.DrawBlackJackUI();
            }
            else if ((gameFlag == GameFlag.Burst) || (gameFlag == GameFlag.PlayerLose))
            {
                Thread.Sleep(1000);
                ui.DrawYouLoseUI();
            }
            else if (gameFlag == GameFlag.PlayerWin)
            {
                Thread.Sleep(1000);
                ui.DrawYouWinUI();
            }

            Thread.Sleep(1000);

            return gameFlag;
        }

        void SetEachCards()
        {
            for (int i = 0; i < 2; i++)
            {
                dealer.AddCardToHand(deck.DrawCard());
                Thread.Sleep(500);
                player.AddCardToHand(deck.DrawCard());
                Thread.Sleep(500);
            }
        }

        GameFlag DealerTurn()
        {
            gameFlag = GameFlag.InGame;
            InGameTurn inGameTurn = InGameTurn.DealerDrawTurn;

            int dealerScore = dealer.ReturnScore();
            int playerScore = player.ReturnScore();

            Thread.Sleep(500);

            ui.DrawInGameUI(inGameTurn);
            ui.DrawPlayerScore(playerScore);
            ui.DrawCardOnCanvas(dealer.cardList[0], 2, 3, false);
            ui.DrawCardOnCanvas(dealer.cardList[1], 9, 3, false);

            Thread.Sleep(500);

            do
            {
                ui.DrawDealerScore(true, dealerScore);

                if (dealer.ReturnScore() >= 17)
                {
                    Thread.Sleep(500);
                    ui.DrawDealerScore(true, dealerScore);
                    ui.DrawInGameUI(inGameTurn);
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    Thread.Sleep(500);
                    dealer.AddCardToHand(deck.DrawCard());
                    ui.DrawDealerScore(true, dealerScore);
                    ui.DrawInGameUI(inGameTurn);
                    Thread.Sleep(1000);
                }

                dealerScore = dealer.ReturnScore();
            } while (dealerScore >= 17);

            if (dealerScore > 21)
            {
                gameFlag = GameFlag.PlayerWin;
            }
            else if (dealerScore == 21)
            {
                gameFlag = GameFlag.PlayerLose;
            }
            else
            {
                if (Math.Abs(dealerScore - 21) > Math.Abs(playerScore - 21))
                {
                    gameFlag = GameFlag.PlayerWin;
                }
                else
                {
                    gameFlag = GameFlag.PlayerLose;
                }
            }
            return gameFlag;
        }

        GameFlag PlayerTurn()
        {
            int playerScore = 0;
            gameFlag = GameFlag.InGame;
            inGameTurn = InGameTurn.PlayerTurn;
            ui.DrawDealerScore(false, 0);
            ui.DrawPlayerScore(player.ReturnScore());

            char key = ' ';

            do
            {
                ui.DrawInGameUI(inGameTurn);

                key = Console.ReadKey().KeyChar;

                if (key == '1')
                {
                    player.AddCardToHand(deck.DrawCard());
                    ui.DrawPlayerScore(player.ReturnScore());
                    Thread.Sleep(1000);
                    ui.DrawInGameUI(inGameTurn);
                }
                else
                    break;

                playerScore = player.ReturnScore();
            } while (playerScore < 21);

            if (playerScore == 21)
            {
                inGameTurn = InGameTurn.PlayerTurnBlackJack;
                gameFlag = GameFlag.BlackJack;
                ui.DrawInGameUI(inGameTurn);
            }
            else if (playerScore > 21)
            {
                inGameTurn = InGameTurn.PlayerTurnBurst;
                gameFlag = GameFlag.Burst;
                ui.DrawInGameUI(inGameTurn);
            }

            return gameFlag;
        }
    }

    public class Player
    {
        public UI ui = new UI();
        public List<Card> cardList;

        public int cardScore;
        public int cardIndex;
        public int cardLocationX;
        public int cardLocationY;

        int tmp = 0;

        public Player(int index, int locationX, int locationY)
        {
            this.cardList = new List<Card>();
            this.cardScore = 0;
            this.cardIndex = index;
            this.cardLocationX = locationX;
            this.cardLocationY = locationY;
        }

        public int ReturnScore()
        {
            cardScore = 0;

            foreach (Card card in cardList)
            {
                cardScore += card.GetCardValue();
            }

            return cardScore;
        }

        public virtual void AddCardToHand(Card card)
        {
            cardList.Add(card);

            ui.DrawCardOnCanvas(cardList[cardIndex++], cardLocationX, cardLocationY, false);

            cardLocationX += 7;
        }
    }

    public class Dealer : Player
    {
        public Dealer(int index, int locationX, int locationY)
            : base(index, locationX, locationY) { }

        public override void AddCardToHand(Card card)
        {
            cardList.Add(card);

            if (cardList.Count <= 2)
            {
                ui.DrawCardOnCanvas(cardList[cardIndex++], cardLocationX, cardLocationY, true);
            }
            else
            {
                ui.DrawCardOnCanvas(cardList[cardIndex++], cardLocationX, cardLocationY, false);
            }

            cardLocationX += 7;
        }
    }

    public class Canvas
    {
        public int width { get; set; }
        public int height { get; set; }

        public Canvas()
        {
            this.width = 66;
            this.height = 21;
        }

        public void DrawCanvas()
        {
            Console.CursorVisible = false;

            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("*");
                Console.SetCursorPosition(i, height - 1);
                Console.Write("*");
                Console.SetCursorPosition(i, height / 2);
                Console.Write("*");
            }

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("*");
                Console.SetCursorPosition(width - 1, i);
                Console.Write("*");
            }
        }
    }

    public class UI
    {
        int gap = 2;
        Canvas canvas = new Canvas();

        public void DrawPlayerScore(int score)
        {
            Console.SetCursorPosition(gap, 19);
            Console.Write("Score >> {0}     ", score);
        }

        public void DrawDealerScore(bool isShow, int score)
        {
            if (isShow == true)
            {
                Console.SetCursorPosition(gap, 9);
                Console.Write("Score >> {0}     ", score);
            }
            else if (isShow == false)
            {
                Console.SetCursorPosition(gap, 9);
                Console.Write("Score >> ?       ");
            }
        }

        public void PanelUI()
        {
            Console.SetCursorPosition(gap, 1);
            Console.Write("[Dealer]");
            Console.SetCursorPosition(gap, 11);
            Console.Write("[Player]");
        }

        public void DrawStartUI()
        {
            Console.SetCursorPosition(canvas.width + gap, 11);
            Console.Write("Press \"Any Key\" to start        ");
            Console.SetCursorPosition(canvas.width + gap, 12);
            Console.Write("> ");
        }

        public void DrawBlackJackUI()
        {
            Console.SetCursorPosition((canvas.width - 64) / 2, 6);

            for (int i = 0; i < canvas.width - 1; i++)
            {
                Console.Write("*");
            }

            for (int i = 1; i < canvas.width - 1; i++)
            {
                for (int j = 7; j <= 13; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition((canvas.width - 64) / 2, 7);
            Console.Write("______  _       ___   _____  _   __   ___   ___   _____  _   __");
            Console.SetCursorPosition((canvas.width - 64) / 2, 8);
            Console.Write("| ___ \\| |     / _ \\ /  __ \\| | / /  |_  | / _ \\ /  __ \\| | / /");
            Console.SetCursorPosition((canvas.width - 64) / 2, 9);
            Console.Write("| |_/ /| |    / /_\\ \\| /  \\/| |/ /     | |/ /_\\ \\| /  \\/| |/ / ");
            Console.SetCursorPosition((canvas.width - 64) / 2, 10);
            Console.Write("| ___ \\| |    |  _  || |    |    \\     | ||  _  || |    |    \\ ");
            Console.SetCursorPosition((canvas.width - 64) / 2, 11);
            Console.Write(
                "| |_/ /| |____| | | || \\__/\\| |\\  \\/\\__/ /| | | || \\__/\\| |\\  \\"
            );
            Console.SetCursorPosition((canvas.width - 64) / 2, 12);
            Console.Write(
                "\\____/ \\_____/\\_| |_/ \\____/\\_| \\_/\\____/ \\_| |_/ \\____/\\_| \\_/"
            );
            Console.SetCursorPosition((canvas.width - 64) / 2, 14);

            for (int i = 0; i < canvas.width - 1; i++)
            {
                Console.Write("*");
            }
        }

        public void DrawYouLoseUI()
        {
            Console.SetCursorPosition((canvas.width - 64) / 2, 6);

            for (int i = 0; i < canvas.width - 1; i++)
            {
                Console.Write("*");
            }

            for (int i = 1; i < canvas.width - 1; i++)
            {
                for (int j = 7; j <= 13; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition((canvas.width - 48) / 2, 7);
            Console.Write("__   __                 _                       ");
            Console.SetCursorPosition((canvas.width - 48) / 2, 8);
            Console.Write("\\ \\ / /                | |                      ");
            Console.SetCursorPosition((canvas.width - 48) / 2, 9);
            Console.Write(" \\ V /   ___   _   _   | |      ___   ___   ___ ");
            Console.SetCursorPosition((canvas.width - 48) / 2, 10);
            Console.Write("  \\ /   / _ \\ | | | |  | |     / _ \\ / __| / _ \\");
            Console.SetCursorPosition((canvas.width - 48) / 2, 11);
            Console.Write("  | |  | (_) || |_| |  | |____| (_) |\\__ \\|  __/");
            Console.SetCursorPosition((canvas.width - 48) / 2, 12);
            Console.Write("  \\_/   \\___/  \\__,_|  \\_____/ \\___/ |___/ \\___|");
            Console.SetCursorPosition((canvas.width - 64) / 2, 14);

            for (int i = 0; i < canvas.width - 1; i++)
            {
                Console.Write("*");
            }
        }

        public void DrawYouWinUI()
        {
            Console.SetCursorPosition((canvas.width - 64) / 2, 6);

            for (int i = 0; i < canvas.width - 1; i++)
            {
                Console.Write("*");
            }

            for (int i = 1; i < canvas.width - 1; i++)
            {
                for (int j = 7; j <= 13; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition((canvas.width - 41) / 2, 7);
            Console.Write("__   __                 _    _  _        ");
            Console.SetCursorPosition((canvas.width - 41) / 2, 8);
            Console.Write("\\ \\ / /                | |  | |(_)       ");
            Console.SetCursorPosition((canvas.width - 41) / 2, 9);
            Console.Write(" \\ V /   ___   _   _   | |  | | _  _ __  ");
            Console.SetCursorPosition((canvas.width - 41) / 2, 10);
            Console.Write("  \\ /   / _ \\ | | | |  | |/\\| || || '_ \\ ");
            Console.SetCursorPosition((canvas.width - 41) / 2, 11);
            Console.Write("  | |  | (_) || |_| |  \\  /\\  /| || | | |");
            Console.SetCursorPosition((canvas.width - 41) / 2, 12);
            Console.Write("  \\_/   \\___/  \\__,_|   \\/  \\/ |_||_| |_|");

            Console.SetCursorPosition((canvas.width - 64) / 2, 14);
            for (int i = 0; i < canvas.width - 1; i++)
            {
                Console.Write("*");
            }
        }

        public void DrawYouDrawUI()
        {
            Console.SetCursorPosition((canvas.width - 64) / 2, 6);

            for (int i = 0; i < canvas.width - 1; i++)
            {
                Console.Write("*");
            }

            for (int i = 1; i < canvas.width - 1; i++)
            {
                for (int j = 7; j <= 13; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition((canvas.width - 53) / 2, 7);
            Console.Write("__   __                ______                        ");
            Console.SetCursorPosition((canvas.width - 53) / 2, 8);
            Console.Write("\\ \\ / /                |  _  \\                       ");
            Console.SetCursorPosition((canvas.width - 53) / 2, 9);
            Console.Write(" \\ V /   ___   _   _   | | | | _ __   __ _ __      __");
            Console.SetCursorPosition((canvas.width - 53) / 2, 10);
            Console.Write("  \\ /   / _ \\ | | | |  | | | || '__| / _` |\\ \\ /\\ / /");
            Console.SetCursorPosition((canvas.width - 53) / 2, 11);
            Console.Write("  | |  | (_) || |_| |  | |/ / | |   | (_| | \\ V  V / ");
            Console.SetCursorPosition((canvas.width - 53) / 2, 12);
            Console.Write("  | |  | (_) || |_| |  | |/ / | |   | (_| | \\ V  V / ");
            Console.SetCursorPosition((canvas.width - 64) / 2, 14);

            for (int i = 0; i < canvas.width - 1; i++)
            {
                Console.Write("*");
            }
        }

        public void DrawInGameUI(InGameTurn inGameTurn)
        {
            if (inGameTurn == InGameTurn.DealerShuffleTurn)
            {
                Console.SetCursorPosition(canvas.width + gap, 11);
                Console.Write("# Dealer's Turn               ");
                Console.SetCursorPosition(canvas.width + gap, 12);
                Console.Write("> Shuffling deck              ");
                Console.SetCursorPosition(canvas.width + gap, 13);
                Console.Write("                              ");
                Console.SetCursorPosition(canvas.width + gap, 14);
                Console.Write("                              ");
            }
            else if (inGameTurn == InGameTurn.DealerDrawTurn)
            {
                Console.SetCursorPosition(canvas.width + gap, 11);
                Console.Write("# Dealer's Turn               ");
                Console.SetCursorPosition(canvas.width + gap, 12);
                Console.Write("> Draw Deck                   ");
                Console.SetCursorPosition(canvas.width + gap, 13);
                Console.Write("                              ");
                Console.SetCursorPosition(canvas.width + gap, 14);
                Console.Write("                              ");
            }
            else if (inGameTurn == InGameTurn.PlayerTurn)
            {
                Console.SetCursorPosition(canvas.width + gap, 11);
                Console.Write("# Player's Turn               ");
                Console.SetCursorPosition(canvas.width + gap, 12);
                Console.Write("1. Hit                        ");
                Console.SetCursorPosition(canvas.width + gap, 13);
                Console.Write("2. Stand                      ");
                Console.SetCursorPosition(canvas.width + gap, 14);
                Console.Write("> ");
            }
            else if (inGameTurn == InGameTurn.PlayerTurnBurst)
            {
                Console.SetCursorPosition(canvas.width + gap, 11);
                Console.Write("# Player's Turn               ");
                Console.SetCursorPosition(canvas.width + gap, 12);
                Console.Write("> Burst!!                     ");
                Console.SetCursorPosition(canvas.width + gap, 13);
                Console.Write("                              ");
                Console.SetCursorPosition(canvas.width + gap, 14);
                Console.Write("                              ");
            }
            else if (inGameTurn == InGameTurn.PlayerTurnBlackJack)
            {
                Console.SetCursorPosition(canvas.width + gap, 11);
                Console.Write("# Player's Turn               ");
                Console.SetCursorPosition(canvas.width + gap, 12);
                Console.Write("> BlackJack!!                 ");
                Console.SetCursorPosition(canvas.width + gap, 13);
                Console.Write("                              ");
                Console.SetCursorPosition(canvas.width + gap, 14);
                Console.Write("                              ");
            }
        }

        public void DrawCardOnCanvas(Card card, int locationX, int locationY, bool isFlip)
        {
            ReturnCardInfo returnCardInfo = new ReturnCardInfo();

            for (int i = locationX; i <= locationX + 5; i++)
            {
                for (int j = locationY; j <= locationY + 4; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            for (int i = locationX; i <= locationX + 5; i++)
            {
                for (int j = locationY; j <= locationY + 4; j++)
                {
                    if (
                        ((i == locationX) && (j == locationY))
                        || ((i == locationX + 5) && (j == locationY))
                        || ((i == locationX) && (j == locationY + 4))
                        || ((i == locationX + 5) && (j == locationY + 4))
                    )
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("·");
                    }
                    else if ((j == locationY) || (j == locationY + 4))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("-");
                    }
                    else if ((i == locationX) || (i == locationX + 5))
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("|");
                    }
                }
            }

            if (isFlip == true)
            {
                for (int i = locationX + 1; i <= locationX + 4; i++)
                {
                    for (int j = locationY + 1; j <= locationY + 3; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("~");
                    }
                }
            }
            else
            {
                Console.SetCursorPosition(locationX + 2, locationY + 1);
                Console.Write(returnCardInfo.ReturnCardSuit(card.cardSuit));

                if (returnCardInfo.ReturnCardNumberToInt(card.cardNumber) >= 10)
                {
                    Console.SetCursorPosition(locationX + 2, locationY + 3);
                }
                else
                {
                    Console.SetCursorPosition(locationX + 3, locationY + 3);
                }

                Console.Write(returnCardInfo.ReturnCardNumberToString(card.cardNumber));
            }
        }

        public void DrawGameEndUI()
        {
            Console.SetCursorPosition(62, 11);
            Console.Write("1. New Game");
            Console.SetCursorPosition(62, 12);
            Console.Write("2. Quit Game");
            Console.SetCursorPosition(62, 13);
            Console.Write("> ");
        }
    }

    public class ReturnCardInfo
    {
        public char ReturnCardSuit(CardSuit cardSuit)
        {
            if (cardSuit == CardSuit.Heart)
                return '♥';
            else if (cardSuit == CardSuit.Spade)
                return '♠';
            else if (cardSuit == CardSuit.Club)
                return '♣';
            else if (cardSuit == CardSuit.Diamond)
                return '◆';
            else
                return ' ';
        }

        public int ReturnCardNumberToInt(CardNumber cardNumber)
        {
            if (cardNumber == CardNumber.Ace)
                return 1;
            else if (cardNumber == CardNumber.Two)
                return 2;
            else if (cardNumber == CardNumber.Three)
                return 3;
            else if (cardNumber == CardNumber.Four)
                return 4;
            else if (cardNumber == CardNumber.Five)
                return 5;
            else if (cardNumber == CardNumber.Six)
                return 6;
            else if (cardNumber == CardNumber.Seven)
                return 7;
            else if (cardNumber == CardNumber.Eight)
                return 9;
            else if (cardNumber == CardNumber.Nine)
                return 9;
            else
                return 10;
        }

        public String ReturnCardNumberToString(CardNumber cardNumber)
        {
            if (cardNumber == CardNumber.Ace)
                return "1";
            else if (cardNumber == CardNumber.Two)
                return "2";
            else if (cardNumber == CardNumber.Three)
                return "3";
            else if (cardNumber == CardNumber.Four)
                return "4";
            else if (cardNumber == CardNumber.Five)
                return "5";
            else if (cardNumber == CardNumber.Six)
                return "6";
            else if (cardNumber == CardNumber.Seven)
                return "7";
            else if (cardNumber == CardNumber.Eight)
                return "8";
            else if (cardNumber == CardNumber.Nine)
                return "9";
            else if (cardNumber == CardNumber.Ten)
                return "10";
            else if (cardNumber == CardNumber.Jack)
                return "J";
            else if (cardNumber == CardNumber.Queen)
                return "Q";
            else if (cardNumber == CardNumber.King)
                return "K";
            else
                return null;
        }
    }

    public class Card
    {
        ReturnCardInfo returnCardInfo = new ReturnCardInfo();

        public CardSuit cardSuit { get; private set; }
        public CardNumber cardNumber { get; private set; }

        public Card(CardSuit cs, CardNumber cn)
        {
            cardSuit = cs;
            cardNumber = cn;
        }

        public int GetCardValue()
        {
            return returnCardInfo.ReturnCardNumberToInt(cardNumber);
        }

        public string GetCardInfo()
        {
            return $"{cardNumber} of {cardSuit}";
        }
    }

    public class Deck
    {
        List<Card> cardList = new List<Card>();

        int index = 0;

        public Deck()
        {
            foreach (CardSuit cs in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardNumber cn in Enum.GetValues(typeof(CardNumber)))
                {
                    cardList.Add(new Card(cs, cn));
                }

                ShuffleDeck();
            }
        }

        void ShuffleDeck()
        {
            Random random = new Random();

            for (int i = 0; i < cardList.Count; i++)
            {
                int j = random.Next(i, cardList.Count);
                Card temp = cardList[i];
                cardList[i] = cardList[j];
                cardList[j] = temp;
            }
        }

        public Card DrawCard()
        {
            Card card = cardList[0];
            cardList.RemoveAt(0);

            return card;
        }
    }

    public enum PlayerChoice
    {
        Stand,
        Hit
    }

    public enum InGameTurn
    {
        PlayerTurn,
        DealerShuffleTurn,
        DealerDrawTurn,
        PlayerTurnBurst,
        PlayerTurnBlackJack
    }

    public enum CardSuit
    {
        Spade,
        Heart,
        Diamond,
        Club
    };

    public enum CardNumber
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    };

    public enum GameFlag
    {
        StartGame,
        InGame,
        Burst,
        BlackJack,
        PlayerWin,
        PlayerLose,
        PlayerDraw,
        RestartGame
    };
}
