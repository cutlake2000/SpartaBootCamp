using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
    Rigidbody2D rb2D;
    public bool isJumping = false;
    public bool isBoosting = false;
    private void Awake()
    {
        rb2D = transform.GetComponent<Rigidbody2D>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Branch"))
        {
            // 厘局拱 面倒贸府

        }
        else if (collision.gameObject.CompareTag("Closed"))
        {
            rb2D.AddForce(new Vector2(Random.Range(-25f, 25f), Random.Range(25f, 50f)));

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerObject") && !isBoosting)
        {
            isBoosting = true;
            rb2D.AddTorque(0.2f);
            rb2D.AddForce(new Vector2(Random.Range(-20f, -50f), 0f));

        }
        else if (collision.gameObject.CompareTag("EndPoint"))
        {
            transform.parent = collision.transform;
            GameManager.Instance.SpringBoard.GetComponent<SpringBoard>().FillSpringBoard();
            isJumping = false;
            Camera.main.transform.position = new Vector3(0, 0, -10);
            collision.transform.GetChild(0).gameObject.SetActive(true);

        }

    }
}
