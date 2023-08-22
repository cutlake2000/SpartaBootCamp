using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoard : MonoBehaviour
{
    Vector2 springJumpPower;
    public bool isReady = false;

    void Start()
    {
        springJumpPower = new Vector2(0f, Random.Range(100f, 120f));
        FillSpringBoard();
    }

    public void FillSpringBoard()
    {
        GameObject characterList = GameManager.Instance.CharacterList;
        if (transform.childCount == 0 && characterList.transform.childCount > 0 && !isReady)
        {
            characterList.transform.GetChild(0).transform.parent = transform;
            SpringBoardMove();
        }

        // 캐릭터 리스트의 첫 요소를
        // SpringBoard의 Child로 데려온 후
        // SpringBoardMove()

    }

    public void SpringBoardMove()
    {
        transform.GetChild(0).localPosition = new Vector3(0, 0, 0);
        transform.GetChild(0).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        transform.GetChild(0).GetComponent<Character>().DefaultSize();
        transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        isReady = true;

        // child의 실제 위치를 이동시킨뒤
        // RigidBody의 z축 고정을 풀어준다.
        // isReady가 true가 되어서 준비가 완료된다.
    }

    public void JumpCharacter()
    {
        if (isReady)
        {
            isReady = false;
            Rigidbody2D rb2D = transform.GetChild(0).GetComponent<Rigidbody2D>();

            rb2D.AddForce(springJumpPower);

            transform.GetChild(0).GetComponent<Character>().isJumping = true;
            transform.GetChild(0).parent = null;
            
            

            // child에게 힘을 가해서 jump시키고
            // SpringBoard 밖으로 내보낸다.
        }

    }
}
