using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    public float horzontalInput = 0;
    public float verticalInput = 0;
    public bool spaceButtonInput = false;
    public bool pauseButtonInput = false;

    public bool playerCanInput = true;

    public TMP_Text playerText;
    // Start is called before the first frame update
    void Start()
    {
        playerText = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>();
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

            if (verticalInput == 1) { playerText.text += 'W'; }
            else if (verticalInput == -1) { playerText.text += 'S'; }
            else if (horzontalInput == -1) { playerText.text += 'A'; }
            else if (horzontalInput == 1) { playerText.text += 'D'; }
            // "P" will be " "(a space) once custom font is set up
            else if (spaceButtonInput) { playerText.text += 'P'; }
        }
    }
}
