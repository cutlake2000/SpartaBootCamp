using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChooseStage()
    {
        PlayerPrefs.SetInt("diff", 1); //난이도 상수
        SceneManager.LoadScene("MainStage");
    }
}
