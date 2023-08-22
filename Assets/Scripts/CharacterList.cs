using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    int index, max = 0;
    List<Character> list = new List<Character>();

    void Start()
    {
        IndexCheck();
        for (int i =0; i<= max; i++)
        {
            list.Add(transform.GetChild(i).GetComponent<Character>());
        }
        list[index].SizeUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextCharacterSelect()
    {
        list[index++].DefaultSize();
        IndexCheck();
        list[index].SizeUp();
        
    }

    public void PrevCharacterSelect()
    {
        list[index--].DefaultSize();
        IndexCheck();
        list[index].SizeUp();
    }

    public void IndexCheck()
    {
        max = transform.childCount - 1 ;
        if (index < 0)
        {
            index = max;
        }
        else if (index > max)
        {
            index = 0;
        }
    }

}
