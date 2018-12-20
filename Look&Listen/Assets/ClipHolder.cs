using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipHolder : MonoBehaviour {
    //쳐다보면 소리내기, 소리 설정
    private AudioSource audioSource;
    //private new Collider collider;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //collider = GetComponent<Collider>();
    }
    // Use this for initialization
    public void Play()
    {
        //question; return 방식 or collider turn off 하는 방식?=>update 써야 됨.
        if (audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();
    }
	
}
