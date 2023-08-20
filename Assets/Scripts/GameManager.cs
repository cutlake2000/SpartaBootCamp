using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    List<Character> characterList = new List<Character>();
    int characterListIndex = 0;

    private void Awake()
    {
        GameManager.instance = this;
        CharacterListInit();


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        
    }
    public void CharacterListInit()
    {
        Transform characters = GameObject.Find("Characters").transform;
        int count = characters.childCount;

        for (int i = 0; i < count; i++)
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

    // 스타트 했을때

    // update문에서 ReadyCharter의 

}
