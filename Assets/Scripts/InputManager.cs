using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float horzontalInput = 0;
    public float verticalInput = 0;
    public bool startButtonInput = false;
    public bool backButtonInput = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // left and right controls
        horzontalInput = Input.GetAxisRaw("horizontal");
        // up and down controls
        verticalInput = Input.GetAxisRaw("horizontal");

        // button inputs use GetButton to allow buttons to be pressed and held for a certian amount of time.
        // this game's controls aren't standard to the player, and they could make a mistake they would
        // consider unfair, like dropping the planchette onto the connector and accidentally sending a signal to the button/axis.
        // using GetButton allows us to check if the button has been held for [x] amount of seconds, like 0.5 or 0.25 seconds.

        // start/space button
        startButtonInput = Input.GetButton("start");
        // back/click button
        backButtonInput = Input.GetButton("back");
    }
}
