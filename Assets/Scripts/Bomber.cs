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
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.3f, 0.7f));
            GameObject b = Instantiate(bomb);
            b.transform.position = transform.position;
        }
    }
}
