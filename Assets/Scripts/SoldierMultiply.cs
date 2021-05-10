using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMultiply : MonoBehaviour
{
    [SerializeField]
    private GameObject baseObject = null; // What object to multiply
    [SerializeField]
    private int number = 0; // How many of said objects to make
    [SerializeField]
    private Vector3 bounds = Vector3.zero; // How far size of spawning region
    [SerializeField]
    private float wait_time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        Rigidbody rb = baseObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        BoxCollider bc = baseObject.GetComponent<BoxCollider>();
        bc.enabled = false;
        MeshRenderer mr = baseObject.GetComponent<MeshRenderer>();
        mr.enabled = false;

        yield return new WaitForSeconds(wait_time);

        rb.useGravity = true;
        bc.enabled = true;
        mr.enabled = true;

        Vector3 start = baseObject.transform.position;
        GameObject temp_go = null;
        Vector3 temp_v = Vector3.zero;
        for (int i = 0; i < number - 1; i++) // number - 1 because keeping original obj
        {
            temp_go = Instantiate(baseObject);
            temp_v = start;
            temp_v.x = temp_v.x + Random.Range(-bounds.x, bounds.x);
            temp_v.y = temp_v.y + Random.Range(-bounds.y, bounds.y);
            temp_v.z = temp_v.z + Random.Range(-bounds.z, bounds.z);
            temp_go.transform.position = temp_v;
        }
    }
}
