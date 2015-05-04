using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConversationEvent : EncounterEvent
{

    public string message = null;
    public Sprite portrait;

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

    ConversationOutput conversationOutput;

    float speed = 0.25f;
    float timer = 0f;

    public bool oneTime = false;

    bool playing = false;
    int currentIndex = 0;

    void Start()
    {
        conversationOutput = GameObject.Find("TextOutput").GetComponent<ConversationOutput>();
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
        conversationOutput.TurnOn(portrait, false);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Finished();
        }
    }

    void Finished()
    {
        Reset();

        conversationOutput.TurnOff();

        if(oneTime)
        {
            currentState = State.CLEARED;
        }

        NextEvent();
    }

    void AltDecodeMessage()
    {
        string substring = null;
        int index = 0;
        while(index < message.Length)
        {
            if(message.Substring(index, 1) == " ")
            {
                substring += message.Substring(index, 1);
                decodedMessage.Add(substring);
                substring = null;
            }
            else
            {
                substring += message.Substring(index, 1);
                if(substring.Length == 1)
                {
                    decodedAudio.Add((substring[0] + "").ToLower()[0] + CHARACTER_OFFSET);
                }
            }

            index++;
        }

        if (substring != null)
        {
            decodedMessage.Add(substring);
            decodedAudio.Add(substring[0] + CHARACTER_OFFSET);
            substring = null;
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

        //base.Reset();
    }
}
