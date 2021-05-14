using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClips : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] clips;
    [SerializeField]
    private float[] start_times;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < clips.Length; i++)
        {
            StartCoroutine(PlaySoundClips(i));
        }
    }

    private IEnumerator PlaySoundClips(int index)
    {

        yield return new WaitForSeconds(start_times[index]);

        clips[index].Play();
    }
}
