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
    public TMP_Text playerText;
    bool isPlayerCorrect;

    InputManager IM;

    // Start is called before the first frame update
    void Start()
    {
        IM = GameObject.Find("InputManager").GetComponent<InputManager>();
        correctText = GameObject.FindGameObjectWithTag("Correct Text").GetComponent<TextMeshProUGUI>();
        playerText = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>();
        CreateSymbolString();
    }
    void Update()
    {
        if (playerText.text.Length == correctText.text.Length)
        {
            IM.playerCanInput = false;
            isPlayerCorrect = CheckPlayerInput();

            if (isPlayerCorrect) 
            {
                Debug.Log("Ding! Correct!");
                // wait [x] amount of seconds
                IM.playerCanInput = true;
                playerText.text = "";
            }
            else
            {
                Debug.Log("BZZZT! INcorrect!");
                // wait [x] amount of seconds
                IM.playerCanInput = true;
                playerText.text = "";
            }
        }
    }

    public void CreateSymbolString()
    {
        // 1 == 'w key'
        // 2 == 'a key'
        // 3 == 's key'
        // 4 == 'd key'
        // 5 == 'spacebar'
        int numOfSymbols = 3 + Mathf.Min(2,turnNum) + Random.Range(0, Mathf.Min(turnNum, 10));
        for (int i = 0; i < numOfSymbols; i++)
        {
            char symbol;
            int symbolNum = (Random.Range(1, 6));

            switch (symbolNum)
            {
                case 1:
                    symbol = 'W';
                    break;
                case 2:
                    symbol = 'A';
                    break;
                case 3:
                    symbol = 'S';
                    break;
                case 4:
                    symbol = 'D';
                    break;
                default:
                    // "P" will be " "(a space) once custom font is set up
                    symbol = 'P';
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
            if (correctText.text[i] == playerText.text[i])
            {

            }
            else { return false; }
        }
        return true;
    }
}
