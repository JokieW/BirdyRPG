using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EncounterEvent : MonoBehaviour {

    public List<EncounterEvent> nextEvent = new List<EncounterEvent>();

    //public bool oneTime = false;

    public enum State
    {
        SLEEPING,
        STARTING,
        FIGHTING,
        WRITING,
        WAITING,
        RESETING,
        CLEARED
    }

    public State currentState = State.SLEEPING;

    public virtual void Play()
    {
        NextEvent();
    }

    public virtual bool IsCleared()
    {
        return false;
    }

    public virtual void Reset()
    {
        foreach (EncounterEvent e in nextEvent)
        {
            e.Reset();
        }
    }

    public virtual void NextEvent()
    {
        foreach (EncounterEvent e in nextEvent)
        {
            if(!e.IsCleared())
            {
                e.Play();
                break;
            }
        }
    }

}
