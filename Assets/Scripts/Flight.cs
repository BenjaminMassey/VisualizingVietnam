using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    [SerializeField]
    private Vector3 destination = Vector3.zero;

    [SerializeField]
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fly());
    }

    IEnumerator Fly()
    {
        float num_steps = 50 * time;
        Vector3 translation = destination - transform.position;
        translation = translation / num_steps;
        for (int i = 0; i < num_steps; i++)
        {
            transform.position = transform.position + translation;
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }
}
