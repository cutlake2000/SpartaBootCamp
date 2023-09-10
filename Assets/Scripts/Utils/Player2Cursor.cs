using UnityEngine;

public class Player2Cursor : Cursor
{
    // 방향키 입력 받아서 CursorDirection 메서드 호출
    private void Update()
    {
        // 플레이어 2 추가 여부 확인 && 아직 플레이어 비행기를 선택하지 않았다면
        if (SelectManager.instance.player[2] == true && isSelect == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CursorDirection(Direction.Up);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CursorDirection(Direction.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CursorDirection(Direction.Right);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CursorDirection(Direction.Down);
            }
        }
    }
}
