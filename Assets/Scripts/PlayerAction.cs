using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    public GameObject actionPanel;
    public int minDistanceInteraction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * minDistanceInteraction);

        if (Physics.Raycast(transform.position, transform.forward, out hit, minDistanceInteraction)) {
            if (hit.collider.tag == "Door") {
                actionPanel.SetActive(true);
                if (Input.GetKeyUp(KeyCode.E))
                {
                    hit.transform.GetComponentInParent<Door>().Interact();
                }
            }
            else if (hit.collider.tag == "SoundInteraction")
            {
                actionPanel.SetActive(true);
                if (Input.GetKeyUp(KeyCode.E))
                {
                    AudioClip ac = hit.transform.GetComponentInParent<AudioShuffler>().GetAudioClip();
                    hit.transform.GetComponentInParent<AudioSource>().PlayOneShot(ac);
                }
            }
        }
        else
        {
            actionPanel.SetActive(false);
        }
    }
}
