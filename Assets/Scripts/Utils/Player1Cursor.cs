using UnityEngine;

public class Player1Cursor : Cursor
{
    private void Update()
    {
        if (isSelect == false)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                CursorDirection(Direction.Up);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                CursorDirection(Direction.Left);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                CursorDirection(Direction.Right);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                CursorDirection(Direction.Down);
            }
        }
    }
}
