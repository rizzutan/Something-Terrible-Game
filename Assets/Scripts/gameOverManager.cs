using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadMenu", 5);
    }

    void loadMenu()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }
}
