using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public float horzontalInput = 0;
    public float verticalInput = 0;
    public bool spaceButtonInput = false;
    public bool pauseButtonInput = false;

    public bool playerCanInput = true;
    public float lerpPercentageComplete = 0;

    public string playerTextLetters;
    public TMP_Text playerTextSymbols;
    public ChangeScene CS;
    Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        CS = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<ChangeScene>();
        playerTextSymbols = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCanInput)
        {
            // left and right controls
            horzontalInput = Input.GetAxisRaw("Horizontal");
            // up and down controls
            verticalInput = Input.GetAxisRaw("Vertical");

            // button inputs use GetButton to allow buttons to be pressed and held for a certian amount of time.
            // this game's controls aren't standard to the player, and they could make a mistake they would
            // consider unfair, like dropping the planchette onto the connector and accidentally sending a signal to the button/axis.
            // using GetButton allows us to check if the button has been held for [x] amount of seconds, like 0.5 or 0.25 seconds.

            // start/space button
            spaceButtonInput = Input.GetButton("space");
            // back/click button
            pauseButtonInput = Input.GetButton("click");

            if (currentScene.buildIndex == 0)
            {
                Debug.Log("TEST1");
                if (verticalInput == 1) { CS.ChangeSceneTo("MainGame"); playerCanInput = false; verticalInput = 0; }
                else if (verticalInput == -1) { playerCanInput = false; verticalInput = 0; }
                else if (horzontalInput == -1) { playerCanInput = false; horzontalInput = 0; }
                else if (horzontalInput == 1) { playerCanInput = false; horzontalInput = 0; }
                else if (spaceButtonInput) {  playerCanInput = false; spaceButtonInput = false; }
                else if (pauseButtonInput) {  playerCanInput = false; pauseButtonInput = false; }
            }
            else if (currentScene.buildIndex == 1)
            {
                if (verticalInput == 1) { playerCanInput = false; verticalInput = 0; }
                else if (verticalInput == -1) { playerTextLetters += 'S'; playerTextSymbols.text += "<sprite=0>"; playerCanInput = false; verticalInput = 0; }
                else if (horzontalInput == -1) { playerTextLetters += 'A'; playerTextSymbols.text += "<sprite=3>"; playerCanInput = false; horzontalInput = 0; }
                else if (horzontalInput == 1) { playerTextLetters += 'D'; playerTextSymbols.text += "<sprite=1>"; playerCanInput = false; horzontalInput = 0; }
                else if (spaceButtonInput) { playerTextLetters += 'P'; playerTextSymbols.text += "<sprite=4>"; playerCanInput = false; spaceButtonInput = false; }
                else if (pauseButtonInput) { playerTextLetters += 'O'; playerTextSymbols.text += "<sprite=2>"; playerCanInput = false; pauseButtonInput = false; }
            }
        }
        else { PauseInputUntil(0.5f); }
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
