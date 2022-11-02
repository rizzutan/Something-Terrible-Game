using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneTo(string sceneName) 
    {
        StartCoroutine(SceneChange(sceneName));
    }
    IEnumerator SceneChange(string sceneName)
    { 
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
