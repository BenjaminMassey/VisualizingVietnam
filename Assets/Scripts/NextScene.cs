using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private AsyncOperation aso;
    private float time = 0.0f;
    
    void Start()
    {
        int myIndex = SceneManager.GetActiveScene().buildIndex;
        if (myIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            aso = SceneManager.LoadSceneAsync(myIndex + 1);
            aso.allowSceneActivation = false;
        }
        switch (myIndex)
        {
            case 0:
                time = 120.0f;
                break;
            case 1:
                time = 280.0f;
                break;
            default:
                time = -1.0f;
                break;
        }
        Debug.Log(time);
        StartCoroutine(StalledLevel());
    }

    IEnumerator StalledLevel()
    {
        if (time <= 0.0f) { yield break; }
        yield return new WaitForSeconds(time);
        aso.allowSceneActivation = true;
    }
}
