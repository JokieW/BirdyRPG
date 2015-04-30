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
        " "
    };
    readonly int CHARACTER_OFFSET = -97;

    ConversationOutput conversationOutput;

    float speed = 0.2f;
    float timer = 0f;

    bool playing = false;
    int currentIndex = 0;

    void Start()
    {
        conversationOutput = GameObject.Find("ConversationOutput").GetComponent<ConversationOutput>();
        DecodeMessage();
        PlayMessage();
    }

    void Update()
    {
        if(playing)
        {
            if(currentIndex < decodedMessage.Count)
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
                playing = false;
                currentIndex = 0;
            }
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

    void PlayMessage()
    {
        playing = true;
    }
}
