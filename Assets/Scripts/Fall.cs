using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private AudioSource drop;

    [SerializeField]
    private AudioSource boom;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wee());
    }

    // Update is called once per frame
    IEnumerator Wee()
    {
        drop.Play();
        Vector3 pos;
        Vector3 down = Vector3.down * 5.0f;
        while (true)
        {
            pos = transform.position;
            transform.position = pos + down;
            if (pos.y <= 0.0f)
            {
                transform.position = new Vector3(pos.x, 0.0f, pos.z);
                StartCoroutine(Boom());
                GetComponent<MeshRenderer>().enabled = false;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator Boom()
    {
        drop.Stop();
        boom.Play();
        GameObject e = Instantiate(explosion);
        e.transform.position = transform.position;
        yield return new WaitForSeconds(2.0f);
        Destroy(e);
        Destroy(gameObject);
    }
}
