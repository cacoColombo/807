using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using DentedPixel;

[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour {
	
    public GameObject pnlDialogue;
    public bool locked;
    public bool open = false;
    public float closedRotation;
    public float openedRotation;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public GameObject soundTrigger;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        if(locked)
        {
            //pnlDialogue.GetComponent<Dialogue>().setText("Give me the keys, you COCKSUCKER!");
			AudioClip ac = soundTrigger.GetComponent<AudioShuffler>().GetAudioClip();
			GetComponent<AudioSource>().PlayOneShot(ac);
        }
        else
        {
            if(open)
            {
                GetComponent<AudioSource>().PlayOneShot(doorClose);
                LeanTween.rotateY(gameObject, closedRotation, .3f).setLoopOnce().setOnComplete(onCompleteClose);
            }
            else
            {
				GetComponent<AudioSource>().PlayOneShot(doorOpen);
                LeanTween.rotateY(gameObject, openedRotation, 1f).setLoopOnce().setOnComplete(onCompleteOpen);
				AudioClip ac = soundTrigger.GetComponent<AudioShuffler>().GetAudioClip();
				GetComponent<AudioSource>().PlayOneShot(ac);
            }
        }
    }

    void onCompleteOpen()
    {
        open = true;
    }

    void onCompleteClose()
    {
        open = false;
    }
}
