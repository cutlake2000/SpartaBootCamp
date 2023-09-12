using UnityEngine;

public class Player2Cursor : SelectCursor
{
    // ����Ű �Է� �޾Ƽ� CursorDirection �޼��� ȣ��
    private void Update()
    {
        // �÷��̾� 2 �߰� ���� Ȯ�� && ���� �÷��̾� ����⸦ �������� �ʾҴٸ�
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
