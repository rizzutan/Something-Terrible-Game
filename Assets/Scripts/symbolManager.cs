using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class symbolManager : MonoBehaviour
{
    public string symbolString = "";
    public int turnNum = 0;
    
    //public string playerText;
    bool isPlayerCorrect;

    InputManager IM;
    TextManager TM;
    AssignSymbol AS;
    public GameObject FloatingLetter;



    // Start is called before the first frame update
    void Start()
    {
        IM = GameObject.Find("InputManager").GetComponent<InputManager>();
        TM = GameObject.Find("TextManager").GetComponent<TextManager>();
        AS = GameObject.Find("TextManager").GetComponent<AssignSymbol>();
        //tmpPlayerText = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>();
        CreateSymbolString();
    }
    void Update()
    {
        if (IM.playerTextLetters.Length != 0 && IM.playerTextLetters[IM.playerTextLetters.Length-1] == 'W')
        {
            sentMessage();
            
        }
    }
    public void sentMessage()
    {
        isPlayerCorrect = CheckPlayerInput();
        //IM.PauseInputUntil(3f);
        if (isPlayerCorrect)
        {
            Debug.Log("Ding! Correct!");
            // wait [x] amount of seconds
            TM.NextPhrase();
            GameObject[] floatingSymbols = GameObject.FindGameObjectsWithTag("FloatingSymbol");
            for (int i = 0; i < floatingSymbols.Length; i++) { Destroy(floatingSymbols[i]); }
            CreateSymbolString();
            
            turnNum += 1;
        }
        else
        {
            Debug.Log("BZZZT! INcorrect!");
            // wait [x] amount of seconds
            TM.ResetText();          
            GameObject[] floatingSymbols = GameObject.FindGameObjectsWithTag("FloatingSymbol");
        }

    }


    public void CreateSymbolString()
    {
        symbolString = "";

        


        int numOfSymbols = 5;
        string symbolNumToAssign = "";
        for (int i = 0; i < numOfSymbols; i++)
        {
            char symbol = 'p';
            int symbolNum = i;
            symbolNumToAssign += symbolNum.ToString();

            switch (symbolNum)
            {
                // numbers to symbols
                // 1 == 'a key' == TriangleSymbol
                // 2 == 's key' == HeartSymbol
                // 3 == 'd key' == SquareSymbol
                // 4 == 'p key' (f on makey-makey)== DiamondSymbol
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
                    symbol = 'F';
                    break;
                case 5:
                    symbol = 'G';
                    break;
            }
            symbolString += symbol;
        }
        Debug.Log("Symbol String: " + symbolString);
        FloatingLetter.GetComponent<AssignSymbol>().InstantiateFloatingSymbol(TM.tutorialTextAnswer[turnNum]);
    }


    public bool CheckPlayerInput()
    {
        // gets player's inputed text
        string playerText = TM.playerTypedText;
        for (int i = 0; i < TM.tutorialTextAnswer[TM.textShown].Length; i++)
        {
            if (TM.tutorialTextAnswer[TM.textShown][i] != playerText[i])
            {
                return false;
            }
            
        }
        return true;
    }
}
