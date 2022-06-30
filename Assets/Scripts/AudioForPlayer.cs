using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip[0]);
        }
    }
}
