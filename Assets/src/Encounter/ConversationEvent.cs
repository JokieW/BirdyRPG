using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConversationEvent : EncounterEvent
{

    public string message = null;

    List<int> decodedAudio = new List<int>();
    List<string> decodedMessage = new List<string>();
    List<string> vowel = new List<string>()
    {
        "a",
        "e",
        "i",
        "o",
        "u",
        "y"
    };
    List<string> punctuation = new List<string>()
    {
        ",",
        ".",
        "!",
        "?",
        " ",
        "'"
    };
    readonly int CHARACTER_OFFSET = -97;

    int eventIndex = 0;

    ConversationOutput conversationOutput;

    float speed = 0.2f;
    float timer = 0f;

    public enum State
    {
        SLEEPING,
        STARTING,
        WRITING,
        WAITING,
        CLEARED
    }

    public State currentState = State.SLEEPING;
    bool playing = false;
    int currentIndex = 0;

    void Start()
    {
        conversationOutput = GameObject.Find("ConversationOutput").GetComponent<ConversationOutput>();
        DecodeMessage();
    }

    void Update()
    {
        switch(currentState)
        {
            case State.STARTING:
                Starting();
                break;
            case State.WRITING:
                Writing();
                break;
            case State.WAITING:
                Waiting();
                break;
        }        
    }

    void Starting()
    {
        conversationOutput.TurnOn();
        currentState = State.WRITING;
    }

    void Writing()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 0.01f;
        }
        if (currentIndex < decodedMessage.Count)
        {
            if (timer > speed)
            {
                conversationOutput.TickConversation(decodedMessage[currentIndex], decodedAudio[currentIndex]);
                currentIndex++;
                timer = 0f;
            }
            timer += Time.deltaTime;
        }
        else
        {
            currentState = State.WAITING;
            currentIndex = 0;
        }
    }

    void Waiting()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(eventIndex > 0)
            {
                eventIndex--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(eventIndex < nextEvent.Count - 1)
            {
                eventIndex++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Finished();
        }
    }

    void Finished()
    {
        if(oneTime)
        {
            currentState = State.CLEARED;
        }
        else
        {
            currentState = State.SLEEPING;
            Reset();
        }
        conversationOutput.TurnOff();

        NextEvent();
    }

    override public void NextEvent()
    {
        if(eventIndex > 0)
        {
            nextEvent[eventIndex].Play();
        }
        else
        {
            base.NextEvent();
        }
    }

    void DecodeMessage()
    {
        string substring = null;
        int index = 0;
        while (index < message.Length)
        {
            if (!vowel.Contains(message.Substring(index, 1)) && !punctuation.Contains(message.Substring(index, 1)) && substring != null)
            {
                decodedMessage.Add(substring);
                decodedAudio.Add((substring[0] + "").ToLower()[0] + CHARACTER_OFFSET);
                substring = null;
            }

            substring += message.Substring(index, 1);

            index++;
        }

        if (substring != null)
        {
            decodedMessage.Add(substring);
            decodedAudio.Add(substring[0] + CHARACTER_OFFSET);
            substring = null;
        }
    }

    public override void Play()
    {
        currentState = State.STARTING;
    }

    public override bool IsCleared()
    {
        return (currentState == State.CLEARED);
    }

    public void Reset()
    {
        currentState = State.SLEEPING;
        currentIndex = 0;
        speed = 0.2f;

        base.Reset();
    }
}
