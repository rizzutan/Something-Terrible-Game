using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class symbolManager : MonoBehaviour
{
    public string symbolString = "";
    public int turnNum = 0;
    public TMP_Text correctText;
    public TMP_Text tmpPlayerText;

    public string playerText;
    bool isPlayerCorrect;

    InputManager IM;

    // Start is called before the first frame update
    void Start()
    {
        IM = GameObject.Find("InputManager").GetComponent<InputManager>();
        correctText = GameObject.FindGameObjectWithTag("Correct Text").GetComponent<TextMeshProUGUI>();
        tmpPlayerText = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>();
        CreateSymbolString();
    }
    void Update()
    {
        if (IM.playerTextLetters.Length == correctText.text.Length && IM.playerTextLetters.Length != 0)
        {
            playerText = IM.playerTextLetters;
            isPlayerCorrect = CheckPlayerInput();
            //IM.PauseInputUntil(3f);
            if (isPlayerCorrect) 
            {
                Debug.Log("Ding! Correct!");
                // wait [x] amount of seconds
                playerText = "";
                IM.playerTextLetters = "";
                tmpPlayerText.text = "";
                CreateSymbolString();
                turnNum += 1;
            }
            else
            {
                Debug.Log("BZZZT! INcorrect!");
                // wait [x] amount of seconds
                playerText = "";
                IM.playerTextLetters = "";
                tmpPlayerText.text = "";
                CreateSymbolString();
                turnNum -= 1;
            }
        }
    }

    public void CreateSymbolString()
    {
        symbolString = "";
        // 1 == 'a key'
        // 2 == 's key'
        // 3 == 'd key'
        // 4 == 'spacebar/p key'
        // 5 == 'o key'
        int numOfSymbols = 3 + Mathf.Min(2,turnNum) + Random.Range(0, Mathf.Min(turnNum, 10));
        for (int i = 0; i < numOfSymbols; i++)
        {
            char symbol;
            int symbolNum = (Random.Range(1, 6));

            switch (symbolNum)
            {
                case 1:
                    symbol = 'A';
                    break;
                case 2:
                    symbol = 'S';
                    break;
                case 3:
                    symbol = 'D';
                    break;
                case 4:
                    symbol = 'P';
                    break;
                default:
                    symbol = 'O';
                    break;
            }
            symbolString += symbol;
        }
        Debug.Log("Symbol String: " + symbolString);
        // text will look like symbols using a custom font
        correctText.text = symbolString;
    }
    public bool CheckPlayerInput()
    {
        for (int i = 0; i < correctText.text.Length; i++)
        {
            if (correctText.text[i] != playerText[i])
            {
                return false;
            }
            
        }
        return true;
    }
}
