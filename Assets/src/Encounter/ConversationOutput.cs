using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConversationOutput : MonoBehaviour {

    public GameObject leftPortrait;
    public GameObject rightPortrait;
    public GameObject textPanel;
    public GameObject textBox;

    public AudioSource[] audioSources = new AudioSource[26];

    public Text text;

	void Start () {
	
	}
	

	void Update () {
	
	}

    public void TickConversation(string text, int index)
    {
        AddText(text);
        PlayAudio(index);
    }

    void PlayAudio(int index)
    {
        audioSources[index].Play();
    }

    public void TurnOn()
    {
        textPanel.SetActive(true);
        textBox.SetActive(true);
    }

    public void TurnOff()
    {
        ClearText();
        leftPortrait.SetActive(false);
        rightPortrait.SetActive(false);
        textPanel.SetActive(false);
        textBox.SetActive(false);
    }

    void ClearText()
    {
        this.text.text = "";

    }

    public void AddText(string text)
    {
        this.text.text += text;
    }

}
