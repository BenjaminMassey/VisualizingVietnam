using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOverTime : MonoBehaviour
{
    [SerializeField]
    private GameObject baseObject = null; // What object to multiply
    [SerializeField]
    private int number = 0; // How many of said objects to make
    [SerializeField]
    private Vector3 bounds = Vector3.zero; // How far size of spawning region
    [SerializeField]
    private float wait_time = 0.0f; // Number of ticks (seconds) to delay
    [SerializeField]
    private float between_time = 1.0f;

    private bool has_rb;
    private bool has_bc;
    private bool has_smr;

    // Start is called before the first frame update
    void Start()
    {
        has_rb = baseObject.GetComponent<Rigidbody>() != null;
        has_bc = baseObject.GetComponent<BoxCollider>() != null;
        has_smr = baseObject.GetComponent<SkinnedMeshRenderer>() != null;
        StartCoroutine("SpawnLoop");
    }

    private IEnumerator SpawnLoop()
    {
        if (has_rb) { baseObject.GetComponent<Rigidbody>().useGravity = false; }
        if (has_bc) { baseObject.GetComponent<BoxCollider>().enabled = false; }
        if (has_smr) { baseObject.GetComponent<SkinnedMeshRenderer>().enabled = false; }
        else { baseObject.GetComponent<MeshRenderer>().enabled = false;  }

        yield return new WaitForSeconds(wait_time);

        Vector3 start = baseObject.transform.position;
        GameObject temp_go = null;
        Vector3 temp_v = Vector3.zero;
        for (int i = 0; i < number; i++)
        {
            temp_go = Instantiate(baseObject);
            temp_v = start;
            temp_v.x = temp_v.x + Random.Range(-bounds.x, bounds.x);
            temp_v.y = temp_v.y + Random.Range(-bounds.y, bounds.y);
            temp_v.z = temp_v.z + Random.Range(-bounds.z, bounds.z);
            temp_go.transform.position = temp_v;
            if (has_rb) { temp_go.GetComponent<Rigidbody>().useGravity = true; }
            if (has_bc) { temp_go.GetComponent<BoxCollider>().enabled = true; }
            if (has_smr) { temp_go.GetComponent<SkinnedMeshRenderer>().enabled = true; }
            else { temp_go.GetComponent<MeshRenderer>().enabled = true; }
            
            temp_go.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(between_time);
        }
    }
}
