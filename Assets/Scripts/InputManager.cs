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

    bool playerCanInput = false;

    public string playerTextLetters;
    public TMP_Text playerTextSymbols;
    public ChangeScene CS;
    public TextManager TM;
    public Dialouge dialog;
    public SpawnCraig craig;
    lifeManager LM;
    Scene currentScene;

    [SerializeField] AudioSource input;

    string textInOrder;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 3) // credits screen
        {
            craig = GameObject.Find("SpawnCraig").GetComponent<SpawnCraig>();
        }
        CS = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<ChangeScene>();
        TM = GameObject.Find("TextManager").GetComponent<TextManager>();
        LM = GameObject.Find("LifeManager").GetComponent<lifeManager>();
        playerTextSymbols = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCanInput)
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
                if (verticalInputP) { CS.ChangeSceneTo("IntroDialouge"); }
                else if (horzontalInputN) { CS.ChangeSceneTo("CreditsScreen"); }
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
                    TM.AddTextToTextbox(TM.scrambledTextAnswer[1]); playerCanInput = false; print("Key : S, Letter: " + TM.scrambledTextAnswer[1]);
                    input.Play();
                }      //ghost
                else if (horzontalInputN)
                {
                    TM.AddTextToTextbox(TM.scrambledTextAnswer[0]); playerCanInput = false; print("Key : A, Letter: " + TM.scrambledTextAnswer[0]);
                    input.Play();
                }     //triangle
                else if (horzontalInputP)
                {
                    TM.AddTextToTextbox(TM.scrambledTextAnswer[2]); playerCanInput = false; print("Key : D, Letter: " + TM.scrambledTextAnswer[2]);
                    input.Play();
                }     //square
                else if (spaceButtonInput)
                {
                    TM.AddTextToTextbox(TM.scrambledTextAnswer[3]); playerCanInput = false; print("Key : F, Letter: " + TM.scrambledTextAnswer[3]);
                    input.Play();
                }    //diamond
                else if (pauseButtonInput)
                {
                    TM.AddTextToTextbox(TM.scrambledTextAnswer[4]); playerCanInput = false; print("Key : G, Letter: " + TM.scrambledTextAnswer[4]);
                    input.Play();
                }    //circle
            }
            else if (currentScene.buildIndex == 2)
            {
                if (verticalInputN) { CS.ChangeSceneTo("TitleScreen"); playerCanInput = false; }
            }
            else if (currentScene.buildIndex == 3) // credits screen
            {
                if (verticalInputN) { CS.ChangeSceneTo("TitleScreen"); playerCanInput = false; }
            }
            else if (currentScene.buildIndex == 5 || currentScene.buildIndex == 6 || currentScene.buildIndex == 7)
            {
                if (verticalInputP || verticalInputN
                || horzontalInputN || horzontalInputP
                || spaceButtonInput || pauseButtonInput)
                {
                    dialog.stringNum += 1;
                    input.Play(); playerCanInput = false;
                }
            }
        }
        else { PauseInputUntil(0.2f); }

        if (currentScene.buildIndex == 3) // credits screen
        {
            if (verticalInputP
                && horzontalInputN
                && horzontalInputP) 
            { craig.Craig(); }
        }
    }

    public void PauseInputUntil(float seconds)
    {
        //Calculates the percentageComplete to be used by LerpInput
        // acts as the acceleration time and the deceleration time, depending on if the player has pressed an input key or not
        if (lerpPercentageComplete >= 0 && lerpPercentageComplete < 1)
        {
            lerpPercentageComplete += Time.deltaTime / seconds;
        }
        else if (lerpPercentageComplete > 1) { lerpPercentageComplete = 0; playerCanInput = true; }
    }
}
