using UnityEngine;
using System.Collections;

public class FightEvent : EncounterEvent {

    public EncounterEvent rootEvent;

    bool isCleared = false;

    public bool temporaryWinState = false;

    void Update()
    {
        switch (currentState)
        {
            case State.STARTING:
                Starting();
                break;
            case State.FIGHTING:
                Fighting();
                break;
        }
    }

    void Starting()
    {
        SetCamera();
        currentState = State.FIGHTING;
    }

    void Fighting()
    {
        FightOver(temporaryWinState);
        Debug.Log("Fighting occurs.");
        //Put code that checks to see if the player wins or not.
    }

    public override void Play()
    {
        currentState = State.STARTING;
    }

    public void FightOver(bool playerWon)
    {
        if(playerWon)
        {
            isCleared = true;
            currentState = State.CLEARED;
            WinEvent();
        }
        else
        {
            Reset();
            LoseEvent();
        }
        ResetCamera();
    }

    public override void Reset()
    {
        currentState = State.SLEEPING;
    }

    void SetCamera()
    {
        //Change camera's position
    }

    void ResetCamera()
    {
        //Reset camera's position
    }

    void WinEvent()
    {
        nextEvent[0].Play();
        rootEvent.currentState = State.CLEARED;
    }

    void LoseEvent()
    {
        nextEvent[1].Play();
    }
}
/*

using UnityEngine;
using System.Collections;

public class FightEvent : EncounterEvent {

    public EncounterEvent rootEvent;

    bool isCleared = false;

    public bool temporaryWinState = false;

    public Transform battleCamera;

    Vector3 defaultPosition = Vector3.zero;
    Quaternion defaultRotation = new Quaternion();

    bool playerWon = false;

    void Start()
    {
        defaultPosition = Camera.main.transform.position;
        defaultRotation = Camera.main.transform.rotation;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.STARTING:
                Starting();
                break;
            case State.FIGHTING:
                Fighting();
                break;
            case State.RESETING:
                ResetCamera();
                break;
        }
    }

    void Starting()
    {
        SetCamera();
        if(Camera.main.transform.position == battleCamera.position && Camera.main.transform.rotation == battleCamera.rotation)
        {
            currentState = State.FIGHTING;
        }
        //currentState = State.FIGHTING;
    }

    void Fighting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FightOver(temporaryWinState);
            Debug.Log("Fighting occurs.");
            //Put code that checks to see if the player wins or not.
        }
    }

    public override void Play()
    {
        currentState = State.STARTING;
    }

    public void FightOver(bool playerWon)
    {
        this.playerWon = playerWon;
        Reset();
    }

    public override void Reset()
    {
        currentState = State.RESETING;
        //currentState = State.SLEEPING;
    }

    void SetCamera()
    {
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, battleCamera.position, Time.deltaTime * 30);
        Camera.main.transform.rotation = Quaternion.RotateTowards(Camera.main.transform.rotation, battleCamera.rotation, Time.deltaTime * 30);
    }

    void ResetCamera()
    {
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, defaultPosition, Time.deltaTime * 30);
        Camera.main.transform.rotation = Quaternion.RotateTowards(Camera.main.transform.rotation, defaultRotation, Time.deltaTime * 30);
        if (Camera.main.transform.position == defaultPosition)
        {
            Camera.main.transform.rotation = defaultRotation;
            if (playerWon)
            {
                isCleared = true;
                WinEvent();
            }
            else
            {
                LoseEvent();
            }
        }
    }

    void WinEvent()
    {
        nextEvent[0].Play();
        rootEvent.currentState = State.CLEARED;
    }

    void LoseEvent()
    {
        nextEvent[1].Play();
    }
}
*/