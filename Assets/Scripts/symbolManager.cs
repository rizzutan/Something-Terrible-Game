using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class symbolManager : MonoBehaviour
{
    public string symbolString = "";
    
    //public string playerText;
    bool isPlayerCorrect;

    public ChangeScene CS;
    InputManager IM;
    TextManager TM;
    AssignSymbol AS;
    lifeManager LM;
    public GameObject FloatingLetter;



    // Start is called before the first frame update
    void Start()
    {
        IM = GameObject.Find("InputManager").GetComponent<InputManager>();
        TM = GameObject.Find("TextManager").GetComponent<TextManager>();
        //AS = GameObject.Find("AssignSymbol").GetComponent<AssignSymbol>();
        LM = GameObject.Find("LifeManager").GetComponent<lifeManager>();
        //tmpPlayerText = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>();
        CreateSymbolString();
    }
    void Update()
    {

    }
    public void sentMessage(bool isPlayerCorrect)
    {
        //IM.PauseInputUntil(3f);
        if (isPlayerCorrect)
        {
            Debug.Log("Ding! Correct!");
            // wait [x] amount of seconds
            // changes scene if textShown is greater than the amount of lines in tutorialText

            TM.NextPhrase();
            GameObject[] floatingSymbols = GameObject.FindGameObjectsWithTag("FloatingSymbol");
            for (int i = 0; i < floatingSymbols.Length; i++) { Destroy(floatingSymbols[i]); }
            CreateSymbolString();
        }
        else
        {
            Debug.Log("BZZZT! INcorrect!");
            // wait [x] amount of seconds
            TM.ResetText();
            LM.lives--;
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
                // 4 == 'f key' (f on makey-makey)== DiamondSymbol
                // 5 == 'g key' (g on makey-makey) == CircleSymbol

                case 0:
                    symbol = TM.tutorialTextAnswer[TM.textShown][0];
                    break;
                case 1:
                    symbol = TM.tutorialTextAnswer[TM.textShown][1];
                    break;
                case 2:
                    symbol = TM.tutorialTextAnswer[TM.textShown][2];
                    break;
                case 3:
                    symbol = TM.tutorialTextAnswer[TM.textShown][3];
                    break;
                default:
                    symbol = TM.tutorialTextAnswer[TM.textShown][4];
                    break;
            }
            symbolString += symbol;
        }
        Debug.Log("Symbol String: " + symbolString);
        FloatingLetter.GetComponent<AssignSymbol>().InstantiateFloatingSymbol(TM.tutorialTextAnswer[TM.textShown]);
    }
}
