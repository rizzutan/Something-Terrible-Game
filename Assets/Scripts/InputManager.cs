using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public bool horzontalInputP = false;
    public bool horzontalInputN = false;
    public bool verticalInputP = false;
    public bool verticalInputN = false;
    public bool spaceButtonInput = false;
    public bool pauseButtonInput = false;

    public float lerpPercentageComplete = 0;

    public string playerTextLetters;
    public TMP_Text playerTextSymbols;
    public ChangeScene CS;
    public TextManager TM;
    lifeManager LM;
    Scene currentScene;

    [SerializeField] AudioSource input;

    string textInOrder;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        CS = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<ChangeScene>();
        TM = GameObject.Find("TextManager").GetComponent<TextManager>();
        LM = GameObject.Find("LifeManager").GetComponent<lifeManager>();
        playerTextSymbols = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
            // left and right controls
            horzontalInputP = Input.GetButtonDown("HorizontalP");
            horzontalInputN = Input.GetButtonDown("HorizontalN");
            // up and down controls
            verticalInputP = Input.GetButtonDown("VerticalP");
            verticalInputN = Input.GetButtonDown("VerticalN");
            // start/space button
            spaceButtonInput = Input.GetButtonDown("space");
            // back/click button
            pauseButtonInput = Input.GetButtonDown("click");

            if (currentScene.buildIndex == 0)
            {
                if (verticalInputP) { CS.ChangeSceneTo("ZachMainGame"); }
                else if (verticalInputN) { CS.ChangeSceneTo("CreditsScreen"); }
                else if (horzontalInputP) { CS.ChangeSceneTo("HelpScreen"); }
            }
            else if (currentScene.buildIndex == 1)
            {
                if (verticalInputP)
                {
                    TM.ResetText(); print("key: W");
                    LM.lives--;
                    input.Play();
                }
                else if (verticalInputN)
                {
                    TM.AddTextToTextbox(TM.tutorialTextAnswer[TM.textShown][0]); print("Key : S, Letter: " + TM.tutorialTextAnswer[TM.textShown][0]);
                    input.Play();
                }      //ghost
                else if (horzontalInputN)
                {
                    TM.AddTextToTextbox(TM.tutorialTextAnswer[TM.textShown][1]); print("Key : A, Letter: " + TM.tutorialTextAnswer[TM.textShown][1]);
                    input.Play();
                }     //triangle
                else if (horzontalInputP)
                {
                    TM.AddTextToTextbox(TM.tutorialTextAnswer[TM.textShown][2]); print("Key : D, Letter: " + TM.tutorialTextAnswer[TM.textShown][2]);
                    input.Play();
                }     //square
                else if (spaceButtonInput)
                {
                    TM.AddTextToTextbox(TM.tutorialTextAnswer[TM.textShown][3]); print("Key : F, Letter: " + TM.tutorialTextAnswer[TM.textShown][3]);
                    input.Play();
                }    //diamond
                else if (pauseButtonInput)
                {
                    TM.AddTextToTextbox(TM.tutorialTextAnswer[TM.textShown][4]); print("Key : G, Letter: " + TM.tutorialTextAnswer[TM.textShown][4]);
                    input.Play();
                }    //circle
            }
        else if (currentScene.buildIndex == 2)
        {
            if (horzontalInputN) { CS.ChangeSceneTo("TitleScreen"); }
        }
        else if (currentScene.buildIndex == 3)
        {
            if (horzontalInputN) { CS.ChangeSceneTo("TitleScreen"); }
        }
    }
    
    
}
