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
    public ChangeScene CS;

    public string scrambledTextAnswer;

    // Start is called before the first frame update
    void Start()
    {
        CS = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<ChangeScene>();
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
        scrambledTextAnswer = "";
        ScrambleAnswerText();
        ResetText();
    }
    public void ResetText()
    {
        
        playerText = "";
        Debug.Log(textShown +"          "+ tutorialText.Length);

        if (textShown >= tutorialText.Length)
        {
            CS.ChangeSceneTo("EndDialougeGood");
        }

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

    public void ScrambleAnswerText()
    {
        if (textShown >= tutorialText.Length)
        {
            CS.ChangeSceneTo("EndDialougeGood");
        }
        List<char> answer = new();
        answer.AddRange(tutorialTextAnswer[textShown]);
        for (int i = 0; i < 5; i++)
        {
            int value = Random.Range(0, answer.Count - 1);
            scrambledTextAnswer += answer[value];
            answer.RemoveAt(value);
        }
    }

}
