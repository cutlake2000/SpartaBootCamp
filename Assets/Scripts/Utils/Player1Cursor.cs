using UnityEngine;

public class Player1Cursor : SelectCursor
{
    // WASD Ű �Է� �޾Ƽ� CursorDirection �޼��� ȣ��
    private void Update()
    {
        // ���� �÷��̾� ����⸦ �������� �ʾҴٸ�
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
