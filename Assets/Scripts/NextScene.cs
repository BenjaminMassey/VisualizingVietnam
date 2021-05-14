using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private AsyncOperation aso;
    // Start is called before the first frame update
    void Start()
    {
        int myIndex = SceneManager.GetActiveScene().buildIndex;
        if (myIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            aso = SceneManager.LoadSceneAsync(myIndex + 1);
            aso.allowSceneActivation = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || OVRInput.GetDown(OVRInput.Button.One))
            aso.allowSceneActivation = true;
        if (OVRInput.GetDown(OVRInput.Button.Two))
            Application.Quit();
    }
}
