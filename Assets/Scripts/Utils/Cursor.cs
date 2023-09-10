using UnityEngine;

public class Cursor : MonoBehaviour
{
    private int pastCursorLocation; // 이전 커서 위치
    public int currentCursorLocation; // 현재 커서 위치
    protected bool isSelect; // 플레이어 비행기 확정 선택 여부
    private string playerAirplane; // 선택한 비행기 이름
    int airplanesCount; // 등록된 비행기 개수
    int airplanesRowCount; // 각 가로줄마다 위치하고 있는 비행기 개수

    private void Start()
    {
        InitCursor();
    }

    private void InitCursor()
    {
        airplanesCount = SelectManager.instance.airplanesCount; // SelectManager에 접근해서 비행기 개수 가져오기
        airplanesRowCount = airplanesCount / 2; // 가로줄마다 위치하고 있는 비행기 개수
        pastCursorLocation = -1; // 이전 커서 위치 -1로 초기화
        isSelect = false; // 선택 여부 초기화
    }

    // 커서 이동
    protected void CursorDirection(Direction direction)
    {
        // 이전 커서 위치 값을 현재 커서 위치 값으로 초기화
        pastCursorLocation = currentCursorLocation;

        // 이전 커서가 위치하고 있던 비행기 상태를 'Unselected'로 변경
        SelectManager.instance.airplanesStatus[pastCursorLocation] = SelectManager
            .Airplane
            .Unselected;

        switch (direction)
        {
            case Direction.Up:
                do
                {
                    currentCursorLocation -= airplanesRowCount;

                    if (currentCursorLocation < 0)
                    {
                        currentCursorLocation += airplanesCount;
                    }
                } while (
                    SelectManager.instance.airplanesStatus[currentCursorLocation]
                    != SelectManager.Airplane.Unselected
                );
                break;

            case Direction.Down:
                do
                {
                    currentCursorLocation += airplanesRowCount;

                    if ((airplanesCount - 1) < currentCursorLocation)
                    {
                        currentCursorLocation -= airplanesCount;
                    }
                } while (
                    SelectManager.instance.airplanesStatus[currentCursorLocation]
                    != SelectManager.Airplane.Unselected
                );
                break;

            case Direction.Left:
                do
                {
                    currentCursorLocation -= 1;

                    if (currentCursorLocation < 0)
                    {
                        currentCursorLocation += airplanesCount;
                    }
                } while (
                    SelectManager.instance.airplanesStatus[currentCursorLocation]
                    != SelectManager.Airplane.Unselected
                );
                break;

            case Direction.Right:
                do
                {
                    currentCursorLocation += 1;

                    if (airplanesCount - 1 < currentCursorLocation)
                    {
                        currentCursorLocation -= airplanesCount;
                    }
                } while (
                    SelectManager.instance.airplanesStatus[currentCursorLocation]
                    != SelectManager.Airplane.Unselected
                );
                break;
        }

        transform.position = SelectManager.instance.airplanes[currentCursorLocation]
            .transform
            .position;
        SelectManager.instance.airplanesStatus[currentCursorLocation] = SelectManager
            .Airplane
            .Standby;
    }

    // 비행기 선택 시
    public void SelectAirplane()
    {
        // 해당 커서의 isSelect = true
        isSelect = true;

        // 해당 커서가 위치하고 있는 비행기 정보를 'Selected'로 변경
        SelectManager.instance.airplanesStatus[currentCursorLocation] = SelectManager
            .Airplane
            .Selected;

        // 커서 이미지 변경
        transform.Find("UnselectedCursor").gameObject.SetActive(false);
        transform.Find("SelectedCursor").gameObject.SetActive(true);
    }

    // 콜라이더를 빠져나오면 비행기 스프라이트 변경
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            other.transform.parent.Find("AirplaneSelected").gameObject.SetActive(true);
            other.transform.parent.Find("AirplaneUnselected").gameObject.SetActive(false);

            playerAirplane = other.transform.parent.name;
        }
    }

    // 콜라이더를 빠져나오면 비행기 스프라이트 변경
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other != null)
        {
            other.transform.parent.Find("AirplaneSelected").gameObject.SetActive(false);
            other.transform.parent.Find("AirplaneUnselected").gameObject.SetActive(true);
        }
    }

    protected enum Direction
    {
        Up,
        Left,
        Right,
        Down
    }
}
