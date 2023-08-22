using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
    public bool isJumping = false;
    private void Awake()
    {

    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GetCamera();
    }
    
    public void SizeUp()
    {
        transform.localScale = new Vector3(2.0f, 2.0f, 0);
    }

    public void DefaultSize()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 0);
    }

    public void GetCamera()
    {
        if (isJumping)
        {
            Vector3 targetPos = transform.localPosition;
            Camera.main.transform.position = new Vector3(targetPos.x, targetPos.y, -10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerObject"))
        {
            Vector2 force = new Vector2(-100f,60f);
            Rigidbody2D rb2D = transform.GetComponent<Rigidbody2D>();
            rb2D.AddForce(force);

        }
        else if (collision.gameObject.CompareTag("EndPoint"))
        {
            transform.parent = collision.transform;
            GameManager.Instance.SpringBoard.GetComponent<SpringBoard>().FillSpringBoard();
            isJumping = false;
            Camera.main.transform.position = new Vector3(0, 0, -10);

        }
    }
}
