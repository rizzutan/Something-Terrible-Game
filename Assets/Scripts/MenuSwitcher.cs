using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuSwitcher : MonoBehaviour
{
    public GameObject[] menuOptions = new GameObject[99];

    public float lerpPercentageComplete = 0;
    public int currentMenuNum = 0;
    public int maxMenuNum = 2;
    public float menuSwitchCooldown = 0.5f;
    public bool canMenuSwitch = true;
    public float menuSwitchDuration = 1;

    // Start is called before the first frame update
    void Start()
    {
        maxMenuNum = transform.childCount;
        Debug.Log("maxMenuNum :" + maxMenuNum);
        for (int i = 0; i < maxMenuNum; i++)
        {
            menuOptions[i] = transform.GetChild(i).gameObject;
        }
        MenuSwitch(0);
    }

    public void MenuSwitch(int scroll_Direction)
    {
        currentMenuNum += scroll_Direction;

        if (currentMenuNum >= maxMenuNum) { currentMenuNum = 0; }
        if (currentMenuNum <= -1) { currentMenuNum = maxMenuNum - 1; }
        
        for (int i = 0; i < maxMenuNum; i++)
        {
            Debug.Log("currentMenuNum: " + currentMenuNum + "  , i: " + i);
            if (i == currentMenuNum)
            {
                Debug.Log("True!");
                menuOptions[currentMenuNum].GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, 1); ;
            }
            else if (i != currentMenuNum) { menuOptions[currentMenuNum].GetComponent<TextMeshProUGUI>().color = new Color(1,1,1,0.5f); Debug.Log("False!"); }
        }


    }
    
}
