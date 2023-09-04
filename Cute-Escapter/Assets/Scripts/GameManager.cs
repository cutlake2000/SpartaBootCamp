using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GameObject SpringBoard { get; set; }
    public GameObject CharacterList { get; set; }
    public void GameStart()
    {
        SpringBoard = (GameObject)Instantiate(Resources.Load("Prefabs/SpringBoard"));
    }

    private void Awake()
    {
        instance = this;
        CharacterList = (GameObject)Instantiate(Resources.Load("Prefabs/CharacterList"));
        

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    
}
