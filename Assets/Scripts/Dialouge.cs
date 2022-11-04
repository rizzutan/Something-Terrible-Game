using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialouge : MonoBehaviour
{
    public string[] dialougeText = new string[17];
    public Color[] dialougeColor = new Color[17];
    public int stringNum = 0;

    public TMP_Text playerText;
    public GameObject blackBox;
    Scene currentScene;
    public ChangeScene CS;

    // Start is called before the first frame update
    void Start()
    {
        playerText = GameObject.FindGameObjectWithTag("Player Text").GetComponent<TextMeshProUGUI>();
        currentScene = SceneManager.GetActiveScene();
        CS = GameObject.FindGameObjectWithTag("Scene Manager").GetComponent<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stringNum >= 20 && currentScene.buildIndex == 5)
        {
            CS.ChangeSceneTo("ZachMainGame");
        }
        if (stringNum >= 8 && currentScene.buildIndex == 6)
        {
            CS.ChangeSceneTo("TitleScreen");
        }
        if (stringNum >= 4 && currentScene.buildIndex == 7)
        {
            CS.ChangeSceneTo("GameOver");
        }

        playerText.text = dialougeText[stringNum];
        playerText.color = dialougeColor[stringNum];

        if (stringNum == 3 && currentScene.buildIndex == 5)
        {
            blackBox.GetComponent<SpriteRenderer>().color = new Color(1,1,1, blackBox.GetComponent<SpriteRenderer>().color.a-(Time.deltaTime));
        }
        if (stringNum > 3 && currentScene.buildIndex == 5)
        {
            blackBox.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        }

        if (stringNum == 4 && currentScene.buildIndex == 6)
        {
            blackBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, blackBox.GetComponent<SpriteRenderer>().color.a + (Time.deltaTime*2));
        }
        if (stringNum > 4 && currentScene.buildIndex == 6)
        {
            blackBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }

        if (stringNum == 2 && currentScene.buildIndex == 7)
        {
            blackBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, blackBox.GetComponent<SpriteRenderer>().color.a + (Time.deltaTime));
        }
        if (stringNum > 2 && currentScene.buildIndex == 7)
        {
            blackBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
    }
}
