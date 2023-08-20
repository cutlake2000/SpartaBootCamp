using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    List<Character> characterList = new List<Character>();
    GameObject springBoard;
    int characterListIndex = 0;
    bool isStart = false;

    private void Awake()
    {
        GameManager.instance = this;
        CharacterListInit();
        springBoard = GameObject.Find("SpringBoard");


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            FillSpringBoard();
        }
        
    }

    public void GameStart()
    {
        foreach(Character character in characterList)
        {
            character.GetComponent<SpriteRenderer>().flipX = true;
            character.DefaultSize();
            isStart = true;
        }

        Camera.main.transform.position = new Vector3(1, -2, -10);
    }
    public void CharacterListInit()
    {
        Transform characters = GameObject.Find("Characters").transform;

        for (int i = 0; i < characters.childCount; i++)
        {
            characterList.Add(characters.GetChild(i).GetComponent<Character>());
        }
        characterList[0].SizeUp();
    }

    void IndexCheck() 
    {
        if (characterListIndex > characterList.Count-1)
        {
            characterListIndex = 0;
        }

        if(characterListIndex < 0)
        {
            characterListIndex = characterList.Count-1;
        }
    }

    public void NextCharacterSelect()
    {
        characterList[characterListIndex++].DefaultSize();
        IndexCheck();
        characterList[characterListIndex].SizeUp();
    }

    public void PrevCharacterSelect()
    {
        characterList[characterListIndex--].DefaultSize();
        IndexCheck();
        characterList[characterListIndex].SizeUp();
    }

    public void FillSpringBoard()
    {
        if (springBoard.transform.childCount == 0 && characterList.Count >0)
        {
            characterList[0].transform.parent = springBoard.transform;
            Invoke("SpringBoardMove", 1.0f);
        }
        
    }

    public void SpringBoardMove()
    {
        springBoard.transform.GetChild(0).localPosition = new Vector3(0, 0, 0);
        springBoard.transform.GetChild(0).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        characterList.RemoveAt(0);
    }

    public void JumpCharacter()
    {
        if (springBoard.transform.childCount > 0)
        {
            Vector2 force = new Vector2(0, 1000f);
            Transform ch = springBoard.transform.GetChild(0);
            Rigidbody2D rb2D = ch.GetComponent<Rigidbody2D>();
            rb2D.AddForce(force);
            rb2D.AddTorque(100f);
            ch.parent = null;
        }
        
    }

    // 바닥, 물체1, 물체2 가있을때
    // 바닥과 물체1 충돌ㅇ
    // 물체1과 물체2 충돌 X 충돌감지 ㅇ

}
