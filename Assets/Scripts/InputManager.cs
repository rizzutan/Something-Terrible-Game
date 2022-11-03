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
    Scene currentScene;

    string textInOrder;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        CS = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<ChangeScene>();
        TM = GameObject.Find("TextManager").GetComponent<TextManager>();
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
                if (verticalInputP) { CS.ChangeSceneTo("MainGame"); verticalInputP = false; }
                else if (verticalInputN) { }
                else if (horzontalInputN) { }
                else if (horzontalInputP) { }
                else if (spaceButtonInput) { }
                else if (pauseButtonInput) { }
            }
            else if (currentScene.buildIndex == 1 || currentScene.buildIndex == 3)
            {
                if (verticalInputP) { TM.ResetText(); print("key: W"); }
                else if (verticalInputN) { TM.AddTextToTextbox(TM.tutorialTextAnswer[0][0]); print("Key : S, Letter: " + TM.tutorialTextAnswer[0][0]); }      //ghost
                else if (horzontalInputN) { TM.AddTextToTextbox(TM.tutorialTextAnswer[0][1]); print("Key : A, Letter: " + TM.tutorialTextAnswer[0][1]); }     //triangle
                else if (horzontalInputP) { TM.AddTextToTextbox(TM.tutorialTextAnswer[0][2]); print("Key : D, Letter: " + TM.tutorialTextAnswer[0][2]); }     //square
                else if (spaceButtonInput) { TM.AddTextToTextbox(TM.tutorialTextAnswer[0][3]); print("Key : F, Letter: " + TM.tutorialTextAnswer[0][3]); }    //diamond
                else if (pauseButtonInput) { TM.AddTextToTextbox(TM.tutorialTextAnswer[0][4]); print("Key : G, Letter: " + TM.tutorialTextAnswer[0][4]); }    //circle
            }
    }
    
    
}
