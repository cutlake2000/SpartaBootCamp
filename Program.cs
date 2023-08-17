using System;
using System.Collections.Generic;

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
        Canvas canvas = new Canvas();
        UI ui = new UI();
        GameFlag gameFlag = new GameFlag();

        char key = ' ';

        public void Run()
        {
            gameFlag = GameFlag.StartGame;

            do
            {
                Console.Clear();

                ui.PanelUI();

                if (gameFlag == GameFlag.StartGame)
                {
                    ui.DrawStartUI();

                    if (Console.ReadKey() == ConsoleKey.Enter)
                    {
                        gameFlag = GameFlag.InGame;
                    }
                }
                else if (gameFlag == GameFlag.InGame)
                {
                    ui.DrawInGameUI();
                }
                else if (gameFlag == GameFlag.GameEnd)
                {
                    ui.DrawGameEndUI();
                }

                canvas.DrawCanvas();
            } while (gameFlag != GameFlag.GameEnd);

            Console.Write("Check");
        }
    }

    public class GameManager { }

    public class Canvas
    {
        public int width { get; set; }
        public int height { get; set; }

        public Canvas()
        {
            this.width = 50;
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
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

        public void PanelUI()
        {
            Console.SetCursorPosition(2, 1);
            Console.Write("[Dealer]");
            Console.SetCursorPosition(2, 11);
            Console.Write("[Player]");
        }

        public void DrawStartUI()
        {
            Console.SetCursorPosition(51, 11);
            Console.Write("Press \"Enter\" to start");
            Console.SetCursorPosition(51, 12);
            Console.Write("> ");
        }

        public void DrawInGameUI()
        {
            Console.SetCursorPosition(51, 11);
            Console.Write("1. Stand (카드를 받지 않습니다.)");
            Console.SetCursorPosition(51, 12);
            Console.Write("2. Hit (카드를 받습니다.)");
            Console.SetCursorPosition(51, 13);
            Console.Write("> ");
        }

        public void DrawGameEndUI()
        {
            Console.SetCursorPosition(51, 11);
            Console.Write("1. Stand (카드를 받지 않습니다.)");
            Console.SetCursorPosition(51, 12);
            Console.Write("2. Hit (카드를 받습니다.)");
            Console.SetCursorPosition(51, 13);
            Console.Write("> ");
        }
    }

    public class Card
    {
        public CardSuit cardSuit { get; private set; }
        public CardNumber cardNumber { get; private set; }

        public Card(CardSuit cs, CardNumber cn)
        {
            cardSuit = cs;
            cardNumber = cn;
        }

        public int GetCardValue()
        {
            if ((int)cardNumber == 0)
            {
                return 11;
            }
            else if (10 <= (int)cardNumber)
            {
                return 10;
            }
            else
            {
                return (int)cardNumber;
            }
        }

        public string GetCardInfo()
        {
            return $"{cardNumber} of {cardSuit}";
        }
    }

    public class Deck
    {
        List<Card> cardList = new List<Card>();

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

        Card DrawCard()
        {
            Card card = cardList[0];
            cardList.RemoveAt(0);

            return card;
        }
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
        GameEnd,
        RestartGame
    };
}
