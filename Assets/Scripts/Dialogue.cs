using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    private float time;
    public float dialogueTime;
    public GameObject dialoguePanel;
    public GameObject dialogueText;

	// Use this for initialization
	void Start () {
        time = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (time < 0)
        {
            dialoguePanel.SetActive(false);
        }
        time -= Time.deltaTime;
	}

    public void setText(string text)
    {
        dialoguePanel.SetActive(true);
        dialogueText.GetComponent<Text>().text = text;
        time = dialogueTime;
    }
}
