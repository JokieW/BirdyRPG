using UnityEngine;
using System.Collections;

public class ItemEvent : EncounterEvent {
    //public Ditto item;

    bool cleared = false;

    ItemOutput itemOutput;

    public enum State
    {
        SLEEPING,
        STARTING,
        WAITING,
        CLEARED
    }

    State currentState;

    public override void Play()
    {
        currentState = State.STARTING;
    }

    void Start()
    {
        itemOutput = GameObject.Find("TextOutput").GetComponent<ItemOutput>();
    }

    void Update()
    {
        switch (currentState)
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
        itemOutput.TurnOn();
        //itemOutput.SetText("You have just acquired a : " + item.handle + ".");
        currentState = State.WAITING;
        //GameObject.Find("Player").GetComponent<Inventory>().AddItem(item);
    }

    void Waiting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            itemOutput.TurnOff();
            currentState = State.CLEARED;
            NextEvent();
        }
    }

    public override bool IsCleared()
    {
        return cleared;
    }
}
