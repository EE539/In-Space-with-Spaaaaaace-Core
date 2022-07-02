using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;
    [HideInInspector] public float clipLength = 1f;
    bool isAlive;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && GetComponent<Movement>().isAlive)
        {
            audioSource.PlayOneShot(audioClip[0]);
        }
        else if(!GetComponent<Movement>().isAlive && count == 0){
            int deathNumber = Random.Range(1, 3);
            clipLength = audioClip[deathNumber].length;
            audioSource.Stop();
            audioSource.PlayOneShot(audioClip[deathNumber]);
            count++;
        }
    }
}
