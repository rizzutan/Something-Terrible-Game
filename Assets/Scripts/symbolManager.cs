using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class symbolManager : MonoBehaviour
{
    public string symbolString = "";
    public int turnNum = 0;
    public string correctText;
    public TMP_Text tmpPlayerText;
    
    public string playerText;
    bool isPlayerCorrect;

    InputManager IM;
    TextManager TM;
    public GameObject FloatingLetter;

    // Start is called before the first frame update
    void Start()
    {
        IM = GameObject.Find("InputManager").GetComponent<InputManager>();
        TM = GameObject.Find("TextManager").GetComponent<TextManager>();
        tmpPlayerText = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>();
        CreateSymbolString();
    }
    void Update()
    {
        if (IM.playerTextLetters.Length == correctText.Length && IM.playerTextLetters.Length != 0)
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
            }
        }
    }

    public void CreateSymbolString()
    {
        symbolString = "";


        


        int numOfSymbols = 3 + Mathf.Min(2,turnNum) + Random.Range(0, Mathf.Min(turnNum, 10));
        string symbolNumToAssign = "";
        for (int i = 0; i < numOfSymbols; i++)
        {
            char symbol;
            int symbolNum = (Random.Range(1, 6));
            symbolNumToAssign += symbolNum.ToString();

            switch (symbolNum)
            {
                // numbers to symbols
                // 1 == 'a key' == TriangleSymbol
                // 2 == 's key' == HeartSymbol
                // 3 == 'd key' == SquareSymbol
                // 4 == 'spacebar/p key' (f on makey-makey)== DiamondSymbol
                // 5 == 'o key' (g on makey-makey) == CircleSymbol

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
        correctText = symbolString;

        FloatingLetter.GetComponent<AssignSymbol>().InstantiateFloatingSymbol(symbolNumToAssign, TM.tutorialTextAnswer[turnNum]);
    }
    public bool CheckPlayerInput()
    {
        for (int i = 0; i < correctText.Length; i++)
        {
            if (correctText[i] != playerText[i])
            {
                return false;
            }
            
        }
        return true;
    }
}
