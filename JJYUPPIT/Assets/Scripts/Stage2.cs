using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    void Start()
    {
        if (PlayerPrefs.HasKey("clear") == true)
        {
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = Color.white;
            button.colors = colorBlock;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HardGame()
    {
        PlayerPrefs.SetInt("diff", 2);
        SceneManager.LoadScene("MainStage");
    }
}
