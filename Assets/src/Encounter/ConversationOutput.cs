using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ConversationOutput : MonoBehaviour {

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

    public void ClearText()
    {

    }

    public void AddText(string text)
    {
        this.text.text += text;
    }

}
