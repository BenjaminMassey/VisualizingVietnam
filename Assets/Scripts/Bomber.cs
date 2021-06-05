using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dropper());
    }

    // Update is called once per frame
    IEnumerator Dropper()
    {
        yield return new WaitForSeconds(Random.Range(0.0f, 1.4f));
        
        float total = 3.0f;
        int num = 3;
        for (int _ = 0; _ < num; _++)
        {
            GameObject b = Instantiate(bomb);
            b.transform.position = transform.position;
            yield return new WaitForSeconds((total / (num - 1)));
        }
    }
}
