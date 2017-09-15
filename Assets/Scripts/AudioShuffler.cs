using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class AudioShuffler : MonoBehaviour {

	public AudioClip[] audioClips;

	public AudioClip GetAudioClip() {
        //int random = Random.Range(0, 1000000);
        int random = System.DateTime.Now.Millisecond;
        Debug.Log(random);
        return audioClips [random % audioClips.Length];
	}
}
