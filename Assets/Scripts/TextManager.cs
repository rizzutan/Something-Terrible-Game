using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public string[] tutorialText = new string[1];
    public string[] tutorialTextAnswer = new string[1];
    public string playerText;
    public string playerTypedText;
    public int textShown = 0;
    public TMP_Text playerTextSymbols;
    public symbolManager SM;

    // Start is called before the first frame update
    void Start()
    {
        playerTextSymbols = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>();
        SM = GameObject.FindGameObjectWithTag("SymbolManager").GetComponent<symbolManager>();
        ResetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextPhrase()
    {
        textShown += 1;
        ResetText();
    }
    public void ResetText()
    {
        playerTypedText = tutorialText[textShown];
        playerTextSymbols.text = tutorialText[textShown];
    }
    public void AddTextToTextbox(char letter)
    {
        bool hasFoundUnderscore = false;
        string newPlayerTypedText = "";
        for (int i = 0; i < playerTypedText.Length - 1; i++)
        {
            if (playerTypedText[i] == '_' && !hasFoundUnderscore)
            {
                newPlayerTypedText += letter;
                hasFoundUnderscore = true;
            }
            else 
            {
                newPlayerTypedText += playerTypedText[i];
            }
        }
        playerTypedText = newPlayerTypedText;

        

        playerTextSymbols.text = playerTypedText;
        playerText += letter.ToString();

        print(newPlayerTypedText);
        if (!CheckIfUnderscore()) { CheckPlayerInput(); }
    }
    public bool CheckIfUnderscore()
    {
        for (int i = 0; i < playerTypedText.Length - 1; i++)
        {
            if (playerTypedText[i] == '_')
            {
                return true;
            }

        }
        return false;
    }

    public void CheckPlayerInput()
    {
        // gets player's inputed text
        bool flaggedFalse = false;
        string playersInputedText = playerTypedText;
        if (tutorialTextAnswer[textShown] != playerText)
        {
            SM.sentMessage(false);
            flaggedFalse = true;
        }
        if (!flaggedFalse) { SM.sentMessage(true); }
        
    }

}
