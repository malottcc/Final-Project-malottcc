using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandom : MonoBehaviour
{

    public AudioClip[] audioClips;
    private AudioSource aS;

    // Start is called before the first frame update
    void Start()
    {
        aS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!aS.isPlaying)
        {
            aS.clip = audioClips[Random.Range(0, audioClips.Length)];
            aS.Play();
        }
    }
}
