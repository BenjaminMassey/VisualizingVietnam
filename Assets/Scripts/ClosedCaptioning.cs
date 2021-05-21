using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedCaptioning : MonoBehaviour
{
    [SerializeField]
    private string[] captions = new string[0];
    [SerializeField]
    private int[] times = new int[0];

    private bool display;
    private TMPro.TextMeshProUGUI text;
    private float font_size;

    // Start is called before the first frame update
    void Start()
    {
        display = false;
        text = GetComponent<TMPro.TextMeshProUGUI>();
        font_size = text.fontSize;
        text.fontSize = 0.0f;
        for (int i = 0; i < captions.Length; i++)
        {
            StartCoroutine(ClosedCaption(i));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) || OVRInput.GetDown(OVRInput.Button.Three))
        {
            display = !display;
            text.fontSize = display ? font_size : 0.0f;
        }
    }

    private IEnumerator ClosedCaption(int index)
    {

        yield return new WaitForSeconds(times[index]);

        text.SetText(captions[index]);
    }
}
