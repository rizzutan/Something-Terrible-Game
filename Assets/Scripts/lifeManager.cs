using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class lifeManager : MonoBehaviour
{
    public int lives = 3;
    [SerializeField] TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 3)
        {
            text.text = "<sprite=5> <sprite=5> <sprite=5>";
        }
        else if (lives == 2)
        {
            text.text = "<sprite=5> <sprite=5>";
        }
        else if (lives == 1)
        {
            text.text = "<sprite=5>";
        }
        else if (lives == 0)
        {
            text.text = "";
            SceneManager.LoadScene("EndDialougeBad", LoadSceneMode.Single);
            
        }
    }
}
