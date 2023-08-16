using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;

            Canvas canvas = new Canvas();
            Snake snake = new Snake();
            Food food = new Food();

            while (!finished)
            {
                try
                {
                    // 캔버스 그리기
                    canvas.DrawCanvas();
                    // 뱀 입력 받기
                    snake.Input();
                    // 음식 배치하기
                    food.DrawFood();
                    // 뱀 그리기
                    snake.DrawSnake();
                    // 뱀 움직이기
                    snake.MoveSnake();
                    // 음식먹기
                    snake.EatFood(food.foodPosition, food);
                    // 자기 자신과 충돌 시
                    snake.ConflictWithItself();
                    // 벽과 충돌 시
                    snake.ConflictWithWall(canvas);
                }
                catch (GameOver e)
                {
                    Console.Clear();
                    Console.Write(e.Message);
                    finished = true;
                }
            }
        }
    }

    public class Snake
    {
        // 입력 받은 키 정보 가져오기 위해 ConsoleKeyInfo 변수 만들어주기
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

        char key = 'w'; // 입력 받은 키 정보를 담을 변수 key
        char dir = 'w'; // 방향 정보를 담을 변수 dir

        // 뱀의 몸 정보를 담아주기 위해 Position 값을 가지는 List 만들기
        List<Position> snakeBody;

        public int x { get; set; }
        public int y { get; set; }

        public Snake()
        {
            // 뱀 생성 시 20, 20으로 초기 위치값 지정
            x = 20;
            y = 20;

            snakeBody = new List<Position>();

            // snakeBody List에 Position 값 추가
            snakeBody.Add(new Position(x, y));
        }

        public void DrawSnake()
        {
            // 뱀 그리기
            foreach (Position pos in snakeBody)
            {
                Console.SetCursorPosition(pos.x, pos.y);
                Console.Write("@");
            }
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);

                key = keyInfo.KeyChar;
            }
        }

        // 뱀 움직일 방향 고정
        private void Direction()
        {
            // 위쪽 키 입력 & 아래쪽 방향이 아니라면
            if (key == 'w' && dir != 'd')
            {
                dir = 'u';
            }
            // 아래쪽 키 입력 & 위쪽 방향이 아니라면
            else if (key == 's' && dir != 'u')
            {
                dir = 'd';
            }
            // 왼쪽 키 입력 & 오른쪽 방향이 아니라면
            else if (key == 'a' && dir != 'r')
            {
                dir = 'l';
            }
            // 오른쪽 키 입력 & 왼쪽 방향이 아니라면
            else if (key == 'd' && dir != 'l')
            {
                dir = 'r';
            }
        }

        // 뱀 움직이기
        public void MoveSnake()
        {
            Direction();

            if (dir == 'u')
            {
                y--;
            }
            else if (dir == 'd')
            {
                y++;
            }
            else if (dir == 'l')
            {
                x--;
            }
            else if (dir == 'r')
            {
                x++;
            }

            // 다음 위치를 List에 추가하고
            snakeBody.Add(new Position(x, y));
            // 맨 마지막 리스트 요소 제거
            snakeBody.RemoveAt(0);

            Thread.Sleep(100);
        }

        // 음식 먹기
        public void EatFood(Position foodPosition, Food food)
        {
            // 뱀의 머리 위치 가져오기
            Position head = snakeBody[snakeBody.Count - 1];

            // 뱀 머리 위치가 음식의 위치와 일치한다면
            if (head.x == foodPosition.x && head.y == foodPosition.y)
            {
                // 현 위치 값을 가지는 새 Position 값 List에 추가
                snakeBody.Add(new Position(x, y));
                // 음식 - 다음 위치 그리기
                food.DrawNextFood();
            }
        }

        // 자신과의 충돌 여부
        public void ConflictWithItself()
        {
            // 뱀의 머리 위치 가져오기
            Position head = snakeBody[snakeBody.Count - 1];

            for (int i = 0; i < snakeBody.Count - 2; i++)
            {
                Position body = snakeBody[i];
                if (head.x == body.x && head.y == body.y)
                {
                    throw new GameOver("You Lose");
                }
            }
        }

        // 벽과의 충돌 여부
        public void ConflictWithWall(Canvas canvas)
        {
            // 뱀의 머리 위치 가져오기
            Position head = snakeBody[snakeBody.Count - 1];

            if (
                !(0 <= head.x && head.x <= canvas.Width)
                || !((0 <= head.y && head.y <= canvas.Height))
            )
            {
                throw new GameOver("You Lose");
            }
        }
    }

    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position() { }
    }

    // 캔버스 그리기
    public class Canvas
    {
        // 캔버스 가로
        public int Width { get; set; }

        // 캔버스 세로
        public int Height { get; set; }

        public Canvas()
        {
            Width = 100;
            Height = 25;
            Console.CursorVisible = false;
        }

        public void DrawCanvas()
        {
            // 콘솔창 Clear
            Console.Clear();

            // 상하 벽 그리기
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, Height - 1);
                Console.Write("#");
            }
            // 좌우 벽 그리기
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(Width - 1, i);
                Console.Write("#");
            }
        }
    }

    public class Food
    {
        public Position foodPosition = new Position();

        Random random = new Random();
        Canvas canvas = new Canvas();

        public Food()
        {
            foodPosition.x = random.Next(1, canvas.Width - 1);
            foodPosition.y = random.Next(1, canvas.Height - 1);
        }

        public void DrawFood()
        {
            Console.Write("Food Position x {0} y {1}", foodPosition.x, foodPosition.y);
            Console.SetCursorPosition(foodPosition.x, foodPosition.y);
            Console.Write("*");
        }

        public void DrawNextFood()
        {
            foodPosition.x = random.Next(5, canvas.Width);
            foodPosition.y = random.Next(5, canvas.Height);
        }
    }

    public class GameOver : ApplicationException
    {
        public GameOver(string message)
            : base(message) { }
    }
}
