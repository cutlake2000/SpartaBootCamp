using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // 게임 매니저에서는 char들을 list로 관리한다.

    // 버튼을 누르면 이번 캐릭터의 isSelected = false가되고
    // index++ 되면서 list에 해당된 캐릭터들의 isSelected = true가 된다.
    // 만약 캐릭터의 isSelected가 true라면 캐릭터의 Scale이 커진다.

    // Update문에서 호출하면 계속해서 isSelected를 검사해야하니까
    // 그냥 버튼에 함수를 연결?
    public string name;

    private void Awake()
    {

    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SizeUp()
    {
        transform.localScale = new Vector3(2.0f, 2.0f, 0);
    }

    public void DefaultSize()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 0);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("TriggerObject"))
        {
            Vector2 force = new Vector2(-100f,0);
            Rigidbody2D rb2D = transform.GetComponent<Rigidbody2D>();
            rb2D.AddForce(force);

        }
    }
}
