using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BranchEvent : EncounterEvent {

    public Sprite portrait;
    int answerIndex = 0;
    public string question;
    public List<string> answers = new List<string>();

	ConversationOutput conversationOutput;

	void Start () {
	    conversationOutput = GameObject.Find("TextOutput").GetComponent<ConversationOutput>();
	}
	
	// Update is called once per frame
	void Update () {
        switch(currentState)
        {
            case State.STARTING:
                Starting();
                break;
            case State.WAITING:
                Waiting();
                break;
        }
	}

    void Starting()
    {
        if(portrait != null)
        {
            conversationOutput.TurnOn(portrait, true);
        }
        else
        {
            conversationOutput.TurnOn();
        }
        
        AskQuestion();
        currentState = State.WAITING;
    }

    void Waiting()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (answerIndex > 0)
            {
                answerIndex--;
                AskQuestion();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (answerIndex < nextEvent.Count - 1)
            {
                answerIndex++;
                AskQuestion();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            NextEvent();
        }
    }

    void AskQuestion()
    {
        conversationOutput.ClearText();
        conversationOutput.AddText(question + "\n");
        for(int index = 0; index < answers.Count; index++)
        {
            if(answerIndex == index)
            {
                conversationOutput.AddText("> ");
            }
            else
            {
                conversationOutput.AddText("   ");
            }
            conversationOutput.AddText(answers[index] + "\n");
        }
    }

    public override void Play()
    {
        currentState = State.STARTING;
    }


    override public void NextEvent()
    {
        Reset();
        nextEvent[answerIndex].Play();
        answerIndex = 0;
    }

    void Reset()
    {
        currentState = State.SLEEPING;
        conversationOutput.TurnOff();
    }
}
