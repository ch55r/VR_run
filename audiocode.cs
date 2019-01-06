using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocode : maincode
{
    public  AudioSource source;
    public AudioClip clip;
    // Use this for initialization
    void Start () {
        //        crowds = gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.loop = true;
        source.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (!runing)
            source.mute=true;
        else source.mute=false;
    }
}
