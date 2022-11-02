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

    public TMP_Text playerText;
    MenuSwitcher MS;
    Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 0) { MS = GameObject.FindGameObjectWithTag("Menu Switcher").GetComponent<MenuSwitcher>(); }
        else if (currentScene.buildIndex == 1) { playerText = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>(); } 
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
                if ((int)verticalInput == 1) { MS.MenuSwitch((int)verticalInput); playerCanInput = false; verticalInput = 0; }
                else if ((int)verticalInput == -1) { MS.MenuSwitch((int)verticalInput); playerCanInput = false; verticalInput = 0; }
                else if ((int)horzontalInput == -1) { playerCanInput = false; horzontalInput = 0; }
                else if ((int)horzontalInput == 1) { playerCanInput = false; horzontalInput = 0; }
                else if (spaceButtonInput) {  playerCanInput = false; spaceButtonInput = false; }
                else if (pauseButtonInput) {  playerCanInput = false; pauseButtonInput = false; }
            }
            else if (currentScene.buildIndex == 1)
            {
                if (verticalInput == 1) { playerText.text += 'W'; playerCanInput = false; verticalInput = 0; }
                else if (verticalInput == -1) { playerText.text += 'S'; playerCanInput = false; verticalInput = 0; }
                else if (horzontalInput == -1) { playerText.text += 'A'; playerCanInput = false; horzontalInput = 0; }
                else if (horzontalInput == 1) { playerText.text += 'D'; playerCanInput = false; horzontalInput = 0; }
                else if (spaceButtonInput) { playerText.text += 'P'; playerCanInput = false; spaceButtonInput = false; }
                else if (pauseButtonInput) { playerText.text += 'B'; playerCanInput = false; pauseButtonInput = false; }
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
